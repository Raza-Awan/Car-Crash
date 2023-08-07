using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurdles_Collision_Check : MonoBehaviour
{
    public bool tookDamage;
    public static int health;
    public int healthCheck;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        tookDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthCheck = health;
        if (health <= 0)
        {
            health = 0;
        }

        if (tookDamage == true)
        {
            health -= 1;
            tookDamage = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hurdle")
        {
            tookDamage = true;
        }
    }
}
