using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
public class FinishFlag : MonoBehaviour
{
    public GameObject finishPanel;
    public GameObject finishButton;
    public RaceScript raceScript;
    public TMP_Text _TimerText;
    public bool isFinish = false;
    public TMP_Text BestTime;
    public TMP_Text SliderBestTime;
    public GameObject nextSliderText;
    public int bestMin = 0;
    public int bestSec = 0;
    public int curreeeent = 1;
    public int currentLVL;
    public int nextlvlrace;
    public LevelSelections LevelSelections;
    public GameObject slider;
    public TimerSlider TimerSlider;
    public GameObject SLIDER;
    public PostProcessVolume Blur;
    public GameObject soundFinish;
    private void Start()
    {
        Blur = Camera.main.gameObject.GetComponent<PostProcessVolume>();
        Blur.enabled = false;
    }
    private void OnTriggerExit(Collider other)
    {
        nextSliderText.SetActive(true);
        if (bestMin == 0 && bestSec == 0)
        {
            bestMin = raceScript.min;
            bestSec = raceScript.sec;
        }
        isBest();
        BestTime.text = bestMin.ToString("D2") + " : " + bestSec.ToString("D2");
        SliderBestTime.text = bestMin.ToString("D2") + " : " + bestSec.ToString("D2");
        raceScript.delta = 0;
        raceScript._Timer.SetActive(false);
        raceScript.currentTime = 3f;
        Blur.enabled = true;
        finishPanel.SetActive(true);
        finishButton.SetActive(true);
        soundFinish.SetActive(true);
        Time.timeScale = 0f;
        raceScript.isTimerActive = false;
        curreeeent = 3;
        LevelSelections.level = 3;
        slider.SetActive(false);
        TimerSlider.isGo = false;
    }
    public void buttonFinish()
    {
        finishPanel.SetActive(false);
        finishButton.SetActive(false);
        Time.timeScale = 1f;
        raceScript.isTimerActive = false;
        raceScript.min = 0;
        raceScript.sec = 0;
        isFinish = true;
        LevelSelections.level = 2;
        curreeeent = 2;
        LevelSelections.buttons[1].GetComponent<Button>().interactable = true;
        Blur.enabled = false;
        soundFinish.SetActive(false);
    }
    public void buttonFinish2()
    {
        finishPanel.SetActive(false);
        finishButton.SetActive(false);
        Time.timeScale = 1f;
        raceScript.isTimerActive = false;
        raceScript.min = 0;
        raceScript.sec = 0;
        isFinish = true;
        LevelSelections.level = 3;
        curreeeent = 3;
        LevelSelections.buttons[2].GetComponent<Button>().interactable = true;
        Blur.enabled = false;
        soundFinish.SetActive(false);
    }
    public void buttonFinish3()
    {
        finishPanel.SetActive(false);
        finishButton.SetActive(false);
        Time.timeScale = 1f;
        raceScript.isTimerActive = false;
        raceScript.min = 0;
        raceScript.sec = 0;
        isFinish = true;
        LevelSelections.level = 3;
        curreeeent = 3;
        LevelSelections.buttons[2].GetComponent<Button>().interactable = true;
        Blur.enabled = false;
        soundFinish.SetActive(false);
    }
    public void isBest()
    {
        if (raceScript.min <= bestMin)
        {
            if (raceScript.sec <= bestSec)
            {
                bestMin = raceScript.min;
                bestSec = raceScript.sec;
            }
        }
    }
}
