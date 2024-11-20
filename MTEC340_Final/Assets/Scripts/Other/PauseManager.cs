using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseManager : MonoBehaviour
{
    [SerializeField] private string pauseSceneName = "PauseMenu"; 

    
    private void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        
        SceneManager.LoadScene(pauseSceneName);
    }
}