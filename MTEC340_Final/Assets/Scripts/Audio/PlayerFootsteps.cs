using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource footstepsAudioSource; 
    public float walkingThreshold = 0.1f; 

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        if (footstepsAudioSource == null)
        {
            Debug.LogError("Footsteps AudioSource is not assigned!");
        }
    }

    void Update()
    {
        if (characterController != null && footstepsAudioSource != null)
        {
            
            if (characterController.velocity.magnitude > walkingThreshold)
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