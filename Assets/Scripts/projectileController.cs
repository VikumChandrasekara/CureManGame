using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{
    public float bulletSpeed;

    Rigidbody2D myRB;
    // Object first comes to life
    void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
        
        // if i have a rotation in z axis 
        if(transform.localRotation.z > 0)
        {
            //Bullet traveling on the x detection omly
            //facing left
            myRB.AddForce(new Vector2(-1, 0) * bulletSpeed, ForceMode2D.Impulse);
        }
        else
        {
            //facing right
            myRB.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void removeForce()
    {
        myRB.velocity = new Vector2(0, 0);
    }
}
