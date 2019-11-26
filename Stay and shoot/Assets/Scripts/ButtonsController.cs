using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ButtonsController : MonoBehaviour
{
    public static event Action OnGameStart;
    [SerializeField] private GameObject[] soundImages;
    [SerializeField] private GameObject[] vibroImages;
    public static bool onUI = false;
    public static bool isStarted = true;
    SceneFader sceneFader;
    private void Awake()
    {
        Application.targetFrameRate = 120;

        #region Sound&VibroStartSettings
        if (!PlayerPrefs.HasKey("Sound"))
        {
            PlayerPrefs.SetInt("Sound",0);
        }
        if (!PlayerPrefs.HasKey("Vibro"))
        {
            PlayerPrefs.SetInt("Vibro", 0);
        }

        if (PlayerPrefs.GetInt("Sound")==0)
        {
            soundImages[1].SetActive(false);
            soundImages[0].SetActive(true);
        }
        else
        {
            soundImages[1].SetActive(true);
            soundImages[0].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Vibro") == 0)
        {
            vibroImages[1].SetActive(false);
            vibroImages[0].SetActive(true);
        }
        else
        {
            vibroImages[1].SetActive(true);
            vibroImages[0].SetActive(false);
        }
        sceneFader = GetComponent<SceneFader>();
        #endregion
    }
    public void Restart()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().buildIndex);
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Sound()
    {
        if (PlayerPrefs.GetInt("Sound")==0)
        {
            PlayerPrefs.SetInt("Sound",1);
            soundImages[1].SetActive(true);
            soundImages[0].SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
            soundImages[0].SetActive(true);
            soundImages[1].SetActive(false);
        }
    }
    public void OnPanelHold()
    {
        OnGameStart.Invoke();
        isStarted = true;
    }
    public void VibrationSet()
    {
        if (PlayerPrefs.GetInt("Vibro") == 0)
        {
            PlayerPrefs.SetInt("Vibro", 1);
            vibroImages[1].SetActive(true);
            vibroImages[0].SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("Vibro", 0);
            vibroImages[0].SetActive(true);
            vibroImages[1].SetActive(false);
        }
    }
    public void OnUIDown()
    {
        onUI = true;
    }
    public void OnUIUp()
    {
        onUI = false;
    }
}
