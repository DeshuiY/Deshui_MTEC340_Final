using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private bool isDead = false; 
    public int points = 1; 

    public void TakeDamage()
    {
        if (isDead) return;

        isDead = true; 
        Die(); 
    }

    private void Die()
    {
        Debug.Log("Die function called");
        if (ScoreManager.Instance != null)
        {
            Debug.Log("Updating score");
            ScoreManager.Instance.AddScore(points);
        }
        Destroy(gameObject);
    }
}