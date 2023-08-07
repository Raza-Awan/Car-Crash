using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus_Checker : MonoBehaviour
{
    public List<GameObject> triggeredObjectsList = new List<GameObject>();
    public static bool playerOnTrack;
    public static bool aiOnTrack;
    public static bool allAiOut;

    // Start is called before the first frame update
    void Start()
    {

        allAiOut = false;
        playerOnTrack = true;
        aiOnTrack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Ai_Holder.totalAiCars == Ai_Holder.count)
        {
            playerOnTrack = true;
            allAiOut = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerOnTrack = false;
        }

        if (other.gameObject.tag == "Ai_Car" && playerOnTrack == true)
        {
            GameObject triggeredObject = other.gameObject;
            triggeredObjectsList.Add(triggeredObject);
            Invoke("DeactiveAiCar", 2.5f);
            UpdateCount();
            aiOnTrack = false;
        }
    }

    void DeactiveAiCar()
    {
        foreach (GameObject triggeredObject in triggeredObjectsList)
        {
            GameObject parentObject = triggeredObject.transform.parent.gameObject;
            parentObject.SetActive(false);
        }
    }

    void UpdateCount()
    {
        Ai_Holder.count += 1;
    }
}
