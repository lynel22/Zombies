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
        
        // LivingEntity.onDeathEnemy += Morir;
        
    }
    // void Morir()
    // {
    //     GetComponentInChildren<Animator>().SetTrigger("Dead");
    //     pathfinder.enabled = false;
    // }


    // Update is called once per frame
    void Update()

    {   
        if(pathfinder.enabled)
        {
            pathfinder.SetDestination(objetivo.position);
        }
    }

    private void OnDestroy()
    {
        // LivingEntity.onDeathEnemy -= Morir;
    }
}
