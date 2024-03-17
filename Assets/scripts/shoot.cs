using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class shoot : MonoBehaviour
{   public float alcance = 1000000000f;
    public   UnityEvent onHitEnemy;
    float damage;
    private CambioDeArma cambioDeArma;
    private float timebetweenShots=0.0f;
    private float timeLastShot=0.0f;
    // Start is called before the first frame update
    void Start()
    {   cambioDeArma = GetComponent<CambioDeArma>();
        damage=20;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && Time.time > timeLastShot + timebetweenShots)
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
                
                switch(cambioDeArma.armaActualIndex){
                    case 0: //m4
                        damage=20;
                        timebetweenShots= 0.4f;
                        break;
                    case 1://ak47
                        damage=25;
                        timebetweenShots= 0.5f;
                        break;
                    case 2://shot
                        float distancia = Vector3.Distance(hit.transform.position, gameObject.transform.position);
                        damage=125 * (1-distancia/50);
                        Debug.Log(damage+" de daño a "+distancia+" metros");
                        timebetweenShots= 2.5f;
                        break;
                }
                timeLastShot=Time.time;
                hit.transform.GetComponent<LivingEntity>().TakeDamage(damage);
            }
        }
    }

    

}
