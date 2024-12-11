using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float timeLimit = 60f; 
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
}