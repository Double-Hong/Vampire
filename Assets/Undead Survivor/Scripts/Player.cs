using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;

    private float vertical;

    private float speed = 3.0f;

    private Animator animator;

    private SpriteRenderer sprite;

    public Scanner scanner;
    
    private AudioSource audioSource;
    
    public AudioClip levelUpClip;

    public AudioClip attackClip;
    
    public AudioClip gunFireClip;

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
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 position = new Vector3(horizontal, vertical, 0);
        transform.position += Time.deltaTime * speed * position;

        if (horizontal < 0)
        {
            sprite.flipX = true;
        }

        if (horizontal > 0)
        {
            sprite.flipX = false;
        }


        animator.SetFloat("X", horizontal);
        animator.SetFloat("Y", vertical);
        if (horizontal == 0.0f && vertical == 0.0f)
        {
            animator.SetBool("Move", false);
        }
        else
        {
            animator.SetBool("Move", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy!=null)
        {

            GameManager.instance.Hit(enemy.damage);

        }
        
    }

    public void Dead()
    {
        animator.SetBool("Dead",true);
    }

    public void PlayLevelUp()
    {
        audioSource.PlayOneShot(levelUpClip);
    }
    
    public void PlayAttack()
    {

        if (GameManager.instance.level > 3)
        {
            audioSource.PlayOneShot(gunFireClip);
        }
        else
        {
            audioSource.PlayOneShot(attackClip);
        }
    }
}