using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource footstepsAudioSource; 
    public float walkingThreshold = 0.1f; 
    private Rigidbody playerRigidbody; 

    void Start()
    {
        
        playerRigidbody = GetComponent<Rigidbody>();

        if (footstepsAudioSource == null)
        {
            Debug.LogError("Footsteps AudioSource is not assigned!");
        }
    }

    void Update()
    {
        
        if (playerRigidbody != null && footstepsAudioSource != null)
        {
            if (playerRigidbody.velocity.magnitude > walkingThreshold)
            {
                
                if (!footstepsAudioSource.isPlaying)
                {
                    footstepsAudioSource.Play();
                }
            }
            else
            {
                
                if (footstepsAudioSource.isPlaying)
                {
                    footstepsAudioSource.Stop();
                }
            }
        }
    }
}
