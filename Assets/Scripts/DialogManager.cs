using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DialogManager : MonoBehaviour
{
    public Text dialogText;

    private Queue<string> sentences;

    // Start is called before the first frame update
    /*
    void Start()
    {
        //sentences = new Queue<string>();
        Debug.Log("DM init");
    }*/

    public void StartDialog(List<string> dialog)
    {
        //sentences.Clear();
        sentences = new Queue<string>();

        foreach (string sentence in dialog)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentences();
    } 

    public void DisplayNextSentences()
    {
        if (sentences.Count == 0)
        {
            //EndDialog();
            GameObject.FindGameObjectsWithTag("GameController")[0].SendMessage("EndDialog");
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }
    /*
    public void EndDialog()
    {
        GameObject.FindGameObjectsWithTag("GameController")[0].SendMessage("ShowDialogWindow");
    }
    */
}
