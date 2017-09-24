using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSimple : Character
{
    public GameObject sayan;

    protected override void OnEnable()
    {
        base.OnEnable();
        sayan.SetActive(false);
        StartCoroutine(SpeedCor());
    }

    IEnumerator SpeedCor()
    {
        yield return new WaitForSeconds(10.0f);
        speed += 1.0f;
    }

    void Update ()
    {
        Vector3 target_pos = Player.player.tran.position;
        RotateToPoint(target_pos);

        Vector3 movement = Player.player.tran.position - tran.position;
        Move(movement);
	}

    IEnumerator Sayan()
    {
        sayan.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        sayan.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if ((coll.gameObject.tag == "Player")&&(!reload_1))
        {
            StartCoroutine(Sayan());
            coll.gameObject.GetComponent<Character>().GetHit(1);
            StartCoroutine(Reload1(char_data.reload_1));
            //Destroy(gameObject);
           // pool_ref.GetPool().Deactivate(gameObject);
        }
    }

    
}
