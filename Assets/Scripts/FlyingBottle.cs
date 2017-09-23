using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBottle : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            BottleHandler.b.AddBottle(other.gameObject.GetComponent<Character>().char_data.bottle_data);
            other.gameObject.GetComponent<Character>().GetHit(1000);
            Destroy(gameObject);
        }
        
    }
}
