using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class WinCameraPath : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 1f;
    float distanceTravelled;
    public static GameObject lookTarget;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);

        gameObject.transform.LookAt(lookTarget.transform);
    }
}
