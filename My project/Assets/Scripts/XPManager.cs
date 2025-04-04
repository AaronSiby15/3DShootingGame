using UnityEngine;
using TMPro;

public class XPManager : MonoBehaviour
{
    public int currentXP = 0;
    public int level = 1;
    public int maxXP = 100;

    public TMP_Text xpText;
    public TMP_Text levelText;

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