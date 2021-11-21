using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCode : MonoBehaviour
{
    public GameObject theCode;
    public GameObject memorize;
    public GameObject getReady;
    Text codeText;
    int code;
    int num1;
    int num2;
    int num3;
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

    void Start()
    {
        Time.fixedDeltaTime = 1;
        prepare();
    }
    private void FixedUpdate()
    {
        if (Time.time == 3)
        {
            getReady.SetActive(false);
            loadFirst();
            lives = 3;
        }
        if(Time.time == 5)
        {
            theCode.SetActive(false);
            memorize.SetActive(false);
            playing = true;
        }
        if (playing)
        {
            setButtons();
        }
        
    }

    void prepare()
    {
        theCode.SetActive(false);
        memorize.gameObject.SetActive(false);
        first.gameObject.SetActive(false);
        second.gameObject.SetActive(false);
        third.gameObject.SetActive(false);
        fourth.gameObject.SetActive(false);
    }

    public void tryWin(Text buttonText)
    {
        if(buttonText = codeText)
        {
            print("you win!");
        }
        else
        {
            lives--;
            print(lives);
        }
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
        int pickRand = Random.Range(1, 4);
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
        //Might make a case where Set lies
    }

    void trueFirst()
    {
        firstText.text = code.ToString();
        num1 = Random.Range(-10, 10);
        while(num1 == code)
        {
            num1 = Random.Range(-10, 10);
        }
        secondText.text = num1.ToString();
        num2 = Random.Range(-10, 10);
        while (num2 == code || num2 == num1)
        {
            num2 = Random.Range(-10, 10);
        }
        thirdText.text = num2.ToString();
        num3 = Random.Range(-10, 10);
        while (num3 == code || num3 == num1 || num3 == num2)
        {
            num3 = Random.Range(-10, 10);
        }
        fourthText.text = num3.ToString();
    }

    void trueSecond()
    {
        num1 = Random.Range(-10, 10);
        firstText.text = num1.ToString();
        while (num1 == code)
        {
            num1 = Random.Range(-10, 10);
        }
        secondText.text = code.ToString();
        num2 = Random.Range(-10, 10);
        while (num2 == code || num2 == num1)
        {
            num2 = Random.Range(-10, 10);
        }
        thirdText.text = num2.ToString();
        num3 = Random.Range(-10, 10);
        while (num3 == code || num3 == num1 || num3 == num2)
        {
            num3 = Random.Range(-10, 10);
        }
        fourthText.text = num3.ToString();
    }
    void trueThird()
    {
        num1 = Random.Range(-10, 10);
        firstText.text = num1.ToString();
        while (num1 == code)
        {
            num1 = Random.Range(-10, 10);
        }
        num2 = Random.Range(-10, 10);
        while (num2 == code || num2 == num1)
        {
            num2 = Random.Range(-10, 10);
        }
        secondText.text = num2.ToString();
        thirdText.text = code.ToString();
        num3 = Random.Range(-10, 10);
        while (num3 == code || num3 == num1 || num3 == num2)
        {
            num3 = Random.Range(-10, 10);
        }
        fourthText.text = num3.ToString();
    }
    void trueFourth()
    {
        num1 = Random.Range(-10, 10);
        firstText.text = num1.ToString();
        while (num1 == code)
        {
            num1 = Random.Range(-10, 10);
        }
        num2 = Random.Range(-10, 10);
        while (num2 == code || num2 == num1)
        {
            num2 = Random.Range(-10, 10);
        }
        secondText.text = num2.ToString();
        num3 = Random.Range(-10, 10);
        while (num3 == code || num3 == num1 || num3 == num2)
        {
            num3 = Random.Range(-10, 10);
        }
        thirdText.text = num3.ToString();
        fourthText.text = code.ToString();
    }
}
