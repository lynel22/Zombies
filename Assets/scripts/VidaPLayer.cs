using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        // Inicia una corutina para reactivar la capacidad de atacar después del tiempo de espera
        StartCoroutine(ResetAttack());
    }
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
