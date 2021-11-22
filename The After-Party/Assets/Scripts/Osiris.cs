using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Osiris : MonoBehaviour
{
    private bool stageTwo;
    private bool stageThree;

    private float startTime;

    private float minInclusive;
    private float maxInclusive;
    private float nextActionTime;
    private bool looking;

    private BoxCollider2D gaze;
    private SpriteRenderer sprtRender;
    public Sprite OsirisTalk, OsirisAlert, OsirisMad;

    // Start is called before the first frame update
    void Start()
    {
        stageTwo = true;
        stageThree = true;

        startTime = Time.time;

        minInclusive = 3.0f;
        maxInclusive = 6.5f;
        nextActionTime = startTime + 5.0f;
        looking = false;

        gaze = GameObject.Find("Gaze").GetComponent<BoxCollider2D>();
        sprtRender = gameObject.GetComponent<SpriteRenderer>();
        OsirisTalk = sprtRender.sprite;
        //OsirisAlert = ;
        //OsirisMad = ;
    }

    // Update is called once per frame
    void Update()
    {
        if (!looking)
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime += Random.Range(minInclusive, maxInclusive);
                StartCoroutine(LookOver());
            }
        }
    }

    void FixedUpdate()
    {
        if (Time.time > (startTime + 30.0f) && stageTwo)
        {
            minInclusive -= 0.5f;
            maxInclusive -= 1.0f;
            stageTwo = false;
        }
        else if (Time.time > (startTime + 45.0f) && stageThree)
        {
            minInclusive -= 1.0f;
            maxInclusive -= 1.5f;
            stageThree = false;
        }

        if (Time.time >= (startTime + 60f))
        {
            //end game
            SceneManager.LoadScene("Main Menu");
        }
    }

    IEnumerator LookOver()
    {
        looking = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        //sprtRender.sprite = OsirisAlert;
        yield return new WaitForSeconds(Random.Range(0.3f, 0.8f));

        gaze.enabled = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        //sprtRender.sprite = OsirisMad;
        yield return new WaitForSeconds(Random.Range(0.8f, 1.4f));

        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        //sprtRender.sprite = OsirisTalk;
        gaze.enabled = false;
        looking = false;
    }
}