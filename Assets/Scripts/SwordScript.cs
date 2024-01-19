using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public float damage = 2;
    public enum AttackDirection
    {
        left, right, top, down
    };

    public AttackDirection attackDirection;

    private BoxCollider2D swordCollider;

    private Vector3 _leftAttackTF = new Vector3(-0.102f, -0.145f);
    private Vector3 _rightAttackTF = new Vector3(0.102f, -0.145f);
    private Vector3 _topAttackTF = new Vector3(-0.005f, -0.025f);
    private Vector3 _downAttackTF = new Vector3(0.022f, -0.195f);


    // Size Box Collider of Attack
    Vector2 topdownAttackSize = new Vector2(0.19f, 0.08f);
    Vector2 rightleftAttackSize = new Vector2(0.15f, 0.13f);

    // Start is called before the first frame update
    void Start(){
        swordCollider = GetComponent<BoxCollider2D>();
        attackDirection = AttackDirection.down;
        transform.localPosition = new Vector3(0f, 0f, 0f);
    }

    public void startAttack()
    {
        switch (attackDirection)
        {
            case AttackDirection.left:
                leftAttack();
                break;
            case AttackDirection.right:
                rightAttack();
                break;
            case AttackDirection.top:
                topAttack();
                break; 
            case AttackDirection.down:
                downAttack();
                break;
        }
    }
    private void rightAttack(){
        swordCollider.enabled = true;
        swordCollider.offset = _rightAttackTF;
        swordCollider.size = rightleftAttackSize;
    }

    private void topAttack(){
        swordCollider.enabled = true;
        swordCollider.offset = _topAttackTF;
        swordCollider.size = topdownAttackSize;
    }

    private void downAttack(){
        swordCollider.enabled = true;
        swordCollider.offset = _downAttackTF;
        swordCollider.size = topdownAttackSize;
    }

    private void leftAttack(){
        swordCollider.enabled = true;
        swordCollider.offset = _leftAttackTF;
        swordCollider.size = rightleftAttackSize;
    }

    public void stopAttack(){
        swordCollider.enabled = false;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            try
            {
                Enemy enemy = other.GetComponent<Enemy>();
                Enemyv2 enemyv2 = other.GetComponent<Enemyv2>();
                if (enemy != null)
                {
                    enemy.GetDamage(this.damage);
                } else if (enemyv2 != null) {
                    enemyv2.GetDamage(this.damage);
                }
            }
            catch (NullReferenceException e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}
