using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float baseGrav = 0.98f;
    public float roadGravScale = .3f;
    public float offRoadGravScale = 1f;
    public float curGravScale = 0.1f;
    public float moveSpeed = 1f;
    Rigidbody2D rigid;
    public Vector2 velocity = new Vector2();

    // Player Movement
    //public float horizontal;
    //public float vertical;
    public float runSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //controls = new PlayerControls();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        rigid.gravityScale = curGravScale;
        //curGravScale = offRoadGravScale;
    }

    // Update is called once per frame
    void Update()
    {


        //rigid = gameObject.GetComponent<Rigidbody2D>();
        //rigid.gravityScale = -.2f;

        // if (Input.GetKey (KeyCode.UpArrow)) 
        // {
        //     rigid.AddForce(new Vector3(0,1,0), ForceMode2D.Force);
        // }
        // if (Input.GetKey (KeyCode.DownArrow)) 
        // {
        //     rigid.AddForce(new Vector3(0,-1,0), ForceMode2D.Force);
        // }
        // if (Input.GetKey (KeyCode.LeftArrow)) 
        // {
        //     rigid.AddForce(new Vector3(-1,0,0), ForceMode2D.Force);
        // }
        // if (Input.GetKey (KeyCode.RightArrow)) 
        // {
        //     rigid.AddForce(new Vector3(1,0,0), ForceMode2D.Force);
        // }

    }

    void FixedUpdate() {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        //bool inputFound = (hInput != 0 || vInput != 0);
        Vector2 grav = new Vector2(0, baseGrav * curGravScale);
        Vector2 move = new Vector2();
        //if (inputFound)
        //{
            move = new Vector2(hInput, vInput) * moveSpeed;
        //}
        velocity = (move - grav) * Time.deltaTime;
        rigid.velocity = velocity;
        transform.Translate(velocity);
    }

    //// This method of moving works,  but gravity no longer applies
    // private void FixedUpdate()
    // {
    //     rigid.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);   
    // }


    public void roadGravity()
    {
        print("Do Stuff");
        curGravScale = roadGravScale;
    }

    public void offRoadGravity()
    {
        curGravScale = offRoadGravScale;
    }
}
