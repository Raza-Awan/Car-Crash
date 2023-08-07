using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer_Rotator : MonoBehaviour
{
    public Vector3 rotation_Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation_Speed * Time.deltaTime);
    }
}
