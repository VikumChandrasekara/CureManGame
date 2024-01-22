using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour
{
    public float bulletDamage;

    projectileController myPC;

    public GameObject explotionEffect;

    // Start is called before the first frame update
    void Awake()
    {
        //cam acess any public scripts from here 
        myPC = GetComponentInParent<projectileController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when bullet collider collides with a another collider it'll show up here
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            Instantiate(explotionEffect, transform.position, transform.rotation);
            Destroy(gameObject);    
            if(other.tag == "Enemy")
            {
                //look for the enemy health script
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(bulletDamage);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            Instantiate(explotionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.tag == "Enemy")
            {
                //look for the enemy health script
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(bulletDamage);
            }
        }

    }

}
 