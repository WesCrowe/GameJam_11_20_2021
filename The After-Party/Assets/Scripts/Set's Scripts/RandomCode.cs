using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomCode : MonoBehaviour
{
    public GameObject theCode;
    public GameObject memorize;
    public GameObject getReady;
    public Text timer;
    Text codeText;
    int code;
    int num1;
    int num2;
    int num3;
    int num4;
    public Text livesNum;
    public Button first;
    public Text firstText;
    public Button second;
    public Text secondText;
    public Button third;
    public Text thirdText;
    public Button fourth;
    public Text fourthText;
    int lives;
    bool playing;
    bool won;
    bool lost;
    public GameObject setSmirk;
    public GameObject setAngry;
    public GameObject winText;
    public GameObject failText;
    public Button playAgain;
    float gameTime;

    void Start()
    {
        Time.fixedDeltaTime = 1f;
        lives = 3;
        prepare();
        won = false;
        lost = false;
    }

    private void Update()
    {
        timer.text = (60-(Time.time-5)).ToString();
        livesNum.text = lives.ToString();
        if(lives == 1)
        {
            lost = true;
        }
    }
    private void FixedUpdate()
    {
        gameTime++;
        if (won)
        {
            win();
        }
        else if (lost)
        {
            lose();
        }
        else
        {
            if (gameTime == 3)
            {
                getReady.SetActive(false);
                loadFirst();
                lives = 3;
            }
            if (gameTime == 5)
            {
                theCode.SetActive(false);
                memorize.SetActive(false);
                playing = true;
                timer.gameObject.SetActive(true);
                setButtons();
            }
            if (playing)
            {
                shuffleButtons();
            }
        }
    }

    void prepare()
    {
        theCode.SetActive(false);
        memorize.gameObject.SetActive(false);
        timer.gameObject.SetActive(false);
        first.gameObject.SetActive(false);
        second.gameObject.SetActive(false);
        third.gameObject.SetActive(false);
        fourth.gameObject.SetActive(false);
        winText.SetActive(false);
        failText.SetActive(false);
        setAngry.SetActive(true);
        setSmirk.SetActive(false);
        playAgain.gameObject.SetActive(false);
    }

    public void win()
    {
        won = true;
        playing = false;
        clearScreen();
        winText.SetActive(true);
        setAngry.SetActive(false);
        setSmirk.SetActive(true);
    }

    public void lose()
    {
        lost = true;
        playing = false;
        clearScreen();
        failText.SetActive(true);
        setAngry.SetActive(true);
        playAgain.gameObject.SetActive(true);
    }

    public void clearScreen(){
        theCode.SetActive(false);
        memorize.gameObject.SetActive(false);
        timer.gameObject.SetActive(false);
        first.gameObject.SetActive(false);
        second.gameObject.SetActive(false);
        third.gameObject.SetActive(false);
        fourth.gameObject.SetActive(false);
    }

    public void tryWin(Text buttonText)
    {
        //bug: always looses
        if (buttonText.text == codeText.text)
        {
            win();
        }
        else
        {
            lives--;
        }
    }

    public void playAgainClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameTime = gameTime - Time.timeSinceLevelLoad;
    }

    public void shuffleButtons()
    {
        Vector3 rand1 = new Vector3((float)Random.Range(305, 931), (float)Random.Range(25, 394), 0f);
        Vector3 rand2 = new Vector3((float)Random.Range(305, 931), (float)Random.Range(25, 394), 0f);
        Vector3 rand3 = new Vector3((float)Random.Range(305, 931), (float)Random.Range(25, 394), 0f);
        Vector3 rand4 = new Vector3((float)Random.Range(305, 931), (float)Random.Range(25, 394), 0f);
        first.transform.position = rand1;
        second.transform.position = rand2;
        third.transform.position = rand3;
        fourth.transform.position = rand4;
    }

    private void loadFirst()
    {
        codeText = theCode.GetComponent<Text>();
        code = Random.Range(-10, 10);
        codeText.text = code.ToString();
        codeText.gameObject.SetActive(true);
        memorize.gameObject.SetActive(true);
    }
    private void setButtons()
    {
        int pickRand = Random.Range(1, 8);
        first.gameObject.SetActive(true);
        second.gameObject.SetActive(true);
        third.gameObject.SetActive(true);
        fourth.gameObject.SetActive(true);
        if (pickRand == 1)
        {
            trueFirst();
        }
        if (pickRand == 2)
        {
            trueSecond();
        }
        if (pickRand == 3)
        {
            trueThird();
        }
        if (pickRand == 4)
        {
            trueFourth();
        }
        else
        {
            lie();
        }
    }

    private int getRandom()
    {
        return Random.Range(-100, 100);
    }



    void trueFirst()
    {
        firstText.text = code.ToString();
        num1 = getRandom();
        while(num1 == code)
        {
            num1 = getRandom();
        }
        secondText.text = num1.ToString();
        num2 = getRandom();
        while (num2 == code || num2 == num1)
        {
            num2 = Random.Range(-10, 10);
        }
        thirdText.text = num2.ToString();
        num3 = getRandom();
        while (num3 == code || num3 == num1 || num3 == num2)
        {
            num3 = getRandom();
        }
        fourthText.text = num3.ToString();
    }

    void trueSecond()
    {
        num1 = getRandom();
        firstText.text = num1.ToString();
        while (num1 == code)
        {
            num1 = getRandom();
        }
        secondText.text = code.ToString();
        num2 = getRandom();
        while (num2 == code || num2 == num1)
        {
            num2 = getRandom();
        }
        thirdText.text = num2.ToString();
        num3 = getRandom();
        while (num3 == code || num3 == num1 || num3 == num2)
        {
            num3 = getRandom();
        }
        fourthText.text = num3.ToString();
    }
    void trueThird()
    {
        num1 = getRandom();
        firstText.text = num1.ToString();
        while (num1 == code)
        {
            num1 = getRandom();
        }
        num2 = getRandom();
        while (num2 == code || num2 == num1)
        {
            num2 = getRandom();
        }
        secondText.text = num2.ToString();
        thirdText.text = code.ToString();
        num3 = getRandom();
        while (num3 == code || num3 == num1 || num3 == num2)
        {
            num3 = getRandom();
        }
        fourthText.text = num3.ToString();
    }
    void trueFourth()
    {
        num1 = getRandom();
        firstText.text = num1.ToString();
        while (num1 == code)
        {
            num1 = getRandom();
        }
        num2 = getRandom();
        while (num2 == code || num2 == num1)
        {
            num2 = getRandom();
        }
        secondText.text = num2.ToString();
        num3 = getRandom();
        while (num3 == code || num3 == num1 || num3 == num2)
        {
            num3 = getRandom();
        }
        thirdText.text = num3.ToString();
        fourthText.text = code.ToString();
    }
    void lie()
    {
        num1 = getRandom();
        firstText.text = num1.ToString();
        while (num1 == code)
        {
            num1 = getRandom();
        }
        num2 = getRandom();
        while (num2 == code || num2 == num1)
        {
            num2 = getRandom();
        }
        secondText.text = num2.ToString();
        num3 = getRandom();
        while (num3 == code || num3 == num1 || num3 == num2)
        {
            num3 = getRandom();
        }
        thirdText.text = num3.ToString();
        num4 = getRandom();
        while (num4 == code || num4 == num1 || num4 == num2 || num4 == num3)
        {
            num4 = getRandom();
        }
        fourthText.text = num4.ToString();
    }
}
