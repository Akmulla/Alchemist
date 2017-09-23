using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public static Player player;
    //public Vector2 hit_zone;
    public LayerMask enemy_mask;

    protected override void Awake()
    {
        base.Awake();
        player = this;
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

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, tran.right, 1.5f, enemy_mask);
            //print(hit.collider);
            if (hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<Character>().GetHit(1);
            }
            
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, tran.right,100.0f, enemy_mask);
            //print(hit.collider);
            if (hit.collider != null)
            {
                
                hit.collider.gameObject.GetComponent<Character>().GetHit(1000);
                //hit.collider.gameObject.GetComponent<Character>().type
            }

        }
    }

    void GetMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(h, v, 0);
        Move(movement);
    }
}
