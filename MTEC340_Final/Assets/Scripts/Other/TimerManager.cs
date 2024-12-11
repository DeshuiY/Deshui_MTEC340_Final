using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public float timeLimit = 60f; 
    private float timer;

    public string failureSceneName = "FailureScene"; 

    void Start()
    {
        timer = timeLimit; 
    }

    void Update()
    {
        timer -= Time.deltaTime; 

        if (timer <= 0f)
        {
            LoadFailureScene(); 
        }
    }

    void LoadFailureScene()
    {
        SceneManager.LoadScene(failureSceneName);
    }

    public float GetRemainingTime()
    {
        return Mathf.Max(0, timer); 
    }
}