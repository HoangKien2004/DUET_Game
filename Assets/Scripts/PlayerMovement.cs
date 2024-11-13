using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveUp();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            RotationLeft();
        else if(Input.GetKey(KeyCode.RightArrow))
            RotationRight();

        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            rb.angularVelocity = 0f;
    }
    void MoveUp()
    {
        rb.velocity = Vector2.up * speed;
    }
    void RotationLeft()
    {
        rb.angularVelocity = rotationSpeed;
    }
    void RotationRight()
    {
        rb.angularVelocity = -rotationSpeed;
    }
}
