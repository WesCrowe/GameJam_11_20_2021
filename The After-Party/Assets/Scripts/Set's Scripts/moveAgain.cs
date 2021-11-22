using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAgain : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "DontOverlay")
        {
            print("Crash");
            Vector3 rand1 = new Vector3((float)Random.Range(305, 931), (float)Random.Range(25, 394), 0f);
            transform.position = rand1;
        }
    }
}
