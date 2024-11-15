using UnityEngine;

public class BallColision : MonoBehaviour
{
    ParticleSystem explosionFX;
    int ballIndex;
    private void Start()
    {
        explosionFX = transform.GetChild(0).GetComponent<ParticleSystem>();
        ballIndex = transform.position.x > 0 ? 0 : 1;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Obstacle"))
        {
            GameManager.Instance.isGameover = true;
            explosionFX.Play();
            Splatters.Instance.AddSplatter(other.transform, other.contacts[0].point, ballIndex);
            PlayerMovement.Instance.Restart ();
        }
    }
}
