using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPLayer : LivingEntity

{   private float damage=25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {   
        //si la capa es la 7
        if (other.gameObject.layer == 7)
        {
            if(other.gameObject.tag == "Zombie1")
            {
                damage=20f;
            }
            else if(other.gameObject.tag == "Zombie2")
            {
                damage=25f;
            }
            

            TakeDamage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
