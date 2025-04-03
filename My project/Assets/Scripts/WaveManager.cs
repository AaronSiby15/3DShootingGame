using System.Collections;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;

    public Transform[] spawnPoints;
    public GameObject zombiePrefab;
    public GameObject lvl1Gem;

    private int[] zombiesPerWave = { 1, 7, 20 };
    private int currentWaveIndex = 0;
    private int zombiesAlive = 0;
    private bool waveInProgress = false;

    private TextMeshProUGUI waveText; 

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GameObject waveTextObj = GameObject.FindGameObjectWithTag("waveText"); 
        if (waveTextObj != null)
        {
            waveText = waveTextObj.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogError("No UI element found with tag 'waveText'"); 
        }

        if (lvl1Gem != null)
        {
            lvl1Gem.SetActive(false);
        }

        StartCoroutine(StartNextWave());
    }

    IEnumerator StartNextWave()
    {
        yield return new WaitForSeconds(2f);

        if (currentWaveIndex < zombiesPerWave.Length)
        {
            int zombieCount = zombiesPerWave[currentWaveIndex];
            UpdateWaveUI(currentWaveIndex + 1);
            currentWaveIndex++;
            zombiesAlive = zombieCount;
            waveInProgress = true;

            for (int i = 0; i < zombieCount; i++)
            {
                SpawnZombie();
                yield return new WaitForSeconds(0.2f);
            }
        }
        else
        {
            waveInProgress = false;
            Debug.Log("All waves complete!");

            if (waveText != null)
            {
                waveText.text = "Forest Zombies Defeated!\nCollect the Forest Gem!";
            }

            if (lvl1Gem != null)
            {
                lvl1Gem.SetActive(true);
                Debug.Log("Lvl1Gem activated!");
            }
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
    }

    public void ZombieDied()
    {
        if (!waveInProgress) return;

        zombiesAlive--;

        if (zombiesAlive <= 0)
        {
            waveInProgress = false;
            StartCoroutine(StartNextWave());
        }
    }

    void UpdateWaveUI(int waveNumber)
    {
        if (waveText != null)
        {
            waveText.text = "Wave: " + waveNumber + "/" + zombiesPerWave.Length;
            Debug.Log("Updated wave text to: Wave " + waveNumber + "/" + zombiesPerWave.Length);
        }
    }
}