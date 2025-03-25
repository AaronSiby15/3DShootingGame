using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    bool dialogueZone = false;

    public GameObject d_template; // The dialogue line prefab (should be disabled in prefab)
    public GameObject canva;      // The UI canvas where lines appear

    void Update()
    {
        if (dialogueZone && Input.GetKeyDown(KeyCode.F))
        {
            canva.SetActive(true);

            // Clear old dialogue (optional)
            for (int i = 9; i < canva.transform.childCount; i++)
            {
                Destroy(canva.transform.GetChild(i).gameObject);
            }

            // Add new dialogue lines
            NewDialogue(""); // Empty (for spacing or delay)
            NewDialogue("Player: Where Am I?");
            NewDialogue("NPC: You have been in a coma for a long time.");
            NewDialogue("NPC: Our world has been taken over by Zombies.");
            NewDialogue("NPC: You are our only hope to save the human race.");
            NewDialogue("NPC: You must collect the 4 lost gems.");
            NewDialogue("Player: How will gems save the human race?");
            NewDialogue("NPC: Once you have collected the gems, you will unlock the key to face the zombie king.");
            NewDialogue("NPC: Once the zombie king is defeated, the rest of the zombies will fall.");
            NewDialogue("NPC: Good luck on your journey, Player!");
            // Show the first dialogue line
            canva.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    void NewDialogue(string text)
    {
        GameObject template_clone = Instantiate(d_template, canva.transform);
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
        template_clone.SetActive(false); // Hide by default
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Use tag "Player" on your player GameObject
        {
            dialogueZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueZone = false;
        }
    }
}