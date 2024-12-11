using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public float timeBonus = 20f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("charge-up"))
        {
            CountdownTimer timer = FindObjectOfType<CountdownTimer>();
            if (timer != null)
            {
                timer.AddTime(timeBonus); 
                Debug.Log($"Charge-up collected! Added {timeBonus} seconds.");
            }

            Destroy(other.gameObject); 
        }
    }
}