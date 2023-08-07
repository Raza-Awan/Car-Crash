using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Holder : MonoBehaviour
{
    public List<GameObject> aiCars;

    public static int totalAiCars;

    public static int count;

    // Start is called before the first frame update
    void Start()
    {
        totalAiCars = aiCars.Count;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
