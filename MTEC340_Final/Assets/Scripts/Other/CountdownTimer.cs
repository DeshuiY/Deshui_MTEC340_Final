using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float timeLimit = 200f; 
    private float timer;

    public TextMeshProUGUI timerText; 

    void Start()
    {
        timer = timeLimit; 
        UpdateTimerUI(); 
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime; 
            UpdateTimerUI(); 
        }
        else
        {
            timer = 0; 
            UpdateTimerUI();
            TimerEnded(); 
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = $"Time Left: {Mathf.Ceil(timer)}s"; 
        }
    }

    void TimerEnded()
    {
        Debug.Log("Timer has ended!");
        
    }

    public void AddTime(float additionalTime)
    {
        timer += additionalTime; 
        UpdateTimerUI();
        Debug.Log($"Added {additionalTime} seconds! Current timer: {timer}s");
    }
}