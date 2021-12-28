using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTile : MonoBehaviour
{
    [SerializeField]
    float waitSeconds = 0.5f;

    SpriteRenderer rend;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        StartCoroutine("enemyTileOn");    
    }

    IEnumerator enemyTileOn()
    {
        yield return new WaitForSeconds(waitSeconds);
        gameObject.layer = 0;
        rend.color = new Color(0f, 1f, 0f, 1f);
        yield return new WaitForSeconds(waitSeconds);
        rend.color = new Color(0f, 1f, 0f, 0.5f);
        gameObject.layer = 6;
        gameObject.SetActive(false);
    }
}
