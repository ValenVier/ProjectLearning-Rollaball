using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0; //speed

    private Rigidbody rb; //player
    private float movementX; //movement X
    private float movementY; //movement Y

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Move input detected
    void OnMove(InputValue movementValue)
    {
        //Input value into Vector2
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        // Create a 3D movement vector; Movement Z = 0 => 0.0f
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed); //Apply force
    }

}
