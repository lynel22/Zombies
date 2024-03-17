using System;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeArma : MonoBehaviour
{
    
    public int armaActualIndex = 0; // Índice del arma actual

    public GameObject[] armas; 
    public bool[] armasActivas;

    private void OnTriggerEnter(Collider other)
    {    int armaNuevaIndex=0;
        // Comprueba si el objeto con el que colisionamos es un arma
        if (other.gameObject.layer == LayerMask.NameToLayer("Armas"))
        {  
            switch (other.gameObject.tag)
            {
                case "ak47":
                    armaNuevaIndex = 1;
                    break;
                case "shot":
                    armaNuevaIndex = 2;
                    break;
                case "M4":
                    armaNuevaIndex = 0;
                    break;
            }
            armasActivas[armaNuevaIndex] = true;
            armas[armaNuevaIndex].SetActive(true);
            armas[armaActualIndex].SetActive(false);
            armaActualIndex = armaNuevaIndex;
            Destroy(other.gameObject);
        }

    }

    private void Update()
    {
        if(Input.GetKeyDown(/*tecla e*/ KeyCode.E))
        {
            CambiarArma();
            // sonido de cambio de arma

        }
    }

    private void CambiarArma()
    {
        int nuevaArmaIndex = (armaActualIndex + 1) % 3;
        while(!armasActivas[nuevaArmaIndex])
        {
            nuevaArmaIndex = (nuevaArmaIndex + 1) % 3;
        }
        armas[armaActualIndex].SetActive(false);
        armas[nuevaArmaIndex].SetActive(true);
        armaActualIndex = nuevaArmaIndex;
        
    }

    private void Start()
    {
        armasActivas = new bool[] { true, false, false };
    }
}