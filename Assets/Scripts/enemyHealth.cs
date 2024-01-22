 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{

    public float enemyMaxHealth;

    public GameObject enemyDeathFX;

    public bool drops;
    public GameObject theDrop;

    float curruntHealth;


    // Start is called before the first frame update
    void Start()
    {
        curruntHealth = enemyMaxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //how much damage does it do to the object
    public void addDamage(float damage)
    {
        curruntHealth -= damage;
        if(curruntHealth <= 0)
        {
            makeDead();
        }
    }

    void makeDead()
    {
        Destroy(gameObject);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);

        if (drops) Instantiate(theDrop, transform.position, transform.rotation);

    }
}
