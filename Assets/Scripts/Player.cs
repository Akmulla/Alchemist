using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : Character
{
    public GameObject explosive_bullet;
    public GameObject sayan;
    public GameObject explosion_circle_player;
    public Animator anim;
    //public Transform shot_spawn;
    public GameObject flying_bottle;
    public SpriteRenderer sprite_rend;
    public static Player player;
    //public Vector2 hit_zone;
    public LayerMask enemy_mask;
    bool reload_shift=false;
    public BottleData current_bottle;
    public BottleData player_bottle;
    List<EnemyType> passive_abil;
    bool charge = false;
    bool invincible = false;


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
        invincible = false;
        passive_abil = new List<EnemyType>();
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
        speed = bottle.speed;
        if (!CheckIfDefault())
        {
            hp++;
            
            for (int i=0;i<bottle.abil.Length;i++)
            {
                if (bottle.abil[i].ability_type==AbilityType.Passive)
                {
                    passive_abil.Add(bottle.abil[i].enemy_type);
                }
            }
            StartCoroutine(DrinkCor());
        }
        else
        {
            passive_abil.Clear();
        }
    }


    IEnumerator DrinkCor()
    {
        anim.enabled = false;
        yield return new WaitForSeconds(10.0f);
        anim.enabled = true;
        DrinkBottle(player_bottle);
    }

	void Update ()
    {
        if (GameController.gc.State==GameState.Game)
        {
            if (!charge)
            {
                GetMouseInput();
                GetMovement();
            }
           
        }
        
    }

    void Attack1()
    {
        RaycastHit2D hit;
        switch (current_bottle.abil[0].enemy_type)
        {
            case EnemyType.None:
                anim.SetTrigger("Attack");
                StartCoroutine(Sword());
                
                break;

            case EnemyType.Simple:
                //anim.SetTrigger("Attack");
                StartCoroutine(Sword());

                ////anim.SetTrigger("Attack");
                //hit = Physics2D.Raycast(transform.position, tran.right, 1.5f, enemy_mask);
                ////print(hit.collider);
                //if (hit.collider != null)
                //{
                //    hit.collider.gameObject.GetComponent<Character>().GetHit(1);
                //}
                break;

            case EnemyType.Bomber:
                Instantiate(explosion_circle_player, tran.position, Quaternion.identity);
                break;

            case EnemyType.Shooter:
                if (passive_abil.Contains(EnemyType.Bomber))
                {
                    Instantiate(explosive_bullet, tran.position, tran.rotation);
                }
                else
                {
                    if (passive_abil.Contains(EnemyType.Simple))
                    {
                        BulletPool.bp.player_pool.Activate(tran.position + tran.up * 0.1f, tran.rotation);
                        BulletPool.bp.player_pool.Activate(tran.position - tran.up * 0.1f, tran.rotation);
                    }
                    else
                    {
                        BulletPool.bp.player_pool.Activate(tran.position, tran.rotation);
                    }
                }




                break;

            case EnemyType.Charge:
                StartCoroutine(Charge());
                break;
        }
    }

    IEnumerator Charge()
    {
        //charge = true;
        //speed += 10.0f;
        //yield return new WaitForSeconds(3.0f);
        //speed -= 10.0f;
        //charge = false;
        charge = true;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        RotateToPoint(mousePosition);
        speed = 10.0f;
        mousePosition.z = 0.0f;

        //Vector3 movement = mousePosition - tran.position;
        //Move(movement);
        for (int i = 0; i < 10; i++)
        {
            transform.position = Vector3.Lerp(tran.position, mousePosition, 0.1f);
            yield return new WaitForSeconds(0.01f);
        }
        
        yield return new WaitForSeconds(0.2f);
        speed = current_bottle.speed;

        charge = false;
    }

    IEnumerator Sword()
    {

        //yield return new WaitForSeconds(0.3f);
        sayan.SetActive(true);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, tran.right, 2.5f, enemy_mask);
        //print(hit.collider);
        if (hit.collider != null)
        {
            hit.collider.gameObject.GetComponent<Character>().GetHit(1);
        }
        yield return new WaitForSeconds(0.3f);
        sayan.SetActive(false);
    }

    IEnumerator Throw()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(flying_bottle, tran.position, tran.rotation);
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
                anim.SetTrigger("Throw");
                StartCoroutine(Throw());

                break;

            case EnemyType.Simple:
                //anim.SetTrigger("Attack");
                StartCoroutine(Sword());
                //RaycastHit2D hit = Physics2D.Raycast(transform.position, tran.right, 1.5f, enemy_mask);
                ////print(hit.collider);
                //if (hit.collider != null)
                //{
                //    hit.collider.gameObject.GetComponent<Character>().GetHit(1);
                //}
                break;

            case EnemyType.Bomber:
                Instantiate(explosion_circle_player, tran.position, Quaternion.identity);
                break;

            case EnemyType.Shooter:
                BulletPool.bp.player_pool.Activate(tran.position, tran.rotation);
                break;

            case EnemyType.Charge:
                StartCoroutine(Charge());
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
        if (charge)
            return;
        if (invincible)
            return;
        hp -= damage;
        
        if (hp <= 0)
        {

            StartCoroutine(gameover());
        }
        UIController.ui.UpdateHearts(hp);
    }
    IEnumerator gameover()
    {
        soundmanager.sound_manager.SingleSound(SoundSample.die_player);
        //Destroy(gameObject);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("MainScene");
    }
    void GetMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(h, v, 0);
        Move(movement);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        sayan.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if ((charge)&&(coll.gameObject.tag == "Enemy"))
        {
            coll.gameObject.GetComponent<Character>().GetHit(3);
            //Destroy(gameObject);
            // pool_ref.GetPool().Deactivate(gameObject);
        }
    }

    IEnumerator GetShield()
    {
        invincible = true;
        yield return new WaitForSeconds(1.0f);
        invincible = false;
    }
}
