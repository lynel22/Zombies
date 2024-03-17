using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class EnemigoMovimiento : MonoBehaviour
{   
    // Start is called before the first frame update
    UnityEngine.AI.NavMeshAgent pathfinder;
    public float vida;
    shoot sh;
    public static UnityEvent onDeathEnemy;

    Transform objetivo;
    void Start()
    {   vida=100;
        objetivo= GameObject.FindGameObjectWithTag("Player").transform;
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
        sh= (shoot)objetivo.GetComponent(typeof(shoot));
        sh.onHitEnemy.AddListener(RecibeDisparo);
        
    }

    public void RecibeDisparo() {
        
        vida-=20;
        if(vida<=0) {
            DestroyImmediate(gameObject,true);
            if(onDeathEnemy != null) 
            {
                onDeathEnemy.Invoke();
            }
        }
        Debug.Log("Vida: "+vida);
    }

    // Update is called once per frame
    void Update()
    {
        pathfinder.SetDestination(objetivo.position);
    }

    private void OnDestroy()
    {
        sh.onHitEnemy.RemoveListener(RecibeDisparo);
    }
}
