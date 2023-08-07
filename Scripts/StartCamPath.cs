using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class StartCamPath : MonoBehaviour
{
    public PathCreator pathCreator;
    public GameObject lookTarget;
    public float speed = 1f;
    float distanceTravelled;

    float initialSpeed;

    public static bool camStopped;

    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = speed;

        camStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);

        gameObject.transform.LookAt(lookTarget.transform);

        if (distanceTravelled >= pathCreator.path.length || StartCamManager.skip == true)
        {
            transform.position = pathCreator.path.GetPoint(pathCreator.path.NumPoints - 1); // stop camera at the last point vertex of path creator.
            gameObject.transform.LookAt(lookTarget.transform);
            speed = 0f;
            camStopped = true;
        }

        if (camStopped == false)
        {
            speed = initialSpeed;
        }
    }
}
