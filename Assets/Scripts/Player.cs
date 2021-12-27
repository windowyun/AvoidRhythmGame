using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 3f;

    bool isMove = false;
    Vector3 afterPos;

    void Start()
    {
      
    }

    void Update()
    {
        if (!isMove)
        {
            if (Input.GetKey(KeyCode.W) && transform.position.y < 5f)
            {
                isMove = true;
                afterPos = transform.position + Vector3.up;
            }

            else if (Input.GetKey(KeyCode.S) && transform.position.y > -5f)
            {
                isMove = true;
                afterPos = transform.position + (Vector3.up * -1f);
            }

            else if (Input.GetKey(KeyCode.D) && transform.position.x < 8f)
            {
                isMove = true;
                afterPos = transform.position + Vector3.right;
            }

            else if (Input.GetKey(KeyCode.A) && transform.position.x > -8f)
            {
                isMove = true;
                afterPos = transform.position + (Vector3.right * -1f);
            }
        }
    }

    void FixedUpdate()
    {
        if(isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, afterPos, moveSpeed * 0.1f);
        
            if(transform.position == afterPos)
            {
                transform.position = afterPos;
                isMove = false;
            }
        }
    }

    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {

        }
    }
}
