using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 3f;
    [SerializeField]
    float limitX = 8f;
    [SerializeField]
    float limitY = 5f;

    bool isMove = false;
    Vector3 afterPos;

    StartManager startManager;
    void Awake()
    {
        startManager = GameObject.Find("StartManager").GetComponent<StartManager>();
    }

    void Update()
    {
        if (startManager.IsStart) {
            if (!isMove)
            {
                if (Input.GetKey(KeyCode.W) && transform.position.y < limitY)
                {
                    isMove = true;
                    afterPos = transform.position + Vector3.up;
                }

                else if (Input.GetKey(KeyCode.S) && transform.position.y > -limitY)
                {
                    isMove = true;
                    afterPos = transform.position + (Vector3.up * -1f);
                }

                else if (Input.GetKey(KeyCode.D) && transform.position.x < limitX)
                {
                    isMove = true;
                    afterPos = transform.position + Vector3.right;
                }

                else if (Input.GetKey(KeyCode.A) && transform.position.x > -limitX)
                {
                    isMove = true;
                    afterPos = transform.position + (Vector3.right * -1f);
                }
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
            startManager.IsStart = false;
            SceneManager.LoadScene(0);
        }
    }
}
