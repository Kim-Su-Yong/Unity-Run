using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//�Ŵ��� Ŭ������ �̱� ���� ����ؾ� �Ѵ�.
//�̱����� ����ؾ� �ϴ� ����
//1. ���ӸŴ��� ������Ʈ�� �� �ϳ��� ���� ��ü���� �ϳ��� �Ǿ�� �Ѵ�.
//�Ŵ��� Ŭ������ ���к��ϰ� ��ü�� ���� �������� �����Ǹ� �ȵ�
//�ϳ��� ��ü�� �����ǰ� �Ѵ�.
//2. � �������� �ս��� ���� �Ŵ��� ������Ʈ�� ���� ����
public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public Text scoretxt;
    public GameObject gameoverUI;
    private int score = 0;
    public static GameManager instance;

    void Start()
    {   //�̱��� ���� instance�� ��� �ִ°�
        if (instance == null)
        {   //��� �ִٸ� �Ҵ�
            instance = this;
        }
        else if (instance != null)
        {   //instance�� �̹� �ٸ� GameManager ������Ʈ�� �Ҵ�Ǿ� �ִ� ���
            //���� �ΰ� �̻��� GameManager ������Ʈ�� �����Ѵٴ� �ǹ�
            //�̱��� ������Ʈ�� �ϳ��� �����ؾ��ϹǷ� �ڱ�
            //�ڽ��� ���ӿ�����Ʈ �ı�
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if(isGameOver && Input.GetMouseButtonDown(0))
        {   //���ӿ������¿��� ���콺 ���ʹ�ư�� Ŭ���ϸ� ���� �� �����
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
    //�÷��̾� ĳ���� ����� ���ӿ����� �����ϴ� �޼���
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameoverUI.SetActive(true);
    }
}
