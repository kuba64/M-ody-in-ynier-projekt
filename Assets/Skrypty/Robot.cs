using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {
    Rigidbody2D rb;
    public bool played, grounded;
    public float speed=1f, newSpeed;

    public Transform groundCheck;
    float groundRadius = 0.02f;
    public LayerMask whatIsGround;

    bool red, blok;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    public void Move()
    {
        rb.velocity = new Vector2(3 * speed, rb.velocity.y);
    }
    public void Jump(int jumpForce)
    {
        if (grounded)
            rb.AddForce(new Vector2(0, jumpForce));
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag=="RedBlok")
        {
            red = true;
        }

        if (coll.tag == "Blok")
        {
            blok = true;
        }

        if (coll.tag == "Finish")
        {
           // played = false;
            GM.instance.Finish();
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "RedBlok")
        {
            red = false;
        }
        if (coll.tag == "Blok")
        {
            blok = false;
        }
    }

    public void CzujnikObiektu(int[] obt, int[] czy)
    {
        //obiekty
        for (int i = 0; i < obt.Length; i++)
        {
            switch(i)
            {
                case 2: //red
                    if(obt[i]==1)
                    {
                        if (red)
                            Czynnosci(czy);
                    }
                    break;

                case 1: //blok
                    if (obt[i] == 1)
                    {
                        if (blok)
                            Czynnosci(czy);
                    }
                    break;
            }
        }
    }

    void Czynnosci(int[] czy)
    {
        for (int i = 0; i < czy.Length; i++)
        {
            switch(i)
            {
                case 3: //move
                    if (czy[i] == 1)
                    {
                        Move();
                    }
                    break;

                case 1: //jump
                    if (czy[i] == 1)
                    {
                        Jump(100);
                    }
                    break;
                case 2: //parametr speed
                    if (czy[i] == 1)
                    {
                        SetSpeed(newSpeed);
                    }
                    break;

            }
        }
    }

    public void SetSpeed(float s)
    {
        speed = s;
    }
}
