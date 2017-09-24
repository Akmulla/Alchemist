using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public static Player player;
    //public Vector2 hit_zone;
    public LayerMask enemy_mask;
    bool reload_shift=false;

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

	void Update ()
    {
        GetMouseInput();
        GetMovement();
    }

    void GetMouseInput()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        RotateToPoint(mousePosition);

        if ((Input.GetMouseButtonDown(0))&&(!reload_1))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, tran.right, 1.5f, enemy_mask);
            //print(hit.collider);
            if (hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<Character>().GetHit(1);
            }
            StartCoroutine(Reload1(char_data.reload_1));
        }

        if ((Input.GetMouseButtonDown(1))&&(!reload_2))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, tran.right,100.0f, enemy_mask);
            //print(hit.collider);
            if (hit.collider != null)
            {
                BottleHandler.b.AddBottle(hit.collider.gameObject.GetComponent<Character>().char_data.bottle_data);
                hit.collider.gameObject.GetComponent<Character>().GetHit(1000);

                //hit.collider.gameObject.GetComponent<Character>().type
            }
            StartCoroutine(Reload2(char_data.reload_2));
        }

        if ((Input.GetKeyDown( "left shift")) && (!reload_shift))
        {

        }
    }

    public bool CheckIfDefault()
    {
        return true;
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
