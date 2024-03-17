using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;

using UnityEngine;


public class hordas : MonoBehaviour
{   public ValoresEnemigos[] hordasEnemigos;
    private ValoresEnemigos enemigoActual;
    float tiempoEspera = 10f;
    public int numHordaActual=0;
    int enemigosPorCrear;
    int enemigosPorMatar;
    // Start is called before the first frame update
    void Start()
    {   numHordaActual = 0;
        nextHorda();
        EnemigoMovimiento.onDeathEnemy.AddListener(enemigoMuerto);
    }

    void enemigoMuerto()
    {
        enemigosPorMatar--;
        if(enemigosPorMatar <= 0 )
        {
            nextHorda();
        }
        if(numHordaActual >= hordasEnemigos.Length)
        {   
            // if(PlayerPrefs.GetInt("level") == 1)
            // {
            //     UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
            // }
            // else
            // {
            // UnityEngine.SceneManagement.SceneManager.LoadScene("WIn");}
        }
    }

    void nextHorda()
    {   if(numHordaActual >= hordasEnemigos.Length)
        {   //carga la siguiente escena
            return;
        }
        numHordaActual++;
        enemigoActual = hordasEnemigos[numHordaActual-1];
        enemigosPorCrear = enemigoActual.numeroEnemigos;
        enemigosPorMatar = enemigoActual.numeroEnemigos;
    }



    // Update is called once per frame
    void Update()
    {
        if(enemigosPorCrear > 0 && tiempoEspera <= 0){
            Vector3 pos = Vector3.zero; // Initialize pos with a default value
            switch(numHordaActual){
                case 1:
                    pos = GameObject.FindGameObjectWithTag("Spawn1").transform.position;
                    break;
                case 2:
                    pos = GameObject.FindGameObjectWithTag("Spawn2").transform.position;
                    break;
                case 3:
                    pos = GameObject.FindGameObjectWithTag("Spawn3").transform.position;
                    break;
                case 4:
                    pos = GameObject.FindGameObjectWithTag("Spawn4").transform.position;
                    break;
            }
        
        Instantiate(enemigoActual.tipoEnemigo,pos,Quaternion.identity);
        enemigosPorCrear--;
        tiempoEspera = enemigoActual.tiempoEntreEnemigos;
        }
        else
        {
            tiempoEspera -= Time.deltaTime;
        }
        
    }

    void OnDestroy()
    {
        EnemigoMovimiento.onDeathEnemy.RemoveListener(enemigoMuerto);
    }
}
