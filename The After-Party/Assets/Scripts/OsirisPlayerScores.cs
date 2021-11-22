using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OsirisPlayerScores : MonoBehaviour
{

    private OsirisPlayer player;
    private static int iter = 0;

    private Text buttonText;

    // Start is called before the first frame update
    void Start()
    {
        string thisPlayer = "Player " + (iter + 1).ToString();
        player = GameObject.Find(thisPlayer).GetComponent<OsirisPlayer>();
        iter++;

        buttonText = gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float currPoints = player.points;
        buttonText.text = currPoints.ToString("F2");
    }
}
