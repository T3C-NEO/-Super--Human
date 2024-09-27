using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Video;

public class gameFunctions : MonoBehaviour
{
    public VideoClip fast1;
    public VideoClip smart1;

    public VideoPlayer[] one;

    public GameObject[] options;

    public string oneIs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayVideo()
    {
        if (oneIs != "")
        {
            if (oneIs == "Smart")
            {
                one[0].clip = smart1;
            }
            if (oneIs == "Fast")
            {
                one[0].clip = fast1;
            }
            one[0].Play();
        }
    }
}
