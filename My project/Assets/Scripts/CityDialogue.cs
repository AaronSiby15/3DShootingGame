using UnityEngine;
using TMPro;

public class CityDialogue : MonoBehaviour
{
    bool dialogueZone = false;

    public GameObject d_template; // Dialogue line prefab
    public GameObject canva;      // UI canvas

    void Update()
    {
        if (dialogueZone && Input.GetKeyDown(KeyCode.F))
        {
            canva.SetActive(true);

            // Clear previous dialogue (optional)
            for (int i = 9; i < canva.transform.childCount; i++)
            {
                Destroy(canva.transform.GetChild(i).gameObject);
            }

            
            NewDialogue("");
            NewDialogue("NPC: Thanks so much for coming.");
            NewDialogue("NPC: I tried to fight them off but I was outnumbered.");
            NewDialogue("NPC: I hid the gem from them in the next building over.");
            NewDialogue("NPC: Go get it... it's our only chance.");

     
            canva.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    void NewDialogue(string text)
    {
        GameObject template_clone = Instantiate(d_template, canva.transform);
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
        template_clone.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("mainPlayer"))
        {
            dialogueZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("mainPlayer"))
        {
            dialogueZone = false;
        }
    }
}