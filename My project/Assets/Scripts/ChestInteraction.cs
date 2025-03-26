using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public GameObject openChestPrefab;  // The prefab for the open chest
    public GameObject gemPrefab;        // The gem prefab that will appear
    public Transform gemSpawnPoint;     // Where the gem will spawn on the ground
    private bool isOpen = false;
    private bool isPlayerNear = false;  // To track if the player is near the chest

    void Update()
    {
        // Check for interaction (e.g., pressing the E key) only when the player is near
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        isOpen = true;

        // Replace the closed chest with the open chest
        if (openChestPrefab != null)
        {
            

            // Disable the current chest (closed version)
            gameObject.SetActive(false);
            
            // Instantiate the open chest at the same position and rotation as the original chest
            Instantiate(openChestPrefab, transform.position, transform.rotation);
        }

        // Make the gem appear at the specified location
        if (gemPrefab != null && gemSpawnPoint != null)
        {
            // Ensure the gem is active and visible now
            gemPrefab.SetActive(true);

            // Position the gem at the spawn point
            gemPrefab.transform.position = gemSpawnPoint.position;
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