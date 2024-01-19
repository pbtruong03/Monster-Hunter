using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerBody : MonoBehaviour
{
    private PlayerController player;
    public void SetPlayer(PlayerController playerController)
    {
        this.player = playerController;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyAtk")
        {
            try
            {
                if (other.GetComponent<swordEnemyMiniSkeletons>() != null)
                {
                    swordEnemyMiniSkeletons enemyAtk = other.GetComponent<swordEnemyMiniSkeletons>();
                    player.GetDamage(enemyAtk.damage);
                }
                else if (other.GetComponent<swordEnemySkeleton>() != null)
                {
                    swordEnemySkeleton enemyAtk = other.GetComponent<swordEnemySkeleton>();
                    player.GetDamage(enemyAtk.damage);
                }

            }
            catch (NullReferenceException e)
            {
                
            }

        }
    }
}
