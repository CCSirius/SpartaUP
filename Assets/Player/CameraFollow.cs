using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 30f, -6f); 
    public bool followRotation = false;

    void LateUpdate()
    {
        if (target == null) return;

        transform.position = target.position + offset;

        if (!followRotation)
            transform.LookAt(target);
        else
            transform.rotation = target.rotation;
    }
}