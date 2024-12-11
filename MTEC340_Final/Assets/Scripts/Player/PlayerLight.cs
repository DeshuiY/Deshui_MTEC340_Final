using UnityEngine;

public class Playerlight : MonoBehaviour
{
    public Light flashlight; 
    public float offsetDistance = 0.5f; 
    public float offsetHeight = 1f; 

    void Update()
    {
        if (flashlight != null)
        {
            
            flashlight.transform.position = transform.position + transform.forward * offsetDistance + Vector3.up * offsetHeight;

            
            flashlight.transform.rotation = transform.rotation;
        }
    }
}