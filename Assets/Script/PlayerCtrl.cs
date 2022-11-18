using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public AudioClip deathClip;
    public float jumpForce = 700f;

    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;
    private Rigidbody2D rb2D;
    private Animator animator;
    private AudioSource playerAudio;
    private readonly int hashGrounded = Animator.StringToHash("Grounded");
    private readonly int hashDie = Animator.StringToHash("Die");
    void Start()
    {
        //초기화
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        //사용 입력을 감지하고 점프 처리
        if (isDead == true) return;
        if(Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            rb2D.velocity = Vector2.zero; //점프 직전에 속도를 순간적으로 제로로 변경
            rb2D.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
        }
        else if(Input.GetMouseButtonUp(0) && rb2D.velocity.y > 0)
        {           //마우스 왼쪽 버튼을 떼는 순간 %% 속도의 y값이 양수라면(위로 상승중)
                    //현재속도는 절반으로 변경
            rb2D.velocity = rb2D.velocity * 0.5f;
        }
        animator.SetBool("Grounded", isGrounded);
    }
    void Die()
    {
        //사망 처리
        animator.SetTrigger(hashDie);
        playerAudio.clip = deathClip;
        playerAudio.Play();
        rb2D.velocity = Vector2.zero;
        isDead = true;
        GameManager.instance.OnPlayerDead();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {   //트리거 콜라이더를 가진 장애물과 충돌을 감지
        if(other.tag == "Dead" && !isDead)
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {           //바닥에 닿았음을 감지하는 처리
        if (collision.contacts[0].normal.y > 0.7f)
        {   //어떤 콜라이더와 닿았으며 충돌표면이 위쪽을 보고 있으면
            isGrounded = true;
            jumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //바닥을 벗어났음을 감지하는 처리
        isGrounded = false;
    }
}
