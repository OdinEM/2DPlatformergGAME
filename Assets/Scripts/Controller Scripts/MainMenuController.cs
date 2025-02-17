using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Start button has been clicked"); 
        SceneManager.LoadScene("Gameplay"); 
    }

    public void BackToMainMenu()
    {
        Debug.Log("Close Button has been clicked");
        SceneManager.LoadScene("Main Menu");
    }

    public void Replay()
    {
        Debug.Log("Replay Button has been clicked");
        SceneManager.LoadScene("Gameplay");
    }

  
    public void Settings()
    {
        Debug.Log("Settings Button has been clicked");
        SceneManager.LoadScene("Settings");
    }


    // public void EndScene()
    // {
    //     Debug.Log("Player has died and the endscene is active"); 
    //     SceneManager.LoadScene(""); 
    // }

    public void EndGame()
    {
        Debug.Log("Player has quit the GAME"); 
        Application.Quit();
    }
}
