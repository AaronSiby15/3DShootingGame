using UnityEngine;

public class NPCTracker : MonoBehaviour
{
    public static NPCTracker Instance { get; private set; }
    
    private int talkedToNPCs = 0;
    public int totalNPCs = 3; // Adjust based on the number of NPCs
    public GameObject diamondObject; // Assign the diamond object in Inspector

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (diamondObject != null)
        {
            diamondObject.SetActive(false); // Hide diamond at start
        }
    }

    public void NPCInteracted()
    {
        talkedToNPCs++;

        if (talkedToNPCs >= totalNPCs)
        {
            ActivateDiamond();
        }
    }

    private void ActivateDiamond()
    {
        if (diamondObject != null)
        {
            diamondObject.SetActive(true);
            Debug.Log("All NPCs talked to! Diamond is now visible.");
        }
    }
}

