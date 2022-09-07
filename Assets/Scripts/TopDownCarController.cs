using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCarController : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float _driftFactor = 0.95f;
    [SerializeField] private float _accelerationFactor = 30.0f;
    [SerializeField] private float _turnFactor = 3.5f;

    //Local variables
    float _accelerationInput = 0;
    float _steeringInput = 0;

    float _rotationAngle = 0;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(transform.right * _accelerationFactor);
        }
    }

    private void FixedUpdate()
    {
        ApplyEngineForce();

        KillOrthogonalVelocity();

        ApplySteering();
    }

    void ApplyEngineForce()
    {
        Vector2 engineForceVector = transform.up * _accelerationInput * _accelerationFactor;

        _rb.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        float minSpeedBeforeAllowTurningFactor = (_rb.velocity.magnitude / 8);
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

        _rotationAngle -= _steeringInput * _turnFactor * minSpeedBeforeAllowTurningFactor;

        _rb.MoveRotation(_rotationAngle);
    }

    public void SetInputVector(Vector2 inputVector)
    {
        _steeringInput = inputVector.x;
        _accelerationInput = inputVector.y;
    }

    void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(_rb.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(_rb.velocity, transform.right);

        _rb.velocity = forwardVelocity + rightVelocity * _driftFactor;
    }
}
