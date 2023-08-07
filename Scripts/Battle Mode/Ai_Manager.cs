using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StopCar();
    }

    // Update is called once per frame
    void Update()
    {
        if (StartCamPath.camStopped == true || StartCamManager.skip == true)
        {
            MoveCar();
        }
    }

    private void StopCar()
    {
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
        this.GetComponent<RCC_CarControllerV3>().engineRunning = false;
    }

    private void MoveCar()
    {
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        this.GetComponent<RCC_CarControllerV3>().engineRunning = true;
    }
}
