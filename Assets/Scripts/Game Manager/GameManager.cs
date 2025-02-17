using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance

    public int lives = 3; // Player lives
    public Transform respawnPoint; // Respawn point near the water
    public GameObject playerPrefab; // Player prefab to respawn
    public string endSceneName = "EndScene"; // Name of the end scene

    private GameObject currentPlayer; // Reference to the current player instance

    void Awake()
    {
        // Singleton pattern to ensure only one GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scene loads
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SpawnPlayer(); // Spawn the player at the start of the game
    }

    // Spawn the player at the respawn point
    void SpawnPlayer()
    {
        if (playerPrefab != null && respawnPoint != null)
        {
            currentPlayer = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("PlayerPrefab or RespawnPoint not assigned in GameManager!");
        }
    }

    // Handle player death
    public void PlayerDied()
    {
        lives--; // Decrease lives

        if (lives > 0)
        {
            RespawnPlayer(); // Respawn the player if lives remain
        }
        else
        {
            GameOver(); // End the game if no lives remain
        }
    }

    // Respawn the player near the water
    void RespawnPlayer()
    {
        if (currentPlayer != null)
        {
            Destroy(currentPlayer); // Destroy the current player instance
        }
        SpawnPlayer(); // Spawn a new player
    }

    // End the game and load the end scene
    void GameOver()
    {
        SceneManager.LoadScene(endSceneName); // Load the end scene
    }

    // Restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit(); // Quit the application
    }
}