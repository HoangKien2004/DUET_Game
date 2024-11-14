using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;

    void Start()
    {
        target = PlayerMovement.Instance.transform;   
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position;
    }
}
