using System.Collections;
using UnityEngine;
using TMPro; // ✅ Use TextMeshProUGUI instead of legacy UI.Text

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;

    public Transform[] spawnPoints;
    public GameObject zombiePrefab;

    private int[] zombiesPerWave = { 1, 7, 20 };
    private int currentWaveIndex = 0;
    private int zombiesAlive = 0;

    private TextMeshProUGUI waveText; 
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GameObject waveTextObj = GameObject.FindGameObjectWithTag("currentWave");
        if (waveTextObj != null)
        {
            waveText = waveTextObj.GetComponent<TextMeshProUGUI>(); 
        }
        else
        {
            Debug.LogError("No UI element found with tag 'currentWave'");
        }

        StartCoroutine(StartNextWave());
    }

    IEnumerator StartNextWave()
    {
        yield return new WaitForSeconds(2f); // Short delay before wave starts

        if (currentWaveIndex < zombiesPerWave.Length)
        {
            int zombieCount = zombiesPerWave[currentWaveIndex];
            UpdateWaveUI(currentWaveIndex + 1);

            for (int i = 0; i < zombieCount; i++)
            {
                SpawnZombie();
                yield return new WaitForSeconds(0.2f); 
            }
        }
        else
        {
            Debug.Log("All waves complete!");
        }
    }

    void SpawnZombie()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points assigned in WaveManager.");
            return;
        }

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(zombiePrefab, spawnPoint.position, Quaternion.identity);
        zombiesAlive++;
    }

    public void ZombieDied()
    {
        zombiesAlive--;

        if (zombiesAlive <= 0)
        {
            currentWaveIndex++;
            StartCoroutine(StartNextWave());
        }
    }

    void UpdateWaveUI(int waveNumber)
    {
        if (waveText != null)
        {
            waveText.text = waveNumber.ToString(); 
            Debug.Log("Updated wave number to: " + waveNumber);
        }
    }
}