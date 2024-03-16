using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovimiento : MonoBehaviour
{
    // Start is called before the first frame update
    UnityEngine.AI.NavMeshAgent pathfinder;
    Transform objetivo;
    void Start()
    {
        objetivo= GameObject.FindGameObjectWithTag("Player").transform;
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        pathfinder.SetDestination(objetivo.position);
    }
}
