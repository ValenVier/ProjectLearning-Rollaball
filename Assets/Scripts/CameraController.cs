using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player; //Player GameObject
    private Vector3 offset; //distance camera-player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Initial offset
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame after all Update functions
    void LateUpdate()
    {
        //maintaining offset
        transform.position = player.transform.position + offset;
    }
}
