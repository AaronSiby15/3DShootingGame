using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private TMP_Text healthText;

    void Start()
    {
        currentHealth = maxHealth; // Set health to max at the start
        
        GameObject healthObject = GameObject.FindGameObjectWithTag("healthTag");
        if (healthObject != null)
        {
            healthText = healthObject.GetComponent<TMP_Text>();
            UpdateHealthUI();
        }
        else
        {
            Debug.LogWarning("No TextMeshPro object with tag 'healthTag' found!");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        Debug.Log("Player Health: " + currentHealth);
        
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        Debug.Log("Player healed: " + currentHealth);
        
        UpdateHealthUI();
    }
    
    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth.ToString();
        }
    }
}