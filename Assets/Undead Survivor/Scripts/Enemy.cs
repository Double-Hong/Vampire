using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;

    private Animator animator;

    private SpriteRenderer sprite;

    public float damage = 10.0f;

    public float health = 10f;

    public int exp = 1;
    
    private AudioSource audioSource;
    
    public AudioClip DeadClip;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.health <= 0)
        {
            return;
        }

        Vector3 inputVec = (GameManager.instance.player.transform.position - transform.position).normalized;

        transform.position += Time.deltaTime * speed * inputVec;

        if (inputVec.x != 0)
            sprite.flipX = inputVec.x < 0;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Bullet"))
        {
            return;
        }

        health -= col.GetComponent<Bullet>().damage;

        if (health > 0)
        {
            animator.SetTrigger("Hit");
        }
        else
        {
            animator.SetBool("Dead", true);
            Dead();
            GameManager.instance.Kill(exp);
        }
    }
    
    void Dead()
    {
        audioSource.PlayOneShot(DeadClip);
        Destroy(gameObject, 0.5f);
        enabled = false;
    }
}