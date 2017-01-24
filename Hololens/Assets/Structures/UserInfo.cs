using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo
{
    public string token;
    public string id;

    public UserInfo() { }
    public UserInfo(string theJson)
    {

        JSONObject j = new JSONObject(theJson);

        this.id = j.GetField("id").ToString();
        this.token = j.GetField("token").ToString();
    }
    
}
