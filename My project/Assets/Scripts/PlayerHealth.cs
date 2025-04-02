using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private TMP_Text healthText;
    

    void Start()
    {
        currentHealth = maxHealth;

        GameObject healthObject = GameObject.FindGameObjectWithTag("healthTag");
        if (healthObject != null)
        {
            healthText = healthObject.GetComponent<TMP_Text>();
        }
        

        UpdateHealthUI();
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
        // Add death logic here (e.g., reload scene, show game over screen)
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
    
    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
        currentHealth += amount; 
        UpdateHealthUI();
    }
    
    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = $"HP: {currentHealth} / {maxHealth}";
        }
    }
}