using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosivebottle : MonoBehaviour
{
    public GameObject explosion;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }

        if (other.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }

    }
}
