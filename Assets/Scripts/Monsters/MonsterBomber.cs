using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBomber : Character
{
    public GameObject explosion_circle;
    public LayerMask player;
    protected override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(ExplodeCor());
    }

    IEnumerator ExplodeCor()
    {
        yield return new WaitForSeconds(5.0f);
        Explode();
    }

    void Explode()
    {
        //if (Physics2D.OverlapCircle(tran.position,3.0f,player))
        //{
        //    //print("sdfg");
        //    Player.player.GetHit(2);
        //}
        Instantiate(explosion_circle, tran.position, Quaternion.identity);
        //Destroy(gameObject);
        pool_ref.GetPool().Deactivate(gameObject);
    }

    void Update()
    {
        Vector3 target_pos = Player.player.tran.position;
        RotateToPoint(target_pos);

        Vector3 movement = Player.player.tran.position - tran.position;
        Move(movement);
    }

}
