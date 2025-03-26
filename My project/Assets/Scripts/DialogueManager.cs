using UnityEngine;
using TMPro;
using System.Collections.Generic;

public abstract class DialogueManager : MonoBehaviour
{
    protected bool dialogueZone = false;
    public GameObject d_template; 
    public GameObject canva;      

    private List<GameObject> dialogueLines = new List<GameObject>();
    private int currentIndex = 0;
    private bool dialogueStarted = false;

    protected virtual void Update()
    {
        if (dialogueZone && Input.GetKeyDown(KeyCode.F) && !dialogueStarted)
        {
            dialogueStarted = true;
            StartDialogue();
        }

        if (dialogueStarted && Input.GetKeyDown(KeyCode.Return))
        {
            AdvanceDialogue();
        }
    }

    void StartDialogue()
    {
        canva.SetActive(true);
        ClearOldDialogue();

        string[] lines = GetDialogueLines();

        foreach (string line in lines)
        {
            AddDialogueLine(line);
        }

        currentIndex = 0;
        ToggleLine(currentIndex, true); 
    }

    void AdvanceDialogue()
    {
        
        if (currentIndex < dialogueLines.Count)
        {
            ToggleLine(currentIndex, false);
        }

        currentIndex++;

        
        if (currentIndex < dialogueLines.Count)
        {
            ToggleLine(currentIndex, true);
        }
        else
        {
            EndDialogue();
        }
    }

    void ToggleLine(int index, bool active)
    {
        if (index >= 0 && index < dialogueLines.Count)
        {
            dialogueLines[index].SetActive(active);
        }
    }

    void ClearOldDialogue()
    {
        foreach (var line in dialogueLines)
        {
            Destroy(line);
        }
        dialogueLines.Clear();
    }

    void AddDialogueLine(string text)
    {
        GameObject line = Instantiate(d_template, canva.transform);
        line.transform.Find("Textbox").GetComponent<TextMeshProUGUI>().text = text;
        line.SetActive(false);
        dialogueLines.Add(line);
    }

    void EndDialogue()
    {
        canva.SetActive(false);
        currentIndex = 0;
        dialogueStarted = false;
    }

    protected abstract string[] GetDialogueLines();

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("mainPlayer"))
        {
            dialogueZone = true;
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("mainPlayer"))
        {
            dialogueZone = false;
        }
    }
}
