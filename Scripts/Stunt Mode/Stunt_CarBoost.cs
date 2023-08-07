using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stunt_CarBoost : MonoBehaviour
{
    public RCC_Camera RCC_Camera;
    public GameObject boostbutton;
    public Image fillImage;
    public Text fill_text;
    public float increase_maxEngineTorque = 2f;
    public float increase_maxSpeed = 1.2f;
    public float boost_Time;                       // Total amount of time/seconds you can apply boost
    public float boost_RefillTime;                       // Total amount of time/seconds you can apply boost

    private Stunt_SelectedCarSpawner selected_Car_Spawner;

    public GameObject boost_Particles;
    public GameObject exhaust_Particles;

    float currentSpeed;
    float max_Speed;                  // 300 etc
    float max_Engine_Torque;          // 400 etc
    float max_Engine_Torque_At_RPM;   // 4500 etc 
    float initial_boostAmount;
    float initial_maxSpeed;           // stores initial values for resetting boost when released boost button
    float initial_maxEngineTorque;    // stores initial values for resetting boost when released boost button
    float initial_maxTorqueAtRPM;     // stores initial values for resetting boost when released boost button
    float minutes;
    float seconds;

    public bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        selected_Car_Spawner = GetComponent<Stunt_SelectedCarSpawner>();

        initial_boostAmount = boost_Time;
        isPressed = false;

        boost_Particles = selected_Car_Spawner.cars[selected_Car_Spawner.currentCarIndex].transform.Find("Boost_Air_Fx").gameObject;
        boost_Particles.SetActive(false);
        exhaust_Particles = selected_Car_Spawner.cars[selected_Car_Spawner.currentCarIndex].transform.Find("BoostExhaust_Fx").gameObject;
        exhaust_Particles.SetActive(false);

        // store value of max engine torque in here
        max_Engine_Torque = selected_Car_Spawner.cars[selected_Car_Spawner.currentCarIndex].GetComponent<RCC_CarControllerV3>().maxEngineTorque;

        // store value of max engine torque at rpm in here
        max_Engine_Torque_At_RPM = selected_Car_Spawner.cars[selected_Car_Spawner.currentCarIndex].GetComponent<RCC_CarControllerV3>().maxEngineTorqueAtRPM;

        // store value of max car speed in here
        max_Speed = selected_Car_Spawner.cars[selected_Car_Spawner.currentCarIndex].GetComponent<RCC_CarControllerV3>().maxspeed;

        initial_maxEngineTorque = max_Engine_Torque;
        initial_maxTorqueAtRPM = max_Engine_Torque_At_RPM;
        initial_maxSpeed = max_Speed;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = selected_Car_Spawner.cars[selected_Car_Spawner.currentCarIndex].GetComponent<RCC_CarControllerV3>().speed;

        if (currentSpeed >= 50)
        {
            boost_Particles.SetActive(true);
        }
        if (currentSpeed < 50)
        {
            boost_Particles.SetActive(false);
        }
        if (isPressed == true)
        {
            boost_Time -= Time.deltaTime;
            Enable_Boost();

            UpdateBoostFill(boost_Time);
        }

        if (boost_Time <= 0)
        {
            isPressed = false;
            //boostOver = true;
        }

        if (isPressed == false)
        {
            Disable_Boost();
        }

        if (isPressed == false && boost_Time < 5)
        {
            boost_Time += boost_RefillTime * Time.deltaTime;
            minutes = Mathf.FloorToInt(boost_Time / 60);
            seconds = Mathf.FloorToInt(boost_Time % 60);
            fill_text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            fillImage.fillAmount = Mathf.InverseLerp(0, initial_boostAmount, boost_Time);
        }

        if (boost_Time > initial_boostAmount)
        {
            boost_Time = initial_boostAmount;
        }

        if (FinishPoint.player_Win == true)
        {
            isPressed = false;
            //boostOver = false;
            boostbutton.SetActive(false);
        }


        if (max_Engine_Torque > 1000f)
        {
            max_Engine_Torque = 1000f;
        }

        if (isPressed == true)
        {
            RCC_Camera.TPSMaximumFOV = 85f;
        }
        else
        {
            RCC_Camera.TPSMaximumFOV = 60f;
        }
    }

    public void UpdateBoostFill(float boostTimeValue)
    {
        if (boostTimeValue < 0)
        {
            boostTimeValue = 0;
        }

        minutes = Mathf.FloorToInt(boostTimeValue / 60);
        seconds = Mathf.FloorToInt(boostTimeValue % 60);

        fill_text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        fillImage.fillAmount = Mathf.InverseLerp(0, initial_boostAmount, boost_Time);

    }
    public void EndBoost()
    {
        isPressed = true;
    }

    public void OnButtonDown()
    {
        if (currentSpeed >= 10)
        {
            isPressed = true;
        }
    }
    public void OnButtonUp()
    {
        isPressed = false;
    }

    private void Increase_EngineTorqueAtRPM()
    {
        //if (cars[currentCarIndex].name == "Koenigsegg Agera One1" || cars[currentCarIndex].name == "SM_Bugatti_Veyron")
        //{
        //    max_Engine_Torque_At_RPM = 7000f;
        //}
        max_Engine_Torque_At_RPM = 6900f;

        float apply_RPM_Boost = max_Engine_Torque_At_RPM; // increase value and stores it here
        selected_Car_Spawner.cars[selected_Car_Spawner.currentCarIndex].GetComponent<RCC_CarControllerV3>().maxEngineTorqueAtRPM = apply_RPM_Boost; // applies increases value here
    }

    private void Enable_Boost()
    {
        exhaust_Particles.SetActive(true);

        float apply_Boost = max_Engine_Torque * increase_maxEngineTorque; // increase value and stores it here
        selected_Car_Spawner.cars[selected_Car_Spawner.currentCarIndex].GetComponent<RCC_CarControllerV3>().maxEngineTorque = apply_Boost; // applies increases value here

        float apply_Boost_Speed = max_Speed * increase_maxSpeed; // increase value and stores it here
        selected_Car_Spawner.cars[selected_Car_Spawner.currentCarIndex].GetComponent<RCC_CarControllerV3>().maxspeed = apply_Boost_Speed; // applies increases value here

        Increase_EngineTorqueAtRPM();
    }

    private void Disable_Boost()
    {
        exhaust_Particles.SetActive(false);

        selected_Car_Spawner.cars[selected_Car_Spawner.currentCarIndex].GetComponent<RCC_CarControllerV3>().maxEngineTorque = initial_maxEngineTorque; // resets the boosted 

        selected_Car_Spawner.cars[selected_Car_Spawner.currentCarIndex].GetComponent<RCC_CarControllerV3>().maxEngineTorqueAtRPM = initial_maxTorqueAtRPM; // resets the boosted 

        selected_Car_Spawner.cars[selected_Car_Spawner.currentCarIndex].GetComponent<RCC_CarControllerV3>().maxspeed = initial_maxSpeed; // resets the boosted values
    }
}
