﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using HoloToolkit.Sharing;
using HoloToolkit.Unity;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Broadcasts the head transform of the local user to other users in the session,
/// and adds and updates the head transforms of remote users.
/// Head transforms are sent and received in the local coordinate space of the GameObject
/// this component is on.
/// </summary>
public class RemoteHeadManager : Singleton<RemoteHeadManager>
{

    public GameObject ourDevice;
    public float CONVO_RADIUS = 6.0f;
    public bool isExploration = true;
    public class RemoteHeadInfo
    {
        public long UserID;
        public GameObject HeadObject;
    }

    /// <summary>
    /// Keep a list of the remote heads, indexed by XTools userID
    /// </summary>
    Dictionary<long, RemoteHeadInfo> remoteHeads = new Dictionary<long, RemoteHeadInfo>();

    void Start()
    {
        ourDevice = GameObject.Find("HoloLensCamera");

        CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.HeadTransform] = this.UpdateHeadTransform;

        SharingSessionTracker.Instance.SessionJoined += Instance_SessionJoined;
        SharingSessionTracker.Instance.SessionLeft += Instance_SessionLeft;
    }

    void Update()
    {
        // Grab the current head transform and broadcast it to all the other users in the session
        Transform headTransform = Camera.main.transform;

        // Transform the head position and rotation from world space into local space
        Vector3 headPosition = this.transform.InverseTransformPoint(headTransform.position);
        Quaternion headRotation = Quaternion.Inverse(this.transform.rotation) * headTransform.rotation;

        CustomMessages.Instance.SendHeadTransform(headPosition, headRotation);
    }

    /// <summary>
    /// Called when an existing user leaves the session.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Instance_SessionLeft(object sender, SharingSessionTracker.SessionLeftEventArgs e)
    {
        if (e.exitingUserId != SharingStage.Instance.Manager.GetLocalUser().GetID())
        {
            RemoveRemoteHead(this.remoteHeads[e.exitingUserId].HeadObject);
            this.remoteHeads.Remove(e.exitingUserId);
        }
    }

    /// <summary>
    /// Called when a remote user is joins the session.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Instance_SessionJoined(object sender, SharingSessionTracker.SessionJoinedEventArgs e)
    {
        if (e.joiningUser.GetID() != SharingStage.Instance.Manager.GetLocalUser().GetID())
        {
            GetRemoteHeadInfo(e.joiningUser.GetID());
        }
    }

    /// <summary>
    /// Gets the data structure for the remote users' head position.
    /// </summary>
    /// <param name="userID"></param>
    /// <returns></returns>
    public RemoteHeadInfo GetRemoteHeadInfo(long userID)
    {
        RemoteHeadInfo headInfo;

        // Get the head info if its already in the list, otherwise add it
        if (!this.remoteHeads.TryGetValue(userID, out headInfo))
        {
            headInfo = new RemoteHeadInfo();
            headInfo.UserID = userID;
            headInfo.HeadObject = CreateRemoteHead();

            this.remoteHeads.Add(userID, headInfo);
        }

        return headInfo;
    }


    float previousDistance = 0.0f;
    /// <summary>
    /// Called when a remote user sends a head transform.
    /// </summary>
    /// <param name="msg"></param>
    void UpdateHeadTransform(NetworkInMessage msg)
    {
        // Parse the message
        long userID = msg.ReadInt64();

        Vector3 headPos = CustomMessages.Instance.ReadVector3(msg);

        Quaternion headRot = CustomMessages.Instance.ReadQuaternion(msg);

        RemoteHeadInfo headInfo = GetRemoteHeadInfo(userID);
        headInfo.HeadObject.transform.localPosition = headPos;
        headInfo.HeadObject.transform.localRotation = headRot;

        float distanceBetweenUs = Vector3.Distance(headPos, ourDevice.GetComponent<Transform>().position);



        /*
         * if this head object is close enough to us 
         * to enable conversation mode or far enough to start
         * exploration mode, do it.
         */
         //if we come closer than our conversation radius

        if(distanceBetweenUs < CONVO_RADIUS)
        {
            GameObject toDeactivate = headInfo.HeadObject.GetComponent<Transform>()
                .Find("Conversation Mode Default(Clone)")
                .Find("Exploration Mode").gameObject;
            if (toDeactivate != null)
            {
                toDeactivate.SetActive(false);
                isExploration = false;
            } 
            GameObject toActivate = headInfo.HeadObject.GetComponent<Transform>()
                .Find("Conversation Mode Default(Clone)")
                .Find("Conversation Mode").gameObject;
            if (toActivate != null)
            {
                toActivate.SetActive(true);
            }
        }
        //if we move further than our conversation radius
        else if (distanceBetweenUs > CONVO_RADIUS ) {


            if (headInfo.HeadObject.activeSelf == true)
            {

                GameObject toDeactivate = headInfo.HeadObject.GetComponent<Transform>()
                    .Find("Conversation Mode Default(Clone)")
                    .FindChild("Conversation Mode").gameObject;
                if(toDeactivate != null)
                {
                    toDeactivate.SetActive(false);
                }
                GameObject toActivate = headInfo.HeadObject.GetComponent<Transform>()
                    .Find("Conversation Mode Default(Clone)")
                    .FindChild("Exploration Mode").gameObject;
                if (toActivate != null)
                {
                    toActivate.SetActive(true);
                    isExploration = true;
                }
            }

        }

        //set up the next previous distance
        previousDistance = distanceBetweenUs;

    }

    /// <summary>
    /// Creates a new game object to represent the user's head.
    /// </summary>
    /// <returns></returns>
    GameObject CreateRemoteHead()
    {
        GameObject newHeadObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject userHeadObj = Instantiate((GameObject)Resources.Load("Conversation Mode Default"));

        newHeadObj.GetComponent<Renderer>().enabled = false;
        newHeadObj.GetComponent<BoxCollider>().enabled = false;


        newHeadObj.transform.parent = this.gameObject.transform;
        userHeadObj.transform.parent = newHeadObj.gameObject.transform;
        newHeadObj.name = "Player";
        newHeadObj.transform.localScale = Vector3.one * 0.2f;
        return newHeadObj;
    }

    /// <summary>
    /// When a user has left the session this will cleanup their
    /// head data.
    /// </summary>
    /// <param name="remoteHeadObject"></param>
	void RemoveRemoteHead(GameObject remoteHeadObject)
    {
        DestroyImmediate(remoteHeadObject);
    }
}