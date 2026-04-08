using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    IEnumerator GetDamage(int damage)
    {
        currentHealth-=damage;
        animator.SetBool("isDamage", true);
        Physics2D.IgnoreLayerCollision(3, 6, true);
        yield return new WaitForSeconds(2);

        animator.SetBool("isDamage", false);
        Physics2D.IgnoreLayerCollision(3, 6, false);

    }

    public void ReceiveDamage(int damage)
    {
        if (currentHealth > 1)
        {
            StartCoroutine(GetDamage(damage));
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
