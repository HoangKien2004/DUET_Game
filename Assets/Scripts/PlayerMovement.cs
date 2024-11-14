using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Singleton class: PlayerMovement
    public static PlayerMovement Instance;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion
    [SerializeField] CircleCollider2D redBallCollider;
    [SerializeField] CircleCollider2D blueBallCollider;
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    Rigidbody2D rb;
    Vector3 startPosition;
    void Start()
    { 
        startPosition = transform.position;
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
    public void Restart()
    {
        redBallCollider.enabled = false;
        blueBallCollider.enabled = false;
        rb.angularVelocity = 0f;
        rb.velocity = Vector2.zero;

        transform
            .DORotate(Vector3.zero, 1f)
            .SetDelay(1f)
            .SetEase(Ease.InOutBack);
        transform
            .DOMove(startPosition, 1f)
            .SetDelay (1f)
            .SetEase(Ease.OutFlash)
            .OnComplete(() => {
                redBallCollider.enabled = true;
                blueBallCollider.enabled = true;
                GameManager.Instance.isGameover = false;
                MoveUp();
            });
    }
}
