using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpPower = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
        }
    }
}