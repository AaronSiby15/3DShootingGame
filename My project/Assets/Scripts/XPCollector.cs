using UnityEngine;

public class XPCollector : MonoBehaviour
{
    public XPManager xpManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("xpGem"))
        {
            if (xpManager != null)
            {
                xpManager.AddXP(10);
            }

            Destroy(other.gameObject);
        }
    }
}