using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrow : MonoBehaviour
{
    public List<GameObject> collectables;
    public GameObject finishPoint;
    public int index;
    public static bool allCollected;
    public static bool indexPlus;

    // Start is called before the first frame update
    void Start()
    {
        allCollected = false;
        indexPlus = false;
        index = 0;

        foreach (GameObject collectable in collectables)
        {
            collectable.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StartCamManager.skip == true || StartCamPath.camStopped == true)
        {
            foreach (GameObject collectable in collectables)
            {
                collectable.SetActive(false);
            }
        }

        if (indexPlus == true)
        {
            indexPlus = false;
            index += 1;
        }

        if (index <= (collectables.Count - 1))
        {
            collectables[index].SetActive(true);
        }


        if (allCollected == false)
        {
            transform.LookAt(collectables[index].transform);
        }

        if (index == (collectables.Count - 1))
        {
            allCollected = true;
        }

        if (allCollected == true)
        {
            transform.LookAt(finishPoint.transform);
        }
    }
}
