using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Collision_Check : MonoBehaviour
{
    public GameObject lose_Panel;

    public static bool isCollided;

    // Start is called before the first frame update
    void Start()
    {

        lose_Panel.SetActive(false);
        isCollided = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollided == true)
        {
            Invoke("PlayerLost", 2f);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isCollided = true;
            Hurdle_SelectedCarSpawner.explosion_Particles.SetActive(true);
        }
    }

    public void PlayerLost()
    {
        lose_Panel.SetActive(true);
    }
}
