using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int currentHealth { get; private set; }
    public int maxHealth = 100;
    public int attackDamage = 10;
    public Animator animator;

    public Stat damage;
    public Stat armor;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage (int damage)
    {
        animator.SetTrigger("Hurt");
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        animator.SetBool("IsDead", true);
        Debug.Log(transform.name + " died");

        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }
}
