using UnityEngine;

public class BallColision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Obstacle"))
        {
            GameManager.Instance.isGameover = true;
            PlayerMovement.Instance.Restart ();
        }
    }
}
