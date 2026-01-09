using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public float textSpeed = 0.05f; // скорость "печати" текста
    public float displayTime = 2f;  // время показа после полной строки

    private Queue<string> messages = new Queue<string>();
    private bool isShowing = false;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    // Добавить сообщение в очередь
    public void ShowMessage(string message)
    {
        messages.Enqueue(message);

        if (!isShowing)
            StartCoroutine(ProcessQueue());
    }

    private IEnumerator ProcessQueue()
    {
        isShowing = true;
        while (messages.Count > 0)
        {
            string msg = messages.Dequeue();
            dialoguePanel.SetActive(true);
            yield return StartCoroutine(TypeText(msg));
            yield return new WaitForSeconds(displayTime);
            dialoguePanel.SetActive(false);
        }
        isShowing = false;
    }

    private IEnumerator TypeText(string msg)
    {
        dialogueText.text = "";
        foreach (char c in msg)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    
}
