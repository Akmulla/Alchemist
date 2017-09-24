using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCircle : MonoBehaviour
{
    public LayerMask mask;

	void Start ()
    {
        StartCoroutine(DestroyCor());
	}
	
    IEnumerator DestroyCor()
    {
         Collider2D[] coll = Physics2D.OverlapCircleAll(transform.position, 1.69f, mask);
        for (int i = 0; i < coll.Length; i++)
        {
            coll[i].gameObject.GetComponent<Character>().GetHit(1);
        }
        soundmanager.sound_manager.SingleSound(SoundSample.explosion);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
