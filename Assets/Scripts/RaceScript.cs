using MalbersAnimations;
using MalbersAnimations.Controller;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class RaceScript : MonoBehaviour
{
    public GameObject lvlPanel;
    public GameObject level2flags;
    public int whichRace;
    public GameObject horse;
    public float currentTime = 0f;
    float startTime = 3f;
    public GameObject timer;
    public TMP_Text timerText;
    [SerializeField] private MAnimal stopMoveHorse;
    [SerializeField] private MalbersInput onHorse;
    public bool isTimerActive = false;
    public GameObject[] flags;
    public GameObject[] flags2;
    public GameObject[] flags3;
    public int aaa;
    public int sec = 0;
    public int min = 0;
    public TMP_Text _TimerText;
    public TMP_Text _TimerText2;
    public GameObject _Timer;
    public GameObject _Timer2;
    [SerializeField] public int delta = 0;
    public TimerSlider TimerSlider;
    public GameObject slider;
    public GameObject losePanel;
    public PostProcessVolume Blur;

    void Start()
    {
        currentTime = startTime;
        StartCoroutine(Timer());
        _Timer2.SetActive(false);
        timer.SetActive(false);
        Blur = Camera.main.gameObject.GetComponent<PostProcessVolume>();
        Blur.enabled = false;

    }
    public void LoadRaceLvl1()
    {
        onHorse.enabled = true;
        lvlPanel.SetActive(false);
        horse.transform.position = new Vector3(38.3f, -0.02f, 0.41f);
        horse.transform.eulerAngles = new Vector3(-0.3f, -91f, 0f);
        Time.timeScale = 1f;
        stopMoveHorse.enabled = false;
        timer.SetActive(true);
        isTimerActive = true;
        aaa = 2;
        whichRace = 1;
        Blur.enabled = false;
    }
    public void LoadRaceLvl2()
    {
        onHorse.enabled = true;
        lvlPanel.SetActive(false);
        horse.transform.position = new Vector3(38.3f, -0.02f, 0.41f);
        horse.transform.eulerAngles = new Vector3(-0.3f, -91f, 0f);
        Time.timeScale = 1f;
        stopMoveHorse.enabled = false;
        timer.SetActive(true);
        isTimerActive = true;
        aaa = 3;
        level2flags.SetActive(true);
        whichRace = 2;
        Blur.enabled = false;
    }
    public void LoadRaceLvl3()
    {
        onHorse.enabled = true;
        lvlPanel.SetActive(false);
        horse.transform.position = new Vector3(38.3f, -0.02f, 0.41f);
        horse.transform.eulerAngles = new Vector3(-0.3f, -91f, 0f);
        Time.timeScale = 1f;
        stopMoveHorse.enabled = false;
        timer.SetActive(true);
        isTimerActive = true;
        aaa = 3;
        whichRace = 3;
        Blur.enabled = false;
    }
    IEnumerator Timer()
    {
        
        while(true)
        {
            if (sec == 59)
            {
                min++;
                sec = -1;
            }
            sec += delta;
            _TimerText.text = min.ToString("D2") + " : " + sec.ToString("D2");
            _TimerText2.text = min.ToString("D2") + " : " + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }
    public void showFlags1()
    {
        for (int i = 0; i < 3; i++)
        {
            flags[i].SetActive(true);
        }
    }
    public void showFlags2()
    {
        for (int i = 0; i < 3; i++)
        {
            flags2[i].SetActive(true);
        }
    }
    public void showFlags3()
    {
        for (int i = 0; i < 4; i++)
        {
            flags3[i].SetActive(true);
        }
    }
    public void hideallFlags()
    {
        for (int i = 0; i < flags.Length; i++)
        {
            flags[i].SetActive(false);
        }
        for (int i = 0; i < flags2.Length; i++)
        {
            flags2[i].SetActive(false);
        }
        for (int i = 0; i < flags3.Length; i++)
        {
            flags3[i].SetActive(false);
        }
    }
    void Update()
    {
        if (isTimerActive == true)
        {
            
            currentTime -= 1 * Time.deltaTime;
            timerText.text = currentTime.ToString("0");
            if (currentTime <= 0)
            {
                currentTime = 0;
                timer.SetActive(false);
                stopMoveHorse.enabled = true;
                isTimerActive = false;
                _Timer.SetActive(true);
                delta = 1;
                slider.SetActive(true);
                TimerSlider.isGo = true;
                if (whichRace == 1)
                    showFlags1();
                if (whichRace == 2)
                    showFlags2();
                if (whichRace == 3)
                    showFlags3();
            }
        }

        

    }
    
}
