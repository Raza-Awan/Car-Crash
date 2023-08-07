using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Panel_Checker : MonoBehaviour
{
    public GameObject win_Panel;

    // Start is called before the first frame update
    void Start()
    {
        win_Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (FinishPoint.player_Win == true)
        {
            win_Panel.SetActive(true);
        }
    }
}
