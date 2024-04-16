using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float damage = 0;

    private Rigidbody2D rigid;

    public float speed = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, GameManager.instance.player.transform.position) > 100f)
        {
            Destroy(gameObject);
        }

        if (GameManager.instance.level > 3)
        {
        }
        else
        {
            transform.Rotate(0, 0, 360 * Time.deltaTime);
        }
    }

    public void Init(float damage, Vector2 direction, float angle)
    {
        this.damage += damage;
        transform.Rotate(0, 0, angle - 90);
        if (rigid)
        {
            rigid.velocity = direction * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>() == null)
        {
            return;
        }

        if (rigid)
        {
            rigid.velocity = Vector2.zero;
        }

        Destroy(gameObject);
    }
    
}