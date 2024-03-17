using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;


public class hordas : MonoBehaviour
{   public ValoresEnemigos[] hordasEnemigos;
    private ValoresEnemigos enemigoActual;
    float tiempoEspera = 10f;
    public int numHordaActual=0;
    int enemigosPorCrear;
    int enemigosPorMatar;

    public Text textoRonda; // Referencia al objeto de texto
    public Text textoRondafin; // Referencia al objeto de texto

    public AudioClip sonidoRonda; // Referencia al clip de audio
    public AudioSource audioSource; // Referencia al AudioSource

    void Start()
    {   numHordaActual = 0;
        nextHorda();
        LivingEntity.onDeathEnemy += enemigoMuerto;
    }

    void enemigoMuerto()
    {
        enemigosPorMatar--;
        if(enemigosPorMatar <= 0 )
        {
            nextHorda();
        }
        // if(numHordaActual >= hordasEnemigos.Length)
        // {   
        //     if(PlayerPrefs.GetInt("level") == 1)
        //     {
        //         UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
        //     }
        //     else
        //     {
        //     UnityEngine.SceneManagement.SceneManager.LoadScene("WIn");}
        // }
    }

    void nextHorda()

    {
       if(numHordaActual >= hordasEnemigos.Length)
        {   // Todas las hordas han terminado, muestra un mensaje
            StartCoroutine(MostrarMensajeFinal());
            return;
        }
        
        numHordaActual++;
        StartCoroutine(MostrarTextoRonda());
        enemigoActual = hordasEnemigos[numHordaActual-1];
        enemigosPorCrear = enemigoActual.numeroEnemigos;
        enemigosPorMatar = enemigoActual.numeroEnemigos;
    }

    IEnumerator MostrarMensajeFinal(){
        // Actualiza el texto de la ronda y lo muestra
        textoRondafin.text = "Fin del Juego. Libertad para explorar";
        textoRondafin.enabled = true;
    
        // Reproduce el sonido de la ronda
        audioSource.PlayOneShot(sonidoRonda);

        // Espera 5 segundos
        yield return new WaitForSeconds(5f);

        // Oculta el texto de la ronda
        //textoRondafin.enabled = false;
    }

    IEnumerator MostrarTextoRonda()
    {
        // Actualiza el texto de la ronda y lo muestra
        textoRonda.text = "Ronda " + numHordaActual;
        textoRonda.enabled = true;

        // Reproduce el sonido de la ronda
        audioSource.PlayOneShot(sonidoRonda);

        // Espera 5 segundos
        yield return new WaitForSeconds(2f);

        // Oculta el texto de la ronda
        textoRonda.enabled = false;
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
        LivingEntity.onDeathEnemy -= enemigoMuerto;
    }
}
