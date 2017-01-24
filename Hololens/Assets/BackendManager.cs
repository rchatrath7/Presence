using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackendManager : MonoBehaviour {

    public UserInfo myInfo;
    public InteractionObject myInteractionObjectOne;
    public InteractionObject myInteractionObjectTwo;


    public string myUsername1 = "LucasLucas";
    public string myPassword1 = "asdfasdf";



    public string token1 = "46a00b0e1f0244506249840ad9d278a5af7810de";
    public string token2 = "cfab0af5b5c63966269cad84d6535c847235eec5";
  

    // Use this for initialization
    void Start () {

        StartCoroutine(RegisterThisPlayer());

        StartCoroutine(GetRequestUserInfo());
	}

    InteractionObject temp;


    public IEnumerator GetRequestUserInfo()
    {

        Dictionary<string, string> getHeader = new Dictionary<string, string>();

        getHeader.Add("Authorization", "Token " + token1);

        WWW getRequest = new WWW("http://" + "10.251.90.135:80/api/users/" + 2 + "/", null, getHeader);
        yield return getRequest;

        if(getRequest.error != null)
        {
            Debug.Log("error getting request : " + getRequest.error);
            
        }
        Debug.Log(getRequest.text);

        myInteractionObjectOne = new InteractionObject(getRequest.text);




        getHeader = new Dictionary<string, string>();

        getHeader.Add("Authorization", "Token " + token2);

        getRequest = new WWW("http://" + "10.251.90.135:80/api/users/" + 1 + "/", null, getHeader);
        yield return getRequest;

        if (getRequest.error != null)
        {
            Debug.Log("error getting request : " + getRequest.error);

        }
        Debug.Log(getRequest.text);

        myInteractionObjectTwo = new InteractionObject(getRequest.text);
    }

    IEnumerator RegisterThisPlayer()
    {
        WWWForm userCredPostHeader = new WWWForm();
        userCredPostHeader.AddField("username", myUsername1);
        userCredPostHeader.AddField("password", myPassword1);

        WWW userCredPost = new WWW("http://" + "10.251.90.135:80/api/session/", userCredPostHeader.data);


        yield return userCredPost;

        if (userCredPost.error != null)
        {
            Debug.Log("Error, bad communications with auth post to django"
                + userCredPost.error);
            yield break;
        }

        Debug.Log(userCredPost.text);
        myInfo = new UserInfo(userCredPost.text);

    }

	// Update is called once per frame
	void Update () {}

}
