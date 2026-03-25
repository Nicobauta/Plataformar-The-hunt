using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator _anim;
    public float speed = 5f;

    private bool isDead = false;
    private float inputX;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDead)
        {
            HandleMovement();
            HandleAnimation();
        }
    }

    void HandleMovement()
    {
        inputX = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * inputX * speed * Time.deltaTime);
    }

    void HandleAnimation()
    {
        _anim.SetBool("isMoving", inputX != 0);
    }

    public void Die()
    {
        isDead = true;
        _anim.SetTrigger("Death");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Die();
        }
         //
    }
}