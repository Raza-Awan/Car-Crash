using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class StartCamLookTargetPath : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 1f;
    float distanceTravelled;

    float initialSpeed;

    bool Stopped;

    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = speed;

        Stopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);

        if (distanceTravelled >= pathCreator.path.length || StartCamManager.skip == true)
        {
            transform.position = pathCreator.path.GetPoint(pathCreator.path.NumPoints - 1); // stop camera at the last point vertex of path creator.
            speed = 0f;
            Stopped = true;
        }

        if (Stopped == false)
        {
            speed = initialSpeed;
        }
    }
}
