using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Video;

public class gameFunctions : MonoBehaviour
{
    [SerializeField] string greenSpeedy;
    [SerializeField] string greenSmart;
    [SerializeField] string greenSneak;
    [SerializeField] string orangeSpeedy;
    [SerializeField] string orangeSmart;
    [SerializeField] string orangeSneak;
    [SerializeField] string blueSpeedy;
    [SerializeField] string blueSmart;
    [SerializeField] string blueSneak;
    [SerializeField] string blackSpeedy;
    [SerializeField] string blackSmart;
    [SerializeField] string blackSneak;

    [SerializeField] string youDidIt;

    [SerializeField] GameObject badge;


    public VideoPlayer[] vids;
    public GameObject[] thumbs;

    public GameObject[] options;

    public string oneIs;
    public string twoIs;
    public string thrIs;
    public string fouIs;

    public bool started;
    bool twoStarted;

    bool threeOkayToStartSmileFace;
    bool fourOkayToStartSmileFace;
    bool endingOkay;
    bool endingHappened;

    bool thrStarted;
    bool fouStarted;

    // Update is called once per frame
    void Update()
    {
        if (vids[0].isPlaying && endingHappened == false)
        {
            started = true;
        }
        if (vids[0].isPlaying == false && started == true && twoStarted == false)
        {
            if (twoIs != "" && oneIs == "Fast")
            {
                string videoPath;
                if (twoIs == "Smart")
                {
                    videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, orangeSmart);
                    vids[1].url = videoPath;
                }
                else if (twoIs == "Fast")
                {
                    videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, orangeSpeedy);
                    vids[1].url = videoPath;
                }
                else if (twoIs == "Sneak")
                {
                    videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, orangeSneak);
                    vids[1].url = videoPath;
                }
                vids[1].Play();
                thumbs[1].SetActive(false);
                twoStarted = true;
            }
            else
            {
                started = false;
            }
        }
        if (vids[1].isPlaying && endingHappened == false)
            threeOkayToStartSmileFace = true;
        if (vids[1].isPlaying == false && threeOkayToStartSmileFace == true && thrStarted == false)
        {
            if (thrIs != "" && twoIs == "Smart")
            {
                threeOkayToStartSmileFace = false;
                string videoPath;
                if (thrIs == "Smart")
                {
                    videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, blueSmart);
                    vids[2].url = videoPath;
                }
                else if (thrIs == "Fast")
                {
                    videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, blueSpeedy);
                    vids[2].url = videoPath;
                }
                else if (thrIs == "Sneak")
                {
                    videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, blueSneak);
                    vids[2].url = videoPath;
                }
                vids[2].Play();
                thumbs[2].SetActive(false);
                thrStarted = true;
            }
            else
            {
                started = false;
                twoStarted = false;
                threeOkayToStartSmileFace = false;
            }
        }

        if (vids[2].isPlaying && endingHappened == false)
            fourOkayToStartSmileFace = true;

        if (vids[2].isPlaying == false && fourOkayToStartSmileFace == true && fouStarted == false)
        {
            if (fouIs != "" && thrIs == "Fast")
            {
                fourOkayToStartSmileFace = false;
                string videoPath;
                if (fouIs == "Smart")
                {
                    videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, blackSmart);
                    vids[3].url = videoPath;
                }
                else if (fouIs == "Fast")
                {
                    videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, blackSpeedy);
                    vids[3].url = videoPath;
                }
                else if (fouIs == "Sneak")
                {
                    videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, blackSneak);
                    vids[3].url = videoPath;
                }
                vids[3].Play();
                thumbs[3].SetActive(false);
                fouStarted = true;
            }
            else
            {
                started = false;
                twoStarted = false;
                thrStarted = false;
                fourOkayToStartSmileFace = false;
            }
        }

        if (vids[3].isPlaying && endingHappened == false)
            endingOkay = true;


        if (vids[3].isPlaying == false && endingOkay == true)
        {
            Debug.Log("1");
            if (fouIs == "Sneak")
            {
                Debug.Log(2);
                string videoPath;
                videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, youDidIt);
                vids[0].url = videoPath;
                vids[1].url = videoPath;
                vids[2].url = videoPath;
                vids[3].url = videoPath;
                
                vids[0].Play();
                vids[1].Play();
                vids[2].Play();
                vids[3].Play();
                started = false;
                twoStarted = false;
                thrStarted = false;
                fouStarted = false;
                endingOkay = false;
                endingHappened = true;
                badge.SetActive(true);
            }
            else
            {
                Debug.Log("3");
                started = false;
                twoStarted = false;
                thrStarted = false;
                fouStarted = false;
                endingOkay = false;
            }
        }
    }

    public void PlayVideo()
    {
        if (oneIs != "" && started == false)
        {
            string videoPath;
            if (oneIs == "Smart")
            {
                videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, greenSmart);
                vids[0].url = videoPath;
            }
            else if (oneIs == "Fast")
            {
                videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, greenSpeedy);
                vids[0].url = videoPath;
            }
            else if (oneIs == "Sneak")
            {
                videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, greenSneak);
                vids[0].url = videoPath;
            }
            vids[0].Play();
            thumbs[0].SetActive(false);
            endingHappened = false;
        }
    }
}
