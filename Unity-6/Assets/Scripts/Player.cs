using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    public int movementspeed;
    public int jumppower;
    public float groundCheckRadius;

    private bool onGround;
    private int facing;

    public int coins;

    public bool moveright;
    public bool moveleft;

    public float startx;
    public float starty;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facing = 1;
        startx = transform.position.x;
        starty = transform.position.y;
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || moveleft)
        {
            rb.velocity = new Vector2(-movementspeed, rb.velocity.y);
            anim.SetBool("Walking", true);

            if(facing == 1)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                facing = 0;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) || moveright)
        {
            rb.velocity = new Vector2(movementspeed, rb.velocity.y);
            anim.SetBool("Walking", true);

            if(facing == 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                facing = 1;
            }
        }  else
        {
            anim.SetBool("Walking", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            jump();
        }

    }

    private void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }


    public void jump()
    {
        if(onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumppower);
        }
    }

    public void Death()
    {
        StartCoroutine("respawndelay");
    }

    public IEnumerator respawndelay()
    {
        enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(1);

        transform.position = new Vector2(startx, starty);
        GetComponent<Renderer>().enabled = true;
        enabled = true;
    }
}
