using UnityEngine;

public class newDialogue : MonoBehaviour
{
    bool dialogueZone = false;
    int index = 3;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && transform.childCount > 9)
        {
            // Hide all dialogue lines
            for (int i = 2; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }

            // If there are more lines to show, show the next one
            if (index < transform.childCount)
            {
                transform.GetChild(index).gameObject.SetActive(true);
                index++;
            }
            else
            {
                // Optional: End of dialogue - hide canvas
                gameObject.SetActive(false);
                index = 9;
            }
        }
    }
}