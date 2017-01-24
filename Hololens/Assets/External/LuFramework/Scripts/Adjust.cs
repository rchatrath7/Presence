using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adjust : MonoBehaviour {

    [Range(0f, 0.15f)]
    public float padding = 0.15f;
    public GameObject node;
    GameObject parentGo;
    LineRenderer lineRenderer;

    public static bool isAdjusting = false;
    private bool nodesSpawned;

    private GameObject[] nodes;

    // Use this for initialization
    void Start () {
        isAdjusting = false;
        nodes = new GameObject[8];
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.numPositions = 16;
        nodesSpawned = false;
    }

    public void ToggleAdjustment()
    {
        Debug.Log("Toggled");

        if(!nodesSpawned)
        {
            nodesSpawned = true;

            lineRenderer.enabled = true;
            parentGo = new GameObject();
            parentGo.transform.SetParent(gameObject.transform);
            parentGo.name = "Adjustment mode";

            Vector3 leftTopBack = new Vector3(transform.position.x - ((transform.localScale.x / 2) + (transform.localScale.x * padding)), transform.position.y + ((transform.localScale.y / 2) + (transform.localScale.y * padding)), transform.position.z - ((transform.localScale.z / 2) + (transform.localScale.z * padding)));
            Vector3 leftTopFront = new Vector3(transform.position.x - ((transform.localScale.x / 2) + (transform.localScale.x * padding)), transform.position.y + ((transform.localScale.y / 2) + (transform.localScale.y * padding)), transform.position.z + ((transform.localScale.z / 2) + (transform.localScale.z * padding)));
            Vector3 leftBottomBack = new Vector3(transform.position.x - ((transform.localScale.x / 2) + (transform.localScale.x * padding)), transform.position.y - ((transform.localScale.y / 2) + (transform.localScale.y * padding)), transform.position.z - ((transform.localScale.z / 2) + (transform.localScale.z * padding)));
            Vector3 leftBottomFront = new Vector3(transform.position.x - ((transform.localScale.x / 2) + (transform.localScale.x * padding)), transform.position.y - ((transform.localScale.y / 2) + (transform.localScale.y * padding)), transform.position.z + ((transform.localScale.z / 2) + (transform.localScale.z * padding)));
            Vector3 rightBottomFront = new Vector3(transform.position.x + ((transform.localScale.x / 2) + (transform.localScale.x * padding)), transform.position.y - ((transform.localScale.y / 2) + (transform.localScale.y * padding)), transform.position.z + ((transform.localScale.z / 2) + (transform.localScale.z * padding)));
            Vector3 rightBottomBack = new Vector3(transform.position.x + ((transform.localScale.x / 2) + (transform.localScale.x * padding)), transform.position.y - ((transform.localScale.y / 2) + (transform.localScale.y * padding)), transform.position.z - ((transform.localScale.z / 2) + (transform.localScale.z * padding)));
            Vector3 rightTopFront = new Vector3(transform.position.x + ((transform.localScale.x / 2) + (transform.localScale.x * padding)), transform.position.y + ((transform.localScale.y / 2) + (transform.localScale.y * padding)), transform.position.z + ((transform.localScale.z / 2) + (transform.localScale.z * padding)));
            Vector3 rightTopBack = new Vector3(transform.position.x + ((transform.localScale.x / 2) + (transform.localScale.x * padding)), transform.position.y + ((transform.localScale.y / 2) + (transform.localScale.y * padding)), transform.position.z - ((transform.localScale.z / 2) + (transform.localScale.z * padding)));

            Vector3[] lineTargets = new Vector3[16];

            lineTargets[0] = leftTopBack;
            lineTargets[1] = rightTopBack;
            lineTargets[2] = rightTopFront;
            lineTargets[3] = leftTopFront;
            lineTargets[4] = leftTopBack;
            lineTargets[5] = leftBottomBack;
            lineTargets[6] = leftBottomFront;
            lineTargets[7] = rightBottomFront;
            lineTargets[8] = rightBottomBack;
            lineTargets[9] = leftBottomBack;
            lineTargets[10] = leftBottomFront;
            lineTargets[11] = leftTopFront;
            lineTargets[12] = rightTopFront;
            lineTargets[13] = rightBottomFront;
            lineTargets[14] = rightBottomBack;
            lineTargets[15] = rightTopBack;

            lineRenderer.SetPositions(lineTargets);

            nodes[0] = Instantiate(node, leftTopBack, Quaternion.identity) as GameObject;
            nodes[1] = Instantiate(node, leftTopFront, Quaternion.identity) as GameObject;
            nodes[2] = Instantiate(node, leftBottomBack, Quaternion.identity) as GameObject;
            nodes[3] = Instantiate(node, leftBottomFront, Quaternion.identity) as GameObject;
            nodes[4] = Instantiate(node, rightBottomFront, Quaternion.identity) as GameObject;
            nodes[5] = Instantiate(node, rightBottomBack, Quaternion.identity) as GameObject;
            nodes[6] = Instantiate(node, rightTopFront, Quaternion.identity) as GameObject;
            nodes[7] = Instantiate(node, rightTopBack, Quaternion.identity) as GameObject;

            foreach (GameObject go in nodes)
            {
                go.transform.SetParent(parentGo.transform);
            }

            
        }
        
        if(!isAdjusting)
        {
            parentGo.SetActive(true);
            lineRenderer.enabled = true;
            isAdjusting = true;
        } else { 
            lineRenderer.enabled = false;
            parentGo.SetActive(false);
            isAdjusting = false;
        }
    
        

    }
}
