using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class VidaPLayer : LivingEntity

{   private float damage=25f;
    public ProgressBar healthBar;
    // Start is called before the first frame update
    void Start()
    {   base.Start();
        healthBar.BarValue = 100;


    }

    private bool canAttack = true; // Variable para controlar si el jugador puede atacar
    private float attackCooldown = 1f; // Tiempo de espera entre ataques
    private float lastAttackTime; // Registro del tiempo del último ataque
    public Image panelRojo; // Referencia al panel rojo

    private void OnTriggerEnter(Collider other)
    {   
        // Verifica si el collider con el que hemos colisionado pertenece a la capa 7
        if (other.gameObject.layer == 7 && canAttack)
        {
            // Verifica las etiquetas del objeto con el que hemos colisionado
            if(other.gameObject.tag == "Zombie1")
            {
                damage = 20f;
            }
            else if(other.gameObject.tag == "Zombie2")
            {
                damage = 25f;
            }


            // Aplica el daño al jugador y actualiza la barra de salud
            TakeDamage(damage);
            healthBar.BarValue = health;

            // Desactiva la capacidad de atacar y registra el tiempo del último ataque
            canAttack = false;
            lastAttackTime = Time.time;

            if (health <= 0)
            {
                StartCoroutine(FadeInPanelRojo());
            }   

            // Inicia una corutina para reactivar la capacidad de atacar después del tiempo de espera
            StartCoroutine(ResetAttack());
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
        SceneManager.LoadScene("Muerte");
    }

    private IEnumerator ResetAttack()
    {
        // Espera el tiempo de espera antes de permitir otro ataque
        yield return new WaitForSeconds(attackCooldown);

        // Activa la capacidad de atacar
        canAttack = true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
