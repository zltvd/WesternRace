using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class ShowFlag : MonoBehaviour
{
    public GameObject[] flags;
    public void showFlags()
    {
        for (int i = 0; i < flags.Length; i++)
        {
            flags[i].SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        showFlags();
    }
}
