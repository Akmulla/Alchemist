using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCharge : Character
{
    bool charge = false;
    protected override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(Reload1(char_data.reload_1));
        charge = false;
    }
    void Update()
    {
        if ((!charge )&&(!reload_1))
        {
            StartCoroutine(Charge());
        }
        else
        {
            //Vector3 target_pos = Player.player.tran.position;
            //RotateToPoint(target_pos);
        }
    }

    IEnumerator Charge()
    {
        //yield return new WaitForSeconds(6.0f);
        charge = true;
        Vector3 target_pos = Player.player.tran.position;
        //RotateToPoint(target_pos);
        Vector3 movement=Vector3.zero;
        while ((target_pos-tran.position).magnitude>0.2f)
        {
            movement = target_pos - tran.position;
            Move(movement);
            yield return new WaitForEndOfFrame();
        }
        charge = false;
        StartCoroutine(Reload1(char_data.reload_1));
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if ((coll.gameObject.tag == "Player") && (!reload_1))
        {
            if (charge)
            {
                coll.gameObject.GetComponent<Character>().GetHit(3);
                charge = false;
            }
            
            //Destroy(gameObject);
            // pool_ref.GetPool().Deactivate(gameObject);
        }
    }
}
