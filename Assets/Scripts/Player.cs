using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    //public Transform shot_spawn;
    public GameObject flying_bottle;
    public SpriteRenderer sprite_rend;
    public static Player player;
    //public Vector2 hit_zone;
    public LayerMask enemy_mask;
    bool reload_shift=false;
    public BottleData current_bottle;
    public BottleData player_bottle;

    protected IEnumerator ReloadShift(float delay)
    {
        reload_shift = true;
        yield return new WaitForSeconds(delay);
        reload_shift = false;
    }

    protected override void Awake()
    {
        base.Awake();
        player = this;
        
    }
    protected override void Start()
    {
        base.Start();
        UIController.ui.UpdateHearts(hp);
    }

    public void DrinkBottle(BottleData bottle)
    {
        current_bottle = bottle;
        sprite_rend.sprite = bottle.char_sprite;
        if (!CheckIfDefault())
        {
            StartCoroutine(DrinkCor());
        }
    }


    IEnumerator DrinkCor()
    {
        yield return new WaitForSeconds(10.0f);
        DrinkBottle(player_bottle);
    }

	void Update ()
    {
        GetMouseInput();
        GetMovement();
    }

    void Attack1()
    {
        switch (current_bottle.abil[0].enemy_type)
        {
            case EnemyType.None:
                RaycastHit2D hit = Physics2D.Raycast(transform.position, tran.right, 1.5f, enemy_mask);
                //print(hit.collider);
                if (hit.collider != null)
                {
                    hit.collider.gameObject.GetComponent<Character>().GetHit(1);
                }
                
                break;

            case EnemyType.Simple:

                break;

            case EnemyType.Bomber:

                break;
        }
    }

    void Attack2()
    {
        switch (current_bottle.abil[1].enemy_type)
        {
            case EnemyType.None:
                //RaycastHit2D hit = Physics2D.Raycast(transform.position, tran.right, 100.0f, enemy_mask);
                ////print(hit.collider);
                //if (hit.collider != null)
                //{
                //    BottleHandler.b.AddBottle(hit.collider.gameObject.GetComponent<Character>().char_data.bottle_data);
                //    hit.collider.gameObject.GetComponent<Character>().GetHit(1000);

                //    //hit.collider.gameObject.GetComponent<Character>().type
                //}
                Instantiate(flying_bottle, tran.position, tran.rotation);

                break;

            case EnemyType.Simple:

                break;

            case EnemyType.Bomber:

                break;
        }
    }

    //void Attack3()
    //{
    //    switch (current_bottle.abil[1].enemy_type)
    //    {
    //        case EnemyType.None:
    //            StartCoroutine(Sprint());

    //            break;

    //        case EnemyType.Simple:

    //            break;

    //        case EnemyType.Bomber:

    //            break;
    //    }
    //}
    IEnumerator Sprint()
    {
        speed += 2.0f;
        yield return new WaitForSeconds(3.0f);
        speed -= 2.0f;
    }
    void GetMouseInput()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        RotateToPoint(mousePosition);

        if ((Input.GetMouseButtonDown(0))&&(!reload_1))
        {
            Attack1();
            StartCoroutine(Reload1(current_bottle.abil[0].cooldown));
        }

        if ((Input.GetMouseButtonDown(1))&&(!reload_2))
        {
            Attack2();
            StartCoroutine(Reload2(current_bottle.abil[1].cooldown));
        }

        if ((Input.GetKeyDown("left shift")) && (!reload_shift))
        {
            StartCoroutine(Sprint());
            StartCoroutine(ReloadShift(7.0f));
            //Attack3();
            //StartCoroutine(ReloadShift(current_bottle.abil[2].cooldown));

        }
    }

    public bool CheckIfDefault()
    {
        if (current_bottle==player_bottle)
        {
            return true;
        }
        else
        {
            return false;
        }
                
    }

    public override void GetHit(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            //Destroy(gameObject);
            print("game over");
        }
        UIController.ui.UpdateHearts(hp);
    }

    void GetMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(h, v, 0);
        Move(movement);
    }
}
