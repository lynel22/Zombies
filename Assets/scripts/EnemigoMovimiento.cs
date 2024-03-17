using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class EnemigoMovimiento : LivingEntity
{   
    // Start is called before the first frame update
    UnityEngine.AI.NavMeshAgent pathfinder;
    
    shoot sh;
    

    Transform objetivo;
    void Start()
    {   base.Start();
        objetivo= GameObject.FindGameObjectWithTag("Player").transform;
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
        
        
    }


    // Update is called once per frame
    void Update()
    {
        pathfinder.SetDestination(objetivo.position);
    }

    private void OnDestroy()
    {

    }
}
