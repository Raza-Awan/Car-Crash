using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Rotator : MonoBehaviour
{
    public Vector3 carRotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch screenTouch = Input.GetTouch(0);
            if (screenTouch.phase == TouchPhase.Moved)
            {
                transform.Rotate(carRotationSpeed * Time.deltaTime);
            }
        }
    }
}
