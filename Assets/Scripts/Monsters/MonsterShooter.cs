using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShooter : Character
{
    public GameObject bullet;

    void Update()
    {
        Vector3 target_pos = Player.player.tran.position;
        RotateToPoint(target_pos);

        Vector3 movement=Vector3.zero; 
        if ((target_pos-tran.position).magnitude<5.0f)
        {
            movement = -(Player.player.tran.position - tran.position);
        }

        Move(movement);

        if (!reload_1)
        {
            BulletPool.bp.enemy_pool.Activate(tran.position, tran.rotation);
            StartCoroutine(Reload1(char_data.reload_1));
        }
    }
}
