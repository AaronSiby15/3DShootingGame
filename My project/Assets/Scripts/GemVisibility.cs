using UnityEngine;

public class GemVisibility : MonoBehaviour
{
    public XPManager xpManager;
    private bool hasBeenShown = false;

    void Update()
    {
        if (!hasBeenShown && xpManager != null && xpManager.currentXP >= 95)
        {
            gameObject.SetActive(true);
            hasBeenShown = true; 
        }
    }
}
