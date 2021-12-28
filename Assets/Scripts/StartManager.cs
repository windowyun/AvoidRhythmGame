using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    bool isStart = false;
    public bool IsStart
    {
        get { return isStart; }
        set { isStart = value; }
    }
    AudioSource audioSource;

    [SerializeField]
    Player player;
    [SerializeField]
    GameObject[] EnemyTiles = new GameObject[45];
    [SerializeField]
    GameObject[] Enemys = new GameObject[28];
    void Awake()
    {
        // 오디오 소스 생성해서 추가
        audioSource = gameObject.GetComponent<AudioSource>();

        // 뮤트: true일 경우 소리가 나지 않음
        audioSource.mute = false;

        // 루핑: true일 경우 반복 재생
        audioSource.loop = false;

        // 자동 재생: true일 경우 자동 재생
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isStart)
        {
            isStart = true;
            StartCoroutine("gameStart");
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            isStart = false;
            StopAllCoroutines();
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator gameStart()
    {
        yield return new WaitForSeconds(1f);
        audioSource.Play();
        TileOn(0);
        EnemyOn(4);
    }

    void EnemyOn(int i)
    {
        Enemys[i].SetActive(true);
    }

    void TileOn(int i)
    {
        EnemyTiles[i].SetActive(true);
    }

}
