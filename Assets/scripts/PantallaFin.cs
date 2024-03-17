using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PantallaFin : MonoBehaviour
{
    public Image panelRojo; // Referencia al panel rojo
    public GameObject cubo; 


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter fue llamado");

        // Comprueba si el jugador ha tocado el cubo
        if (other.gameObject == cubo)
        {
            // Inicia la coroutine para hacer que la pantalla se ponga roja de manera gradual
            StartCoroutine(FadeInPanelRojo());
        }
    }

    IEnumerator FadeInPanelRojo()
    {
        // Mientras el panel no sea completamente opaco
        while (panelRojo.color.a < 1)
        {
            // Aumenta la opacidad del panel
            Color color = panelRojo.color;
            color.a += Time.deltaTime; // Ajusta este valor para controlar la velocidad del fade in
            panelRojo.color = color;

            yield return null;
        }

        // Carga la escena de muerte
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Finjuego");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
