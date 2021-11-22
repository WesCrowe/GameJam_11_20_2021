using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsirisGaze : MonoBehaviour
{

    private Vector3 StartPosition;
    private Vector3 ActivePosition;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        StartPosition = transform.position;
        ActivePosition = StartPosition;
        ActivePosition.y += 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<BoxCollider2D>().enabled)
        {
            transform.position = ActivePosition;
        }
        else
        {
            transform.position = StartPosition;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        print("Something triggered");
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "NPC")
        {
            other.gameObject.GetComponent<OsirisPlayer>().stunned = true;
            print("Stunned a player");
        }
    }
}
