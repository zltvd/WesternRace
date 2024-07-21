using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Xml;
using MalbersAnimations;
using UnityEngine.Rendering.PostProcessing;
using MalbersAnimations.Controller;

public delegate void action();
public class DialogueSystem : MonoBehaviour
{
    public GameObject dialogWindow;
    [SerializeField] private MalbersInput onHorse;
    [SerializeField] private MAnimal stopMoveHorse;
    public GameObject answers;
    public TMP_Text message;
    public TMP_Text answer;
    public GameObject npc;

    Dictionary<string, action> actions = new Dictionary<string, action>();
    CDialogue dialogue = new CDialogue();
    public void loadDialog(Object xmlFile)
    {
        dialogue.Clear();
        actions.Clear();
        actions.Add("none", null);
        actions.Add("start race", null);
        actions.Add("dialogue end", dialogEnd);

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlFile.ToString());
        XmlNode messages = xmlDoc.SelectSingleNode("//messages");
        XmlNodeList messageNodes = xmlDoc.SelectNodes("//messages/message");

        foreach (XmlNode messageNode in messageNodes)
        {
            CMessage msg = new CMessage();
            msg.text = messageNode.ChildNodes[0].InnerText;
            msg.msgID = long.Parse(messageNode.Attributes["uid"].Value);
            dialogue.loadMessage(msg);

            foreach (XmlNode answerNode in messageNode.ChildNodes[1].ChildNodes)
            {
                CAnswer answ = new CAnswer();
                answ.answID = long.Parse(answerNode.Attributes["auid"].Value);
                answ.msgID = long.Parse(answerNode.Attributes["muid"].Value);
                answ.action = answerNode.Attributes["action"].Value;
                answ.text = answerNode.InnerText;
                dialogue.loadAnswer(answ);
            }
        }
        showMessage(dialogue.getMessages()[0].msgID, "none");
        dialogWindow.SetActive(true);
        //stopMoveHorse.enabled = false;
        onHorse.enabled = false;
    }
    public void showMessage(long uid, string act)
    {
        actions[act]?.Invoke();
        if (uid == -1) return;
        foreach (Transform child in answers.transform)
        {
            Destroy(child.gameObject);
        }
        message.text = dialogue.selectMessage(uid);

        foreach (CAnswer ans in dialogue.getAnswers())
        {
            TMP_Text txt = Instantiate<TMP_Text>(answer);
            txt.text = ans.text;
            txt.GetComponent<Button>().onClick.AddListener(delegate { showMessage(ans.msgID, ans.action); });
            txt.transform.SetParent(answers.transform);
        }
    }

    public void dialogEnd()
    {
        dialogWindow.SetActive(false);
        onHorse.enabled = true;
    }

    public void setAction(string name, action act)
    {
        actions[name] = act;
    }
}
