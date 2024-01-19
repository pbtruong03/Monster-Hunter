using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

abstract public class Enemy : MonoBehaviour
{
    protected Animator animator; // Hoạt hình của kẻ địch
    protected float health; //Máu của kẻ địch

    Vector2 direction; // Vector hướng di chuyển của kẻ địch
    protected float moveSpeed; // Tốc độ di chuyển
    public float collisionOffset = 0.005f;
    private bool canmove;
    public DetectionZone detectionZone;
    Rigidbody2D rbenemy;
    SpriteRenderer spriteE;

    protected float score_reward;
    private PlayerController player;

    private void Start(){
        player = FindObjectOfType<PlayerController>();

        spriteE = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rbenemy = GetComponent<Rigidbody2D>();
        direction = Random.insideUnitCircle.normalized;
        canmove = true;
    }

    //Update
    void FixedUpdate()
    {
        if (detectionZone != null && detectionZone.detectedObjs != null && detectionZone.detectedObjs.Count > 0)
        {
            direction = (detectionZone.detectedObjs[0].transform.position - transform.position).normalized;
            direction = (Quaternion.Euler(0f, 0f, Random.Range(-10f, +10f)) * direction).normalized;
            TryMove();
        }
        else
        {
            direction = (Quaternion.Euler(0f, 0f, Random.Range(-15f, +15f)) * direction).normalized;
            TryMove();
        }

    }

    public void TryMove(){
        if (canmove){
            // Flip sprite
            if (direction.x > 0) spriteE.flipX = false;
            else spriteE.flipX = true;
            // Set animation
            animator.SetBool("isMoving", true);
            rbenemy.AddForce(direction * moveSpeed * Time.deltaTime);
        }
        else{
            animator.SetBool("isMoving", false);
        }
    }

    public void CanMove()
    {
        canmove = true;
    }
    public void CannotMove()
    {
        canmove = false;
    }
    // Nhận sát thương từ vũ khí
    public void GetDamage(float dame){
        health -= dame;
        animator.SetTrigger("takeDamage");
        if (health <= 0) Defeated();
    }
    // Chết khi Sát thương <= 0
    public void Defeated(){
        animator.SetBool("isDeath", true);
    }
    // Xóa đối tượng
    public void Destroy(){
        player.updateScore(score_reward);
        Destroy(gameObject);
    }

    // Gây sát thương cho người chơi
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            try
            {
                PlayerController player = collision.collider.GetComponent<PlayerController>();
                if (player != null)
                {
                    this.Attack(player);
                }
            }
            catch (NullReferenceException e)
            {
                Debug.Log(e.Message);
            }
        }
    }

    private float timer = 0f; // Đếm thời gian

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            timer += Time.deltaTime; // Tăng đếm thời gian sau mỗi frame

            if (timer >= 1)
            {
                PlayerController player = collision.collider.GetComponent<PlayerController>();
                if (player != null)
                {
                    this.Attack(player); // Gây sát thương
                }

                timer = 0f; // Reset lại đếm thời gian
            }
        }
    }

    public abstract void Attack(PlayerController player);
}
