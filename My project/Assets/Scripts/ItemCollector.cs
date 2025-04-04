using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int collectedCount = 0;
    public int totalItemsToCollect = 4;
    public GameObject gunChest;

    private float timeRemaining = 150f;
    private bool timerActive = true;
    private bool hintShown = false;

    private TMP_Text timerText;
    private TMP_Text hintText;
    private TMP_Text itemStatusText;

    void Start()
    {
        GameObject timerObj = GameObject.FindGameObjectWithTag("timer");
        GameObject hintObj = GameObject.FindGameObjectWithTag("hint");
        GameObject itemStatusObj = GameObject.FindGameObjectWithTag("itemStatus");

        if (timerObj != null) timerText = timerObj.GetComponent<TMP_Text>();
        if (hintObj != null) hintText = hintObj.GetComponent<TMP_Text>();
        if (itemStatusObj != null) itemStatusText = itemStatusObj.GetComponent<TMP_Text>();

        UpdateItemStatus();
        UpdateTimerUI();
    }

    void Update()
    {
        if (timerActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();

            if (!hintShown && timeRemaining <= 60f && collectedCount < totalItemsToCollect)
            {
                if (hintText != null)
                    hintText.text = "Hint: The items are hidden in each corner of the map.";
                hintShown = true;
            }

            if (timeRemaining <= 0f)
            {
                timerActive = false;
                timeRemaining = 0f;

                if (hintText != null && collectedCount < totalItemsToCollect)
                    hintText.text = "Time's up!";
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("item") )
        {
            collectedCount++;
            Destroy(other.gameObject);
            UpdateItemStatus();

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

            if (itemStatusText != null)
                itemStatusText.text = "Chest Spawned!\nReturn to the Origin!";

            if (hintText != null)
                hintText.text = ""; // Clear hint
        }
        else
        {
            Debug.LogWarning("Gun chest is not assigned in the inspector.");
        }
    }

    void UpdateItemStatus()
    {
        if (itemStatusText != null && collectedCount < totalItemsToCollect)
            itemStatusText.text = $"Items Collected: {collectedCount}/{totalItemsToCollect}";
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            timerText.text = $"Time Remaining: {minutes:00}:{seconds:00}";
        }
    }
}