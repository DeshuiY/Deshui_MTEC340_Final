using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start Game: Loads the main game scene
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame"); 
    }

    // Open Settings: Loads the settings scene
    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings"); 
    }
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }

    // Exit Game: Closes the application
    public void ExitGame()
    {
        Debug.Log("Game exited."); 
        Application.Quit(); 
    }
}