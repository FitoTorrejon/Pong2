using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RandomBall : MonoBehaviour
{
    Rigidbody rb;
    Vector3 direction = new Vector3(1, 0, 1);

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        ThrowRandomBall();
    }

    void ThrowRandomBall()
    {
        rb.AddForce(direction * 20, ForceMode.Impulse);
    }
}
