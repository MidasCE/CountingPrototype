using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float limitZLeft = -5;
    public float limitZRight = 5;
    
    public float speed = 10.0f; 
    private float _horizontalInput;
    
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    

    void FixedUpdate()
    {
        // Get horizontal input
        _horizontalInput = Input.GetAxis("Horizontal");

        // Calculate new position
        Vector3 newPosition = _rb.position + Vector3.forward * (speed * _horizontalInput * Time.fixedDeltaTime);

        // Clamp position within limits
        newPosition.z = Mathf.Clamp(newPosition.z, limitZLeft, limitZRight);

        // Move using Rigidbody to ensure smooth physics movement
        _rb.MovePosition(newPosition);
    }
}
