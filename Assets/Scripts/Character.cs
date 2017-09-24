using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject death;
    protected PoolRef pool_ref;
    //public EnemyType type;
    public CharData char_data;
    [HideInInspector]
    public Transform tran;
    public int hp=1;
    Rigidbody2D rb;
    public float speed = 3.0f;
    protected bool reload_1=false;
    protected bool reload_2=false;

    protected IEnumerator Reload1(float delay)
    {
        reload_1 = true;
        yield return new WaitForSeconds(delay);
        reload_1 = false;
    }

    protected IEnumerator Reload2(float delay)
    {
        reload_2 = true;
        yield return new WaitForSeconds(delay);
        reload_2 = false;
    }

    public void RotateToPoint(Vector3 point)
    {
        point.z = 0;
        float angle = Vector2.Angle(Vector2.right, point - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < point.y ? angle : -angle);
    }

    public void Move(Vector3 movement)
    {
        //if (movement.magnitude>0.1f)
        rb.velocity = movement.normalized * speed;
        //else
           // rb.velocity = Vector2.zero;
    }

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Awake()
    {
        tran = GetComponent<Transform>();
        pool_ref = GetComponent<PoolRef>();
    }

	protected virtual void OnEnable ()
    {
        hp = char_data.hp_base;
        speed = char_data.speed_base;
	}

    public virtual void GetHit(int damage)
    {
        hp -= damage;
        if (hp<=0)
        {
            //Destroy(gameObject);
            pool_ref.GetPool().Deactivate(gameObject);
            Instantiate(death, tran.position, Quaternion.identity);
            GameController.gc.enemy_killed++;
            soundmanager.sound_manager.SingleSound(SoundSample.die_enemy);
        }
    }
}
