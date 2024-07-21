using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideFlags : MonoBehaviour
{
    public TimerSlider TimerSlider;
    public GameObject soundFlags;
    private void OnTriggerEnter(Collider other)
    {
        soundFlags.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        gameObject.SetActive(false);
        TimerSlider.lfTime = 10f;
        soundFlags.SetActive(true);
    }
}
