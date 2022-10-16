using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] bool playerLeft;
    [SerializeField] float moveSpeed = 10f;
    bool canMoveUp = true;
    bool canMoveDown = true;

    private void Update()
    {
        MovePlayer(playerLeft);
    }

    void MovePlayer(bool playerLeft)
    {
        if (playerLeft)
        {
            if (Input.GetKey(InputManager.instance.keys["LeftUp"]) && canMoveUp)
            {
                Vector3 dir = new Vector3(0, 0, 1);
                transform.Translate(dir * moveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(InputManager.instance.keys["LeftDown"]) && canMoveDown)
            {
                Vector3 dir = new Vector3(0, 0, -1);
                transform.Translate(dir * moveSpeed * Time.deltaTime);
            }
        }
        else //player right
        {
            if (Input.GetKey(InputManager.instance.keys["RightUp"]) && canMoveUp)
            {
                Vector3 dir = new Vector3(0, 0, 1);
                transform.Translate(dir * moveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(InputManager.instance.keys["RightDown"]) && canMoveDown)
            {
                Vector3 dir = new Vector3(0, 0, -1);
                transform.Translate(dir * moveSpeed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("LimitTopWall"))
        {
            canMoveUp = false;
        }
        if (other.transform.CompareTag("LimitBottomWall"))
        {
            canMoveDown = false;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        canMoveDown = true;
        canMoveUp = true;
    }
}
