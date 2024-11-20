using UnityEngine;

public class MouseController : MonoBehaviour
{
    private void Start()
    {
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}