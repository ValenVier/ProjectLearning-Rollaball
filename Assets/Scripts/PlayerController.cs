using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0; //speed

    public TextMeshProUGUI countText; // UI text component to display count of "PickUp" objects collected.
    public GameObject winTextObject; // UI object to display winning text

    private Rigidbody rb; //player
    private float movementX; //movement X
    private float movementY; //movement Y

    private int count; // Variable to keep track of collected "PickUp" objects.


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0; // Initialize count to zero.

        SetCountText(); // Update the count display.
        winTextObject.SetActive(false); // Initially set the win text to be inactive.
    }

    // Move input detected
    void OnMove(InputValue movementValue)
    {
        //Input value into Vector2
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString(); // Update the count text with the current count.
        if (count >= 12) // Check if the count has reached or exceeded the win condition.
        {
            winTextObject.SetActive(true); // Display the win text.
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win!"; //Show text when I win

            Destroy(GameObject.FindGameObjectWithTag("Enemy")); //Destroy Enemy
        }
    }

    private void FixedUpdate()
    {
        // Create a 3D movement vector; Movement Z = 0 => 0.0f
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed); //Apply force
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject); //destroy the current object

            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "GameOver!"; //Show text when I lose
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) //Check the object's tag
        {
            other.gameObject.SetActive(false); //Deactivate PickUp object
            count++; //adding 1 to the value

            SetCountText(); // Update the count display.
        }
    }
}
