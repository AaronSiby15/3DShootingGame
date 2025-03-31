using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int collectedCount = 0;
    public int totalItemsToCollect = 4;

    public GameObject gunChest; // Assign your chest GameObject here

    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is one of the collectible items
        if (other.CompareTag("GunPowder") || 
            other.CompareTag("MetalPile") || 
            other.CompareTag("Energy") || 
            other.CompareTag("Tool"))
       
        {
            collectedCount++;
            Destroy(other.gameObject); // Despawn the object

            Debug.Log($"Collected {collectedCount}/{totalItemsToCollect}");

            if (collectedCount >= totalItemsToCollect)
            {
                ActivateGunChest();
            }
        }
    }

    void ActivateGunChest()
    {
        if (gunChest != null)
        {
            gunChest.SetActive(true); 
            Debug.Log("All items collected! Gun chest is now active.");
        }
        else
        {
            Debug.LogWarning("Gun chest is not assigned in the inspector.");
        }
    }
}