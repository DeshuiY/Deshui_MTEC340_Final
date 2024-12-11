using UnityEngine;

public class PlaySoundOnce : MonoBehaviour
{
    private bool hasPlayed = false; 
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing on this prefab!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed && other.CompareTag("Player")) 
        {
            hasPlayed = true; 
            if (audioSource != null)
            {
                audioSource.Play(); 
            }

           
        }
    }
}
