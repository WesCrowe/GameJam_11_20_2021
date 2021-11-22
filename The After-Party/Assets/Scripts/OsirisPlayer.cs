using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsirisPlayer : MonoBehaviour
{

    public float points;
    public bool stunned;
    private BoxCollider2D Pcollider;
    //private Vector3 PInitTransform;

    private KeyCode[] keys = { KeyCode.S, KeyCode.DownArrow, KeyCode.V, KeyCode.K };
    private KeyCode myKey;
    private static int iter = 0;

    private SpriteRenderer sprtRender;
    private Sprite playerWake;
    private Sprite playerSnooze;
    private Sprite playerStunned;

    // Start is called before the first frame update
    void Start()
    {
        stunned = false;
        points = 0.0f;
        sprtRender = gameObject.GetComponent<SpriteRenderer>();
        playerWake = sprtRender.sprite;
        //playerSnooze = ;
        //playerStunned = ;

        Pcollider = gameObject.GetComponent<BoxCollider2D>();
        Pcollider.enabled = false;
        //PInitTransform = gameObject.transform.position;

        if (PlayerPrefs.GetInt("Players") <= iter)
        {
            myKey = keys[iter];
            iter++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!stunned) { 
            if (Input.GetKey(myKey))
            {
                points += 0.05f;
                //sprtRender.sprite = playerSnooze;
                sprtRender.color = Color.green;
                Pcollider.enabled = true;
                //transform.position = new Vector3(transform.position.x, transform.position.y - 0.0f);
            }
            else
            {
                //sprtRender.sprite = playerWake;
                sprtRender.color = Color.white;
                Pcollider.enabled = false;
                //transform.position = PInitTransform;
            }
        }
    }

    void FixedUpdate()
    {
        if (stunned)
        {
            //sprtRender.sprite = playerStunned;
            Pcollider.enabled = false;
            sprtRender.color = Color.red;
            StartCoroutine(Stunned());
        }
    }

    IEnumerator Stunned()
    {
        yield return new WaitForSeconds(1.5f);
        //sprtRender.sprite = playerWake;
        sprtRender.color = Color.white;
        stunned = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        print("Something triggered");
        stunned = true;
        print("Stunned a player");
    }
}
