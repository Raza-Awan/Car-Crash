using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_Manager : MonoBehaviour
{
    public int currentCarIndex = 0;
    public GameObject[] carModels;

    // Start is called before the first frame update
    void Start()
    {
        currentCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);

        foreach (GameObject car in carModels)
        {
            car.SetActive(false);
        }
        carModels[currentCarIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Method to set the current car index
    public void SetCurrentCarIndex(int index)
    {
        carModels[currentCarIndex].SetActive(false);
        currentCarIndex = index; // This index is setted from Button_Holder script
        carModels[currentCarIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedCar", currentCarIndex);
    }
}
