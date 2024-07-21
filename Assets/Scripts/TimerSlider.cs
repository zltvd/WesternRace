using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class TimerSlider : MonoBehaviour
{
    public Slider slider;
    public float lfTime = 10f;
    private float gameTime;
    public bool isGo;
    public bool isGameOver;
    public GameObject losePanel;
    public GameObject sliderrr;
    public RaceScript raceScript;
    public GameObject timer;
    public PostProcessVolume Blur;
    public GameObject soundLose;
    private void Start()
    {
        isGameOver = false;
        Blur = Camera.main.gameObject.GetComponent<PostProcessVolume>();
        Blur.enabled = false;
    }
    void Update()
    {
        if (isGo == true)
        {
            slider.value = lfTime;
            gameTime += 1 * Time.deltaTime;
            if (gameTime >= 1)
            {
                lfTime -= 1;
                gameTime = 0;
            }
            if (lfTime <= 0)
            {
                losePanel.SetActive(true);
                soundLose.SetActive(true);
                Blur.enabled = true;
                timer.SetActive(false);
                Time.timeScale = 0f;
                sliderrr.SetActive(false);
                raceScript.delta = 0;
                raceScript.currentTime = 3f;
            }
        }
        else if (isGo == false)
        {
            lfTime = 10f;
        }
    }
    public void isLose()
    {
        lfTime = 10f;
        Time.timeScale = 1f;
        losePanel.SetActive(false);
        soundLose.SetActive(false);
        Blur.enabled = false;
        raceScript.isTimerActive = false;
        raceScript.min = 0;
        raceScript.sec = 0;
        isGo = false;
        raceScript.hideallFlags();
    }
}
