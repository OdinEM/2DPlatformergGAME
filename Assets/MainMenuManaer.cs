using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Name of the game scene to load
    public string gameSceneName = "GameScene-ALU";

    // This method will be called when the Play button is clicked
    public void OnPlayButtonClicked()
    {
        // Load the game scene using the variable
        SceneManager.LoadScene(gameSceneName);
    }
}