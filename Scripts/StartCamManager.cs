using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCamManager : MonoBehaviour
{
    public Camera rcc_Cam;
    public GameObject startCam;
    public GameObject skipCanvas; 
    public GameObject rcc_Canvas;

    public static bool skip;

    // Start is called before the first frame update
    void Start()
    {
        skip = false;

        startCam.SetActive(true);
        skipCanvas.SetActive(true);
        rcc_Canvas.SetActive(false);
        rcc_Cam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartCamPath.camStopped == true || skip == true)
        {
            rcc_Cam.enabled = true;
            startCam.SetActive(false);
            skipCanvas.SetActive(false);
            rcc_Canvas.SetActive(true);
        }
        if (Ground_Collision_Check.isCollided == true)
        {
            rcc_Canvas.SetActive(false);
        }

        if (FinishPoint.player_Win == true)
        {
            rcc_Canvas.SetActive(false);
        }

        if (GameStatus_Checker.allAiOut == true || GameStatus_Checker.playerOnTrack == false)
        {
            rcc_Canvas.SetActive(false);
        }
    }

    public void Skip()
    {
        skip = true;
        Debug.Log("skip");
    }
}
