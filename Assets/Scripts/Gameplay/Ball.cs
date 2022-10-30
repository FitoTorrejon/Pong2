using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float timer = 3;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        rb.velocity = Vector3.zero;
        transform.position = new Vector3(0, 0.5f, 0);
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            MusicManager.instance.source.PlayOneShot(MusicManager.instance.HitSound());
        }
    }

    private void OnEnable()
    {
        timer = 3;
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
