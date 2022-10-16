using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    Rigidbody rb;
    public Vector3 desiredVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("PlayerLeft") || other.transform.CompareTag("PlayerRight"))
        {
            rb.velocity = new Vector3(-desiredVelocity.x, 0, desiredVelocity.z);
            rb.velocity *= 1.02f;
        }

        if (other.transform.CompareTag("LimitTopWall") || other.transform.CompareTag("LimitBottomWall"))
        {
            rb.velocity = new Vector3(desiredVelocity.x, 0, desiredVelocity.z);
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.x != desiredVelocity.x)
        {
            desiredVelocity = rb.velocity;
        }
        if (rb.velocity == Vector3.zero)
        {
            rb.velocity = desiredVelocity;
        }
    }
}
