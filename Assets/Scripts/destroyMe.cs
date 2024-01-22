using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyMe : MonoBehaviour
{
    public float aliveTime;

    // Start is called before the first frame update
    void Awake()
    {
        //Destroy whatever the compenent (game object) that this scrip is on
        Destroy(gameObject, aliveTime);
    }
     
    // Update is called once per frame
    void Update()
    {
        
    }
}
