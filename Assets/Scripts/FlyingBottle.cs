using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBottle : MonoBehaviour
{
    Transform tran;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            BottleHandler.b.AddBottle(other.gameObject.GetComponent<Character>().char_data.bottle_data);
            other.gameObject.GetComponent<Character>().GetHit(1000);
            Destroy(gameObject);
        }
    }
    void Awake()
    {
        tran = GetComponent<Transform>();
    }
    void Update()
    {
        tran.Rotate(new Vector3(0.0f, 0.0f, 10.0f * Time.deltaTime));
    }
}
