using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource button;
    public AudioClip click;

    public void ClickSound()
    {
        button.PlayOneShot(click);
    }
}
