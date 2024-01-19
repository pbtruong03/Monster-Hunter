using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : Enemy
{
    private float damage;
    public SlimeEnemy() {
        damage = 2f;
        base.health = 10f;
        base.moveSpeed = 40f;
        base.score_reward = 1;
    }

    public override void Attack(PlayerController player)
    {
        player.GetDamage(damage);
    }

}
