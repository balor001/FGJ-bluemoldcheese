using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public Animator animator;
    public int currentHealth { get; private set; }
    public int maxHealth = 100;
    public UI_HealthBar healthBar;
    public int attackDamage = 10;

    public Stat damage;
    public Stat armor;

    public bool Died = false;

    private void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
        else return;
    }

    public void TakeDamage (int damage)
    {
        //animator.SetTrigger("Hurt");
        //damage -= armor.GetValue();
        Debug.Log(transform.name + " took " + damage + " amount of damage");
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
    }

    public virtual void Die()
    {
        animator.SetTrigger("Died");
        Debug.Log(transform.name + " died");

        Died = true;
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    // Killbox
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Killbox")
        {
            Debug.Log("Died");
            Die();
        }
    }
}
