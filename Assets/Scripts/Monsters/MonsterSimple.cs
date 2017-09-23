using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSimple : Character
{
    protected override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(SpeedCor());
    }

    IEnumerator SpeedCor()
    {
        yield return new WaitForSeconds(10.0f);
        character.speed += 1.0f;
    }

    void Update ()
    {
        Vector3 target_pos = PlayerInfo.player.tran.position;
        character.RotateToPoint(target_pos);

        Vector3 movement = PlayerInfo.player.tran.position - tran.position;
        character.Move(movement);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<Character>().GetHit(1);
            Destroy(gameObject);
        }
    }
}
