using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunt_SelectedCarSpawner : MonoBehaviour
{
    public GameObject winCam;
    public GameObject winCamLook_Target;
    public GameObject Arrow;
    public int currentCarIndex = 0;
    public GameObject[] cars;

    public static GameObject explosion_Particles;
    GameObject smoke_Particles;

    GameObject rcc_Cam;

    // Start is called before the first frame update
    void Start()
    {
        WinCameraPath.lookTarget = winCamLook_Target;

        winCam.SetActive(false);
        rcc_Cam = GameObject.Find("RCCCamera");

        currentCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);

        foreach (GameObject car in cars)
        {
            car.SetActive(false);
        }
        cars[currentCarIndex].SetActive(true);
        winCam.transform.SetParent(cars[currentCarIndex].transform);
        Arrow.transform.SetParent(cars[currentCarIndex].transform);

        StopCar();

        smoke_Particles = cars[currentCarIndex].transform.Find("Smoke_Fx").gameObject;
        explosion_Particles = cars[currentCarIndex].transform.Find("Explosion_Fx").gameObject;

        smoke_Particles.SetActive(false);
        explosion_Particles.SetActive(false);

        winCamLook_Target.transform.SetParent(cars[currentCarIndex].transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (StartCamPath.camStopped == true || StartCamManager.skip == true)
        {
            MoveCar();
        }

        if (FinishPoint.player_Win == true)
        {
            StopCar();

            winCam.SetActive(true);
            rcc_Cam.SetActive(false);
            Arrow.SetActive(false);
        }

        if (Hurdles_Collision_Check.health <= 3)
        {
            smoke_Particles.SetActive(true);
        }

        if (Ground_Collision_Check.isCollided == true)
        {
            Invoke("StopCar", 1f);
        }
    }

    private void StopCar()
    {
        cars[currentCarIndex].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
        cars[currentCarIndex].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
        cars[currentCarIndex].GetComponent<RCC_CarControllerV3>().engineRunning = false;
    }

    private void MoveCar()
    {
        cars[currentCarIndex].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        cars[currentCarIndex].GetComponent<RCC_CarControllerV3>().engineRunning = true;
    }
}
