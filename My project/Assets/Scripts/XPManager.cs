using UnityEngine;
using TMPro;

public class XPManager : MonoBehaviour
{
    public int currentXP = 0;
    public int level = 1;
    public int maxXP = 100;

    public TMP_Text xpText;
    public TMP_Text levelText;
    
    public PlayerHealth playerHealth;

    private void Start()
    {
        UpdateUI();
    }

    public void AddXP(int amount)
    {
        currentXP += amount;

        if (currentXP >= maxXP)
        {
            currentXP -= maxXP;
            level++;

            if (playerHealth != null)
            {
                playerHealth.IncreaseMaxHealth(10); 
            }
        }

        UpdateUI();
    }

private void UpdateUI()
{
    if (xpText != null)
    {
        xpText.text = currentXP + "";
    }

    if (levelText != null)
    {
        levelText.text = level.ToString();
    }
}
}