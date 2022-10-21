using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    float timer = 3;

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
            desiredVelocity = rb.velocity;

        }

        if (other.transform.CompareTag("LimitTopWall") || other.transform.CompareTag("LimitBottomWall"))
        {
            rb.velocity = new Vector3(desiredVelocity.x, 0, -desiredVelocity.z);
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity != Vector3.zero)
        {
            desiredVelocity = rb.velocity;
        }
        else
        {
            rb.velocity = desiredVelocity;
        }
    }

    private void OnEnable()
    {
        StartCoroutine(StartCountdown());
    }

    void ThrowBall()
    {
        int horizontal = Random.Range(0, 2);
        int vertical = Random.Range(0, 2);
        Vector3 direction = Vector3.zero;

        if (horizontal == 0)
        {
            direction += transform.right;
        }
        else
        {
            direction -= transform.right;
        }
        if (vertical == 0)
        {
            direction += transform.forward;
        }
        else
        {
            direction -= transform.forward;
        }
        rb.AddForce(direction * 10, ForceMode.Impulse);
        timer = 3;
    }

    IEnumerator StartCountdown()
    {
        Time.timeScale = 1;
        while (timer > 0)
        {
            timer--;
            yield return new WaitForSeconds(1);
        }
        ThrowBall();
    }
}
