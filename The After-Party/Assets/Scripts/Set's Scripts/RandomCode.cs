using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class RandomCode : MonoBehaviour
{
    //int playerCount;
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
    Button[] buttons = new Button[4];
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
    public Texture2D cursor;
    Vector3 rand1, rand2, rand3, rand4;
    RectTransform firstRect, secondRect, thirdRect, fourthRect;
    RectTransform[] rects = new RectTransform[4];
    public AudioClip winSound;
    public AudioClip failSound;
    public AudioClip music;
    public AudioClip drums;
    public AudioClip badClick;
    AudioSource audioZource;
    AudioSource musicPlayer;
    GameObject musicObject;
    bool winSoundPlayed;
    bool failSoundPlayed;

    void Start()
    {
        /*if (PlayerPrefs.HasKey("PlayerCount"))
        {
            playerCount = PlayerPrefs.GetInt("PlayerCount");
        }
        else
        {
            playerCount = 1;
            Vector2 cursorOffset = new Vector2(cursor.width / 2, cursor.height / 2);
            Cursor.SetCursor(cursor, cursorOffset, CursorMode.Auto);
        }*/
        Vector2 cursorOffset = new Vector2(cursor.width / 2, cursor.height / 2);
        Cursor.SetCursor(cursor, cursorOffset, CursorMode.Auto);
        Time.fixedDeltaTime = 1f;
        lives = 3;
        prepare();
        won = false;
        lost = false;
        makeButtonArray();
        firstRect = first.GetComponent<RectTransform>();
        secondRect = second.GetComponent<RectTransform>();
        thirdRect = third.GetComponent<RectTransform>();
        fourthRect = fourth.GetComponent<RectTransform>();
        makeRectArray();
        audioZource = GetComponent<AudioSource>();
        //musicPlayer = musicObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        timer.text = (60-(Time.time-5)).ToString();
        livesNum.text = lives.ToString();
        if(lives == 0)
        {
            lost = true;
        }
    }
    private void FixedUpdate()
    {
        gameTime++;
        if (won)
        {
            if (!winSoundPlayed)
            {
                winSoundPlayed = true;
                //musicPlayer.Stop();
                audioZource.clip = winSound;
                audioZource.Play();
            }
            win();
        }
        else if (lost)
        {
            if (!failSoundPlayed)
            {
                failSoundPlayed = true;
                //musicPlayer.Stop();
                audioZource.clip = failSound;
                audioZource.Play();
            }
            lose();
        }
        else
        {
            if(gameTime == 65)
            {
                lose();
            }
            if(gameTime == 1)
            {
                audioZource.clip = drums;
                audioZource.Play();
                winSoundPlayed = false;
                failSoundPlayed = false;
            }
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
                musicPlayer.clip = music;
                musicPlayer.Play();
            }
            if (playing)
            {
                setButtons();
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
        playAgain.gameObject.SetActive(true);
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
        print("button: " + buttonText.text);
        print(codeText.text);
        if (buttonText.text == codeText.text)
        {
            win();
        }
        else
        {
            lives--;
            audioZource.clip = badClick;
            audioZource.Play();
        }
    }

    public void playAgainClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameTime = gameTime - Time.timeSinceLevelLoad;
    }

    public void shuffleButtons()
    {
        rand1 = new Vector3((float)Random.Range(305, 931), (float)Random.Range(25, 394), 0f);
        rand2 = new Vector3((float)Random.Range(305, 931), (float)Random.Range(25, 394), 0f);
        rand3 = new Vector3((float)Random.Range(305, 931), (float)Random.Range(25, 394), 0f);
        rand4 = new Vector3((float)Random.Range(305, 931), (float)Random.Range(25, 394), 0f);
        first.transform.position = rand1;
        second.transform.position = rand2;
        third.transform.position = rand3;
        fourth.transform.position = rand4;
        reAdjustButtons();
    }

    void makeButtonArray()
    {
        buttons[0] = first;
        //print(first.)
        buttons[1] = second;
        buttons[2] = third;
        buttons[3] = fourth;
    }

    void makeRectArray()
    {
        rects[0] = firstRect;
        rects[1] = secondRect;
        rects[2] = thirdRect;
        rects[3] = fourthRect;
    }

    public void reAdjustButtons()
    {
        bool overlap = false;
        for(int i = 0; i < 3; i++)
        {
            //print("i " + i);
            for(int j = i+1; j < 4; j++)
            {
                //print("j " + j);
                if (rectOverlaps(rects[i], rects[j])){
                    overlap = true;
                    moveButton(buttons[j]);
                    //print(rectOverlaps(rects[i], rects[j]));
                }
                //print("after if");
            }
        }
        print(overlap);
    }

    void moveButton(Button but)
    {
       Vector3 burner = new Vector3((float)Random.Range(305, 931), (float)Random.Range(25, 394), 0f);
       but.transform.position = burner;
       reAdjustButtons();
    }

    bool rectOverlaps(RectTransform rectTrans1, RectTransform rectTrans2)
    {
        print("overlap");
        Rect rect1 = new Rect(rectTrans1.localPosition.x, rectTrans1.localPosition.y, rectTrans1.rect.width, rectTrans1.rect.height);
        Rect rect2 = new Rect(rectTrans2.localPosition.x, rectTrans2.localPosition.y, rectTrans2.rect.width, rectTrans2.rect.height);

        return rect1.Overlaps(rect2);
    }

    private void loadFirst()
    {
        codeText = theCode.GetComponent<Text>();
        code = Random.Range(-100, 100);
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
