using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] bool playerLeft;
    [SerializeField] float moveSpeed = 10f;

    [SerializeField] float maxHeight = 3.5f;

    private void Update()
    {
        MovePlayer(playerLeft);
    }

    void MovePlayer(bool playerLeft)
    {
        if (playerLeft)
        {
            if (Input.GetKey(InputManager.instance.keys["LeftUp"]) && (transform.position.z < maxHeight))
            {
                Vector3 dir = new Vector3(0, 0, 1);
                transform.Translate(dir * moveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(InputManager.instance.keys["LeftDown"]) && (transform.position.z > -maxHeight))
            {
                Vector3 dir = new Vector3(0, 0, -1);
                transform.Translate(dir * moveSpeed * Time.deltaTime);
            }
        }
        else //player right
        {
            if (Input.GetKey(InputManager.instance.keys["RightUp"]) && (transform.position.z < maxHeight))
            {
                Vector3 dir = new Vector3(0, 0, 1);
                transform.Translate(dir * moveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(InputManager.instance.keys["RightDown"]) && (transform.position.z > -maxHeight))
            {
                Vector3 dir = new Vector3(0, 0, -1);
                transform.Translate(dir * moveSpeed * Time.deltaTime);
            }
        }
    }
}
