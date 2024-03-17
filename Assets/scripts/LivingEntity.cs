using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LivingEntity : MonoBehaviour
{   
    protected float health;
    protected bool dead;
    public float startingHealth;
    public delegate void OnDeath();
    public static event OnDeath onDeathEnemy;
    public static event OnDeath onDeathPlayer;
    


    public void TakeDamage(float damage)
    {   if(damage <= 0) return;
        health -= damage;
        if(health <= 0 && !dead)
        {
            Die();
        }
    }

    public IEnumerator Desaparecer()
    {   GetComponentInChildren<Animator>().SetTrigger("Dead");
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        yield return new WaitForSeconds(3.5f);
        Destroy(gameObject);
    }

    public void Die()
    {   if(transform.tag != "Player"){
            onDeathEnemy();
            dead = true;
            StartCoroutine(Desaparecer());
        }
        else{
            onDeathPlayer();
            dead = true;
        
        }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        health = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
