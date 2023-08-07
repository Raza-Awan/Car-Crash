using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public GameObject Fire_Fx_Holder;

    public static bool player_Win;

    // Start is called before the first frame update
    void Start()
    {
        Fire_Fx_Holder.SetActive(false);

        player_Win = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player_Win = true;
            Fire_Fx_Holder.SetActive(true);
        }
    }
}
