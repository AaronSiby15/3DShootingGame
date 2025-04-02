using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damageAmount = 50;  // The amount of health to deduct
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Check if the object entering the trigger is the player
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();  // Get the PlayerHealth component from the player
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);  // Call TakeDamage to reduce the health
            }
        }
    }
}