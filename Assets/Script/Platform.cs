using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles; //��ֹ� ������Ʈ��
    private bool stepped = false; //�÷��̾� ĳ���Ͱ� ��Ҵ°�
    void OnEnable() //������Ʈ Ȱ��ȭ�� ������ ����Ǵ� �޼���
    {
        //������ �����ϴ� ó��
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        //�÷��̾� ĳ���Ͱ� �ڽ��� ����� �� ������ �߰��ϴ� ó��
        if(col.collider.tag == "Player" && !stepped)
        {
            stepped = true;
            GameManager.instance.AddScore(1);
        }
        //stepped = false; //���� ���¸� ����
        //for(int i = 0; i < obstacles.Length; i++)
        //{   //���� ������ ��ֹ��� 1/3�� Ȯ���� Ȱ��ȭ
        //    if(Random.Range(0,3) == 0)
        //    {
        //        obstacles[i].SetActive(true);
        //    }
        //    else
        //    {
        //        obstacles[i].SetActive(false);
        //    }
        //}
    }
}
