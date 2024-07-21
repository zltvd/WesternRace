using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelections : MonoBehaviour
{
    public Image[] buttons;
    public FinishFlag FinishFlag;
    public FinishFlag FinishFlag2;
    public FinishFlag FinishFlag3;
    public int level = 1;
    private void Update()
    {

        int curLVL = PlayerPrefs.GetInt("curLVL", level);
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i + 1 > curLVL)
                buttons[i].GetComponent<Button>().interactable = false;
        }
        if (FinishFlag.curreeeent == 2)
        {
            level = 2;
            PlayerPrefs.GetInt("curLVL", 2);
        }
        if (FinishFlag2.curreeeent == 3)
        {
            level = 3;
            PlayerPrefs.GetInt("curLVL", 3);
        }
        if (FinishFlag3.curreeeent == 3)
        {
            level = 3;
            PlayerPrefs.GetInt("curLVL", 3);
        }

        if (Input.GetKeyUp(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}

