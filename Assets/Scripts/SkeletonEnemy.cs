using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemy : Enemyv2
{
    public swordEnemySkeleton swordEnemy;
    public SkeletonEnemy()
    {
        base.health = 14f;
        base.moveSpeed = 50f;
        base.score_reward = 7;
    }

    public override void Attack()
    {
        swordEnemy.atkdirection = directionAtk;
        if (timeatk > 3.3f)
        {
            CannotMove();
            onFire();
            timeatk = 0;
        }
        else
        {
            CanMove();
        }
    }
    public void startAttack()
    {
        swordEnemy.startAttack();
    }
    public void stopAttack()
    {
        swordEnemy.stopAttack();
    }
}
