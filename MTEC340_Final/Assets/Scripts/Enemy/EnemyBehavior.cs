using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private bool isDead = false; 

    
    public void TakeDamage()
    {
        if (isDead) return; 

        isDead = true; 
        Die(); 
    }

    private void Die()
    {
       
        Destroy(gameObject);
    }
}