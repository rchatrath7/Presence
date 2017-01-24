using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoLoading : MonoBehaviour {

    public string url;

    private WWW wwwData;
    private GUITexture gt;

    void Start()
    {
        wwwData = new WWW(url);
        gt = transform.GetChild(0).GetComponent<GUITexture>();
        gt.texture = wwwData.movie;
    }

    void Update()
    {
        MovieTexture m = gt.texture as MovieTexture;
        if (!m.isPlaying && m.isReadyToPlay)
            m.Play();
    }



}
