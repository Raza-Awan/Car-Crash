using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    GameObject rcc_Camera;
    GameObject slowMotionCam;

    public float slowMotionTimeValue;

    float startTime;
    float startFixedDeltaTime;

    // Start is called before the first frame update
    void Start()
    {
        rcc_Camera = GameObject.Find("RCCCamera");
        slowMotionCam = this.gameObject.GetComponentInChildren<Camera>().gameObject;

        slowMotionCam.SetActive(false);
        //rcc_Camera.SetActive(true);

        startTime = Time.timeScale;
        startFixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        slowMotionCam.transform.LookAt(transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartSlowMotion();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopSlowMotion();
        }
    }

    public void StartSlowMotion()
    {
        slowMotionCam.SetActive(true);
        rcc_Camera.SetActive(false);
        Time.timeScale = slowMotionTimeValue;
        Time.fixedDeltaTime = startFixedDeltaTime * slowMotionTimeValue;
    }
    public void StopSlowMotion()
    {
        rcc_Camera.SetActive(true);
        slowMotionCam.SetActive(false);
        Time.timeScale = startTime;
        Time.fixedDeltaTime = startFixedDeltaTime;
    }
}
