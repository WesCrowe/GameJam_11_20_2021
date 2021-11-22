using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public string[] levels;
    public int selected_idx;
    public string selected_level;
    public Slider playerCountSlider;

    public void sliderUpdated()
    {
        setPlayerCount((int)playerCountSlider.value);
    }
    public void setPlayerCount(int count)
    {
        PlayerPrefs.SetInt("PlayerCount", count);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(selected_level);
    }
    public void SelectLevel(int idx)
    {
        selected_idx = idx;
        selected_level = levels[selected_idx];
        if (PlayerPrefs.HasKey("PlayerCount"))
        {
            playerCountSlider.value = PlayerPrefs.GetInt("PlayerCount");
        }
        else
        {
            PlayerPrefs.SetInt("PlayerCount", 1);
            playerCountSlider.value = PlayerPrefs.GetInt("PlayerCount");
        }
    }
}
