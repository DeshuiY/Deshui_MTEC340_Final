using UnityEngine;

public class ChargeUp : MonoBehaviour
{
    public float bonusTime = 20f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            CountdownTimer timer = FindObjectOfType<CountdownTimer>(); 
            if (timer != null)
            {
                timer.AddTime(bonusTime); 
            }

            Destroy(gameObject); 
        }
    }
}