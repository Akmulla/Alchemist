using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float speed;
    public Transform tran;
    public Rigidbody2D rb;


    void Update()
    {
        rb.velocity = tran.right.normalized*speed;
    }
}
