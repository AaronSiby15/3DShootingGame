using UnityEngine;

public class destroyOnInteraction : MonoBehaviour
{
    private bool isPlayerNear = false;
    private bool isOpen = false;

    // Update is called once per frame
    void Update()
    {
        if (gameObject != null)
        {
            isOpen = false;
        }
        else
        {
            isOpen = true;
        }
        
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            Destroy(gameObject);
        }
    }
    
    // Trigger when player enters the chest's area
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Ensure this trigger happens only with the player
        {
            isPlayerNear = true;
        }
    }

    // Trigger when player exits the chest's area
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))  // Ensure this happens only when the player leaves
        {
            isPlayerNear = false;
        }
    }
}
