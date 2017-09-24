using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string target;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(target))
        {
            other.gameObject.GetComponent<Character>().GetHit(1);
            Destroy(gameObject);
        }

    }
}
