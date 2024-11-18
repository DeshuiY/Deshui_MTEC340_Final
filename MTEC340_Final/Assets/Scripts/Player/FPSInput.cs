using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    [Range(1.0f, 10.0f)]
    [SerializeField] float _speed = 6.0f;
    [SerializeField] float _gravity = -9.8f;

    private CharacterController _controller;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * _speed;
        float deltaZ = Input.GetAxis("Vertical") * _speed;

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0;
        right.y = 0;

        Vector3 movement = forward.normalized * deltaZ + right.normalized * deltaX;

        movement = Vector3.ClampMagnitude(movement, _speed);

        movement.y = _gravity;

        movement *= Time.deltaTime;

        _controller.Move(movement);
    }
}
