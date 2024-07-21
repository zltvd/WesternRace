using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject panel;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(false);
        }
    }
    public void lvlSelect(int next)
    {
        Global.nxtLVL = next;
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);

    }
    public void menuExit()
    {
        Application.Quit();
    }
    public void settingsPanel()
    {
        panel.SetActive(true);
    }
}
