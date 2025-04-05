using UnityEngine;
using TMPro;

public class XPManager : MonoBehaviour
{
    
    public static XPManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public int currentXP = 0;
    public int level = 1;
    public int maxXP = 100;

    public TMP_Text xpText;
    public TMP_Text levelText;

    public PlayerHealth playerHealth; // Reference to PlayerHealth script

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
                playerHealth.IncreaseMaxHealth(10); // 🎯 Increase health on level up
            }
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (xpText != null)
        {
            xpText.text = currentXP.ToString();
        }

        if (levelText != null)
        {
            levelText.text = level.ToString();
        }
    }
}