using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPointManager : MonoBehaviour
{
    public GameObject finishPoint;
    public GameObject winPanel;

    bool startAnimStop;

    // Start is called before the first frame update
    void Start()
    {
        startAnimStop = false;

        finishPoint.SetActive(true);
        winPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (DirectionArrow.allCollected == true && startAnimStop == true)
        {
            finishPoint.SetActive(true);
        }

        if ((StartCamPath.camStopped == true || StartCamManager.skip == true) && startAnimStop == false)
        {
            finishPoint.SetActive(false);
            startAnimStop = true;
        }

        if (FinishPoint.player_Win == true)
        {
            Invoke("EnableWinPanel", 2f);
        }
    }

    void EnableWinPanel()
    {
        winPanel.SetActive(true);
    }
}
