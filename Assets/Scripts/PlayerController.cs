using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float health = 0f;
    private const float maxHealth = 100f;
    private float score = 0f;

    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter = new ContactFilter2D();
    public LayerMask mapColLayer; // LayerMask
    private bool canMove = true;
    private bool canAtk = true;
    Vector2 movementInput;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRendered;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject scoreUI;

    Audiomanager audiomanager;

    public SwordScript swordAttack;
    public PlayerBody playerbody;

    public Color hitColor = Color.red; // Màu sắc khi bị đánh
    public float hitDuration = 0.1f; // Thời gian màu sắc thay đổi
    public Color originalColor;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audiomanager = FindObjectOfType<Audiomanager>();
    }
    // Start is called before the first frame update
    void Start(){

        if(health <= 0)
        {
            health = maxHealth;
        }
        animator = GetComponent<Animator>();
        spriteRendered = GetComponent<SpriteRenderer>();
        mapColLayer = LayerMask.GetMask("MapCol");
        movementFilter.SetLayerMask(mapColLayer);
        playerbody = gameObject.AddComponent<PlayerBody>();
        playerbody.SetPlayer(this);
        originalColor = spriteRendered.color;
    }
    // Getter And Setter
    public float getHealth()
    {
        return health;
    }
    public void setHealth(float _health)
    {
        health = _health;
    }
    public float getPositionX()
    {
        return rb.position.x;
    }
    public float getPositionY()
    {
        return rb.position.y;
    }
    public void setPosition(float _px, float _py)
    {
        rb.position = new Vector3(_px, _py, 0);
    }
    public float getScore() { return score; }
    public void setScore(float _score) { score = _score; }
    public void updateScore(float _tmp) { score += _tmp; }

    // FixedUpdate 
    private void FixedUpdate() {
        if (canMove){
            if(movementInput != Vector2.zero){
                float x = movementInput.x;
                float y = movementInput.y;
                bool success = TryMove(movementInput);
                if (!success) {
                    success = TryMove(new Vector2(movementInput.x, 0));
                    if (!success)
                    {
                        success = TryMove(new Vector2(0,movementInput.y));
                    }
                }
                if (success){
                    animator.SetBool("isMoving", success);
                    if (x == 0){
                        if(y > 0){
                            animator.SetBool("isTop", true);
                            animator.SetBool("isDown", false);
                            animator.SetBool("isRight", false);
                            swordAttack.attackDirection = SwordScript.AttackDirection.top;
                        } else if (y < 0){
                            animator.SetBool("isTop", false);
                            animator.SetBool("isDown", true);
                            animator.SetBool("isRight", false);
                            swordAttack.attackDirection = SwordScript.AttackDirection.down;
                        }
                        spriteRendered.flipX = false;
                    }else {
                        animator.SetBool("isTop", false);
                        animator.SetBool("isDown", false);
                        animator.SetBool("isRight", true);

                        if(x > 0)
                        {
                            spriteRendered.flipX = false;
                            swordAttack.attackDirection = SwordScript.AttackDirection.right;
                        } else
                        {
                            spriteRendered.flipX = true;
                            swordAttack.attackDirection = SwordScript.AttackDirection.left;
                        }
                    }
                }
                } else{
                animator.SetBool("isMoving", false);
            }
        }
    }

    void spawnAttack(){
        swordAttack.startAttack();

    }

    void stopAttack()
    {
        swordAttack.stopAttack();
    }
    private bool TryMove(Vector2 direction){
        int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);
        if(count == 0)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        } else
        {
            return false;
        }
    }


    void OnMove (InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        if (canAtk)
        {
            animator.SetTrigger("spawnAttack");
            canAtk = false;
            StartCoroutine(WaitContinueAtk());
        }
    }
    IEnumerator WaitContinueAtk()
    {
        yield return new WaitForSeconds(0.4f);// Đặt lại màu sắc ban đầu sau khi đã thay đổi trong một khoảng thời gian
        canAtk = true;
    }

    void CanMove()
    {
        this.canMove = true;
    }

    void CannotMove()
    {
        this.canMove = false;
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        TakeDamage();
        if(health <= 0){
            animator.SetBool("isDeath", true);
            scoreUI.SetActive(false);
            audiomanager.GameOverMusic();
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void TakeDamage()
    {
        spriteRendered.color = hitColor; // Thay đổi màu sắc khi nhận sát thương
        StartCoroutine(ResetColorAfterDelay());
    }
    IEnumerator ResetColorAfterDelay()
    {
        yield return new WaitForSeconds(hitDuration);// Đặt lại màu sắc ban đầu sau khi đã thay đổi trong một khoảng thời gian
        spriteRendered.color = originalColor;
    }

    public float MaxHealth => maxHealth;

    // SFX Audio
    public void runSFX()
    {
        audiomanager.PlayerRunSFX();
    }
    public void atkSFX()
    {
        audiomanager.PlayerAtkSFX();
    }
}
