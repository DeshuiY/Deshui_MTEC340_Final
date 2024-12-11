using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 

    void Update()
    {
        if (ScoreManager.Instance != null)
        {
            scoreText.text = "Grade: " + ScoreManager.Instance.score;
        }
    }
}