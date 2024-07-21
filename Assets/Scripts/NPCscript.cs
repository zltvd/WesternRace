using MalbersAnimations;
using MalbersAnimations.Controller;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class NPCscript : MonoBehaviour
{
    public Object dialogue;
    public GameObject dialogueSystem;
    public GameObject dialoguePanel;
    public GameObject levelPanel;
    public PostProcessVolume Blur;
    [SerializeField] private MalbersInput onHorse;
    [SerializeField] private MAnimal stopMoveHorse;
    private void Start()
    {
        Blur = Camera.main.gameObject.GetComponent<PostProcessVolume>();
        Blur.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            dialoguePanel.SetActive(false);
            levelPanel.SetActive(false);
            Blur.enabled = false;
            Time.timeScale = 1f;
            stopMoveHorse.enabled = true;
            onHorse.enabled = true;
        }
    }
    public void interact()
    {
        dialogueSystem.GetComponent<DialogueSystem>().loadDialog(dialogue);
        dialogueSystem.GetComponent<DialogueSystem>().setAction("start race", startRace);
    }

    public void startRace()
    {
        dialoguePanel.SetActive(false);
        levelPanel.SetActive(true);
        Blur.enabled = true;
        Time.timeScale = 0f;
        onHorse.enabled = true;
    }
}
