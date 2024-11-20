using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] float _speed = 3.0f;
    [SerializeField] float _rotationSpeed = 100.0f; 
    [SerializeField] float _obstacleRange = 5.0f;
    [SerializeField] float _turnDistance = 1.5f; 

    private readonly float _sphereRadius = 0.75f;
    private bool _isAlive;
    public bool IsAlive { get => _isAlive; set => _isAlive = value; }

    [SerializeField] GameObject _fireballPrefab;
    public GameObject _fireball;

    private Vector3 _startPosition;  
    private bool _returningToStart = false;  
    private Quaternion _originalRotation;   
    private bool _isTurning = false;  
    private Quaternion _targetRotation;  

    private void Start()
    {
        IsAlive = true;
        _startPosition = transform.position; 
        _originalRotation = transform.rotation; 
    }

    private void Update()
    {
        if (_isAlive)
        {
            DetectPlayerAndShoot(); 

            if (_returningToStart)
            {
                ReturnToStartPosition();
            }
            else if (_isTurning)
            {
                SmoothTurn();
            }
            else
            {
                NormalMovement();
            }
        }
    }

    private void NormalMovement()
    {
        transform.Translate(0, 0, _speed * Time.deltaTime);

        Ray ray = new(transform.position, transform.forward);

        if (Physics.SphereCast(ray, _sphereRadius, out RaycastHit hit, _obstacleRange))
        {
            if (!hit.transform.CompareTag("Player"))
            {
                _returningToStart = true;
            }
        }
    }

    private void ReturnToStartPosition()
    {
        Vector3 directionToStart = (_startPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(directionToStart);

        if (Vector3.Distance(transform.position, _startPosition) < _turnDistance)
        {
            _targetRotation = Quaternion.Euler(0, Random.Range(-110, 110), 0) * _originalRotation;
            _returningToStart = false;
            _isTurning = true;
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, _rotationSpeed * Time.deltaTime);
            transform.Translate(0, 0, _speed * Time.deltaTime);
        }
    }

    private void SmoothTurn()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);

        if (Quaternion.Angle(transform.rotation, _targetRotation) < 1f)
        {
            _isTurning = false;
        }
    }

    private void DetectPlayerAndShoot()
    {
        Ray ray = new(transform.position, transform.forward);

        if (Physics.SphereCast(ray, _sphereRadius, out RaycastHit hit, _obstacleRange))
        {
            if (hit.transform.CompareTag("Player"))
            {
                if (_fireball == null || !_fireball.activeInHierarchy)
                {
                    _fireball = Instantiate(
                        _fireballPrefab,
                        transform.TransformPoint(Vector3.forward * 1.5f),
                        transform.rotation
                    );
                }
            }
        }
    }
}
