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
        //�ʱ�ȭ
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        //��� �Է��� �����ϰ� ���� ó��
        if (isDead == true) return;
        if(Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            rb2D.velocity = Vector2.zero; //���� ������ �ӵ��� ���������� ���η� ����
            rb2D.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
        }
        else if(Input.GetMouseButtonUp(0) && rb2D.velocity.y > 0)
        {           //���콺 ���� ��ư�� ���� ���� %% �ӵ��� y���� ������(���� �����)
                    //����ӵ��� �������� ����
            rb2D.velocity = rb2D.velocity * 0.5f;
        }
        animator.SetBool("Grounded", isGrounded);
    }
    void Die()
    {
        //��� ó��
        animator.SetTrigger(hashDie);
        playerAudio.clip = deathClip;
        playerAudio.Play();
        rb2D.velocity = Vector2.zero;
        isDead = true;
        GameManager.instance.OnPlayerDead();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {   //Ʈ���� �ݶ��̴��� ���� ��ֹ��� �浹�� ����
        if(other.tag == "Dead" && !isDead)
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {           //�ٴڿ� ������� �����ϴ� ó��
        if (collision.contacts[0].normal.y > 0.7f)
        {   //� �ݶ��̴��� ������� �浹ǥ���� ������ ���� ������
            isGrounded = true;
            jumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //�ٴ��� ������� �����ϴ� ó��
        isGrounded = false;
    }
}
