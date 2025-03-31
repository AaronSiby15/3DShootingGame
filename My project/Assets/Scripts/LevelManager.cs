using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class LevelManager : MonoBehaviour
{
    // Call this method to load the next scene
    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the Player enters the trigger
        {
            LoadNextLevel();
        }
    }

}