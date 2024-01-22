using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerContoller : MonoBehaviour
{
    //movement variables
    public float maxSpeed;

    //jumping variables
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck; //location to build the circle
    public float jumpHeight;

    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;

    //for shooting
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if(grounded && Input.GetAxis("Jump")>0){
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));
        }

        //player shooting
        if (Input.GetAxisRaw("Fire1")>0){
            fireBullet();
        }
    }

    void FixedUpdate()
    {
        //check if we are grounded if no then we are falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        //vertical verlocity of RB
        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        //getaxis take values between -1,0,1
        float move = Input.GetAxis("Horizontal");
        //take absalute value of move
        myAnim.SetFloat("speed", Mathf.Abs(move)); 

        //take velocity to change the movements 
        myRB.velocity = new Vector2(move * maxSpeed,myRB.velocity.y);

        if(move>0 && !facingRight)
        {
            flip();
        }
        else if(move<0 && facingRight)
        {
            flip();
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        //taking the scale values
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;    
    }
    void fireBullet()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                //what / where / rotation 
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if(!facingRight){
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }
}
