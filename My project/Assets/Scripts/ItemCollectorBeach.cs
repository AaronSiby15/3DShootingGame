using UnityEngine;

public class ItemCollectorBeach : MonoBehaviour
{
    private int collectedCount = 0;
    public int totalItemsToCollect = 2;
    
    public GameObject boat, NPC, Farboat; // Assign your boat GameObject here
    public Collider targetArea; // The specific target area where the player needs to step

    private bool canActivateBoat = false; // To control when the boat can be activated

    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is one of the collectible items
        if (other.CompareTag("item"))
        {
            collectedCount++;
            Destroy(other.gameObject); // Despawn the item

            Debug.Log($"Collected {collectedCount}/{totalItemsToCollect}");

            if (collectedCount >= totalItemsToCollect)
            {
                // After collecting all items, enable boat activation when player enters the target area
                Debug.Log("All items collected! Now step on the target area to activate the boat.");
            }
        }

        // Check if the player stepped into the target area and has collected all items
        if (collectedCount >= totalItemsToCollect)
        {
            // Make sure the player is inside the target area before activating the boat
            if (targetArea != null && targetArea.bounds.Contains(other.transform.position))
            {
                ActivateBoat();
            }
        }
    }

    void ActivateBoat()
    {
        if (boat != null)
        {
            boat.SetActive(true); // Activate the boat
            NPC.SetActive(true);
            Farboat.SetActive(false);
            Debug.Log("All items collected and player stepped into the target area! Boat is now active.");
        }
        else
        {
            Debug.LogWarning("Boat is not assigned in the inspector.");
        }
    }
}