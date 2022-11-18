using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//매니저 클래스는 싱글 턴을 사용해야 한다.
//싱글턴을 사용해야 하는 이유
//1. 게임매니저 오브젝트는 단 하나만 존재 객체생성 하나만 되어야 한다.
//매니저 클래스가 무분별하게 객체가 생성 여러개가 생성되면 안됨
//하나의 객체만 생성되게 한다.
//2. 어떤 곳에서도 손쉽게 게임 매니저 오브젝트에 접근 가능
public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public Text scoretxt;
    public GameObject gameoverUI;
    private int score = 0;
    public static GameManager instance;

    void Start()
    {   //싱글턴 변수 instance가 비어 있는가
        if (instance == null)
        {   //비어 있다면 할당
            instance = this;
        }
        else if (instance != null)
        {   //instance에 이미 다른 GameManager 오브젝트가 할당되어 있는 경우
            //씬에 두개 이상의 GameManager 오브젝트가 존재한다는 의미
            //싱글턴 오브젝트는 하나만 존재해야하므로 자기
            //자신의 게임오브젝트 파괴
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if(isGameOver && Input.GetMouseButtonDown(0))
        {   //게임오버상태에서 마우스 왼쪽버튼을 클릭하면 현재 씬 재시작
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void AddScore(int newScore)
    {
        if(!isGameOver)
        {
            score += newScore;
            scoretxt.text = "Score : " + score;
        }
    }
    //플레이어 캐릭터 사망시 게임오버를 실행하는 메서드
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameoverUI.SetActive(true);
    }
}
