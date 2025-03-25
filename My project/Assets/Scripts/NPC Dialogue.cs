using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    bool dialogueZone = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueZone && Input.GetKeyDown(KeyCode.F)){

            print("Dialogue Started");

        }
        
    }

    public void OnTriggerEnter(Collider other){

        if (other.CompareTag("mainPlayer"))
        {

            dialogueZone = true;

        }



    }

    private void OnTriggerExit(Collider other)
    {

        dialogueZone = false;

    }
}
