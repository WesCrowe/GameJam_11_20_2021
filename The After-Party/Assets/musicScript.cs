using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicScript : MonoBehaviour
{
    AudioSource musicPlayer;
    GameObject musicObject;
    public AudioClip music;
    bool playingGame;
    bool musicPlaying;
    public GameObject timer;
    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = musicObject.GetComponent<AudioSource>();
        musicPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        //musicPlaying = musicPlayer.isPlaying;
        //print(timer.activeInHierarchy);
        if (timer.activeInHierarchy && !musicPlaying )
        {
            musicPlaying = true;
            musicPlayer.clip = music;
            musicPlayer.Play();
        }
        else
        {
            //musicPlayer.Stop();
            musicPlaying = false;
        }
    }
}
