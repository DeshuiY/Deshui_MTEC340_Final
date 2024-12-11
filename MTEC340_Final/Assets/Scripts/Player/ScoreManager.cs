using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI scoreText; 
    public int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("ScoreManager Initialized");
        }
        else
        {
            Destroy(gameObject);
            Debug.LogWarning("Duplicate ScoreManager instance destroyed");
        }
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log($"Score: {score} (Added {value} points)");

        
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogError("ScoreManager: scoreText reference is missing!");
        }
    }
}