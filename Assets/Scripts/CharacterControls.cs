using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 3.0f;

    public void RotateToPoint(Vector3 point)
    {
        point.z = 0;
        float angle = Vector2.Angle(Vector2.right, point - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < point.y ? angle : -angle);
    }
	
    public void Move(Vector3 movement)
    {
        rb.velocity = movement.normalized * speed;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}

