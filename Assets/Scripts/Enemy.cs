using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float waitSecond = 0.5f;
    Vector3 direction;
    Vector3 owner;
    bool isOn = false;
    bool isEnd = false;
    GameObject laser;

    float frontback = 1f;
    void Awake()
    {
        direction = transform.right * 5;
        owner = transform.position;
        laser = transform.GetChild(1).gameObject;
    }

    void OnEnable()
    {
        isOn = true;
        StartCoroutine("moveEnemy");
    }

    void FixedUpdate()
    {
        if(isOn)
        {
            transform.position = Vector3.Lerp(transform.position, owner + (direction * frontback), 0.07f);
        }
    }

    private void Update()
    {
        if(isEnd)
        {
            isEnd = false;
            gameObject.SetActive(false);
        }
    }

    IEnumerator moveEnemy()
    {
        yield return new WaitForSeconds(waitSecond);
        isOn = false;
        yield return new WaitForSeconds(waitSecond);
        laser.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        laser.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        frontback = -1f;
        isOn = true;
        yield return new WaitForSeconds(waitSecond);
        frontback = 1f;
        isEnd = true;

    }


}
