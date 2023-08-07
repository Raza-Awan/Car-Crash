using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Manager : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;

    // Start is called before the first frame update
    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStatus_Checker.aiOnTrack == false)
        {
            GameStatus_Checker.aiOnTrack = true;
        }
        if (GameStatus_Checker.playerOnTrack == false)
        {
            losePanel.SetActive(true);
        }
        if (GameStatus_Checker.allAiOut == true)
        {
            winPanel.SetActive(true);
        }
    }
}
