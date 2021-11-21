using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float baseGrav = 0.98f;
    public float roadGravScale = 1f;
    public float offRoadGravScale = 2f;
    public float curGravScale = 50f;
    public float moveSpeed = 19.6f;
    Rigidbody2D rigid;
    public Vector2 velocity = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        //controls = new PlayerControls();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        // rigid.gravityScale = offRoadGrav;
        curGravScale = offRoadGravScale;
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        bool inputFound = (hInput != 0 || vInput != 0);
        Vector2 grav = new Vector2(0, baseGrav * curGravScale);
        Vector2 move = new Vector2();
        if (inputFound)
        {
            move = new Vector2(hInput, vInput) * moveSpeed;
        }
        velocity = (move - grav) * Time.deltaTime;
        rigid.velocity = velocity;
        // transform.Translate(velocity);
    }

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
