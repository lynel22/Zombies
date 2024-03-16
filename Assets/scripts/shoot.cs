using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class shoot : MonoBehaviour
{   public float alcance = 1000000000f;
    public   UnityEvent onHitEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() {
        if (Input.GetMouseButtonDown(0))
        {  
            Disparar();
        }
    }

    void Disparar() {
        RaycastHit hit;
        //encuentra objeto con tag maincamera
        Vector3 direccionDelRayo = Camera.main.transform.forward;
        int layerMask = ~LayerMask.GetMask("Camara");
        Debug.DrawRay(transform.position, direccionDelRayo * alcance, Color.red, 2f);
        if (Physics.Raycast(transform.position,direccionDelRayo, out hit, alcance,layerMask)) {
            // El raycast ha golpeado algo
            Debug.Log("Rayo ha colisionado: " + hit.collider.gameObject.name);
            //haz el rayo rojo
            
            //si esta en la layer enemigo
            if (hit.transform.gameObject.layer == 7) {
                // El raycast ha golpeado un enemigo
                Debug.Log("Enemigo golpeado");
                if (onHitEnemy != null) // Comprueba si hay suscriptores antes de invocar el evento
                {
                    onHitEnemy.Invoke();
                }
            }
        }
    }

    

}
