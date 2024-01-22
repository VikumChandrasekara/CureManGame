using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public float damage;
    public float damageRate;
    public float pushBackForce;

    float nextDamage;
    // Start is called before the first frame update
    void Start()
    {
        nextDamage = 0f; // character can damage immediately
    }
     
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && nextDamage <Time.time)
        {
            playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth>(); //player health script reference
            thePlayerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;

            pushBack(other.transform);
        }
    }

    void pushBack(Transform pushedObject)
    {
        Vector2 pushDerection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDerection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDerection, ForceMode2D.Impulse); 
    }
}
