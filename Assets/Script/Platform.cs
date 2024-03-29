using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles; //장애물 오브젝트들
    private bool stepped = false; //플레이어 캐릭터가 밟았는가
    void OnEnable() //오브젝트 활성화될 때마다 실행되는 메서드
    {
        //발판을 리셋하는 처리
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        //플레이어 캐릭터가 자신을 밟았을 때 점수를 추가하는 처리
        if(col.collider.tag == "Player" && !stepped)
        {
            stepped = true;
            GameManager.instance.AddScore(1);
        }
        //stepped = false; //밟힘 상태를 리셋
        //for(int i = 0; i < obstacles.Length; i++)
        //{   //현재 순번의 장애물을 1/3의 확률로 활성화
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
