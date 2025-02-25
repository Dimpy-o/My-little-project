using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of movement
    private Vector2 movement;


    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal"); // Gets -1 (left) or 1 (right)
        movement.x = input * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
