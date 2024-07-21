using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;


public class PauseMenu : MonoBehaviour
{
    public GameObject pause;
    public PostProcessVolume Blur;
    void Start()
    {
        Blur = Camera.main.gameObject.GetComponent<PostProcessVolume>();
        Blur.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            Blur.enabled = true;
            Time.timeScale = 0f;
            pause.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            pause.SetActive(false);
            Blur.enabled = false;
        }
    }
    public void resume()
    {
        Time.timeScale = 1f;
        pause.SetActive(false);
        Blur.enabled = false;
    }
    public void exit()
    {
        UnityEngine.Application.Quit();
        Time.timeScale = 1.0f;
    }
    public void menu(int next)
    {
        Global.nxtLVL = next;
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
}
