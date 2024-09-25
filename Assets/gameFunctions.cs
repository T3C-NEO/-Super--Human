using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Video;

public class gameFunctions : MonoBehaviour
{
    public VideoClip high;
    public VideoClip low;

    public VideoPlayer[] one;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Switch()
    {
        one[0].clip = high;
    }

    public void PlayVideo()
    {
        for (int i = 0; i < one.Length; i++)
        {
            one[i].Play();
        }
    }
}
