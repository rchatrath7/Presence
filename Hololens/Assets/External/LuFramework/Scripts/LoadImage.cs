using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadImage : MonoBehaviour {

    public string url;

    IEnumerator Start()
    {
        Texture2D texture;
        texture = new Texture2D(4, 12, TextureFormat.DXT1, false);
        WWW www = new WWW(url);
        yield return www;
        www.LoadImageIntoTexture(texture);
        transform.GetComponent<Renderer>().material.mainTexture = texture;
    }
}
