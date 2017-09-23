using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public EnemyType type;
    public CharData char_data;
    [HideInInspector]
    public Transform tran;
    public int hp=1;
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

    protected virtual void Awake()
    {
        tran = GetComponent<Transform>();
    }

	protected virtual void OnEnable ()
    {
        hp = char_data.hp_base;
        speed = char_data.speed_base;
	}

	public void GetHit(int damage)
    {
        hp -= damage;
        if (hp<=0)
        {
            Destroy(gameObject);
        }
    }
}
