using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordEnemySkeleton : MonoBehaviour
{
    public float damage = 4f;
    private CapsuleCollider2D swordECol;
    public Vector2 atkdirection;

    private Vector3 _leftAttackTF = new Vector3(-0.147f, 0.0198f);
    private Vector3 _rightAttackTF = new Vector3(0.147f, 0.0198f);

    void Start()
    {
        swordECol = GetComponent<CapsuleCollider2D>();
        transform.localPosition = new Vector3(0f, 0f, 0f);
    }
    public void startAttack()
    {
        if (atkdirection.x > 0f)
        {
            rightAttack();
        }
        else leftAttack();
    }

    public void leftAttack()
    {
        swordECol.offset = _leftAttackTF;
        swordECol.enabled = true;
    }

    public void rightAttack()
    {
        swordECol.offset = _rightAttackTF;
        swordECol.enabled = true;
    }

    public void stopAttack()
    {
        swordECol.enabled = false;
    }
}
