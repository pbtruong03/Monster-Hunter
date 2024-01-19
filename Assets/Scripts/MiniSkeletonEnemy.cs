using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniSkeletonEnemy : Enemyv2
{
    public swordEnemyMiniSkeletons swordEnemy;
    public MiniSkeletonEnemy()
    {
        base.health = 14f;
        base.moveSpeed = 50f;
        base.score_reward = 4f;
    }

    public override void Attack()
    {
        swordEnemy.atkdirection = directionAtk;
        if(timeatk > 2f)
        {
            CannotMove();
            onFire();
            timeatk = 0;
        } else
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
