using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject[] bullet;

    private float timer; //计时器

    private float fireTime = 1.0f; //发射间隔

    public float damage = 5f; //武器伤害

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > fireTime)
        {
            timer = 0;
            Fire();
        }
    }

    private void Fire()
    {
        if (player.scanner.nearestTransform == null)
        {
            return;
        }
        GameManager.instance.player.PlayAttack();
        Vector3 dir = player.scanner.nearestTransform.position - transform.position;
        dir = dir.normalized;
        float angle = (float)(Mathf.Atan2(dir.y, dir.x) * 180 / Math.PI);
        GameObject newBullet;
        if (GameManager.instance.level == 0)
        {
            newBullet = Instantiate(bullet[0]);
        }
        else
        {
            if (GameManager.instance.level<=5)
            {
                newBullet = Instantiate(bullet[GameManager.instance.level-1]);
            }
            else
            {
                newBullet = Instantiate(bullet[5]);
            }
            
        }
        
        newBullet.transform.position = transform.position;
        newBullet.GetComponent<Bullet>().Init(damage,dir,angle);
    }
}