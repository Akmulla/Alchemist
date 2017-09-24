using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PoolRef pool_ref;
    public string target;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            //other.gameObject.GetComponent<Character>().GetHit(1);
            pool_ref.GetPool().Deactivate(gameObject);
            //Destroy(gameObject);
        }

        if (other.gameObject.CompareTag(target))
        {
            other.gameObject.GetComponent<Character>().GetHit(1);
            pool_ref.GetPool().Deactivate(gameObject);
            //Destroy(gameObject);
        }

    }
}
