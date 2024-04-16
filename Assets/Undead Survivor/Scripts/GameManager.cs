using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Player player;

    public float health = 100.0f;

    public static GameManager instance;

    public int kill;
    public int level;
    public int exp;
    public int[] nextExp = { 3, 5, 8, 12, 18, 27, 40, 60, 90, 135 };
    // public int[] nextExp = { 3, 3, 3, 3, 3, 3, 3, 3, 3, 384 };

    public float maxGameTime = 181;
    public float gameTime;
    public int[] enemyProbability = { 70, 20, 10, 0, 0 };
    
    public WeaponIcon weaponIcon;

    // Start is called before the first frame update


    private void Awake()
    {
        Time.timeScale = 0;
    }

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Time.timeScale = 1;
        }
    }

    public void Hit(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        player.Dead();
    }

    public void Kill(int expKill)
    {
        kill++;
        GetExp(expKill);
    }

    private void GetExp(int expKill)
    {
        exp += expKill;
        if (exp >= nextExp[Mathf.Min(level, nextExp.Length - 1)])
        {
            exp = 0;
            level++;
            ChangeProbability();
            weaponIcon.ChangeWeaponIcon(level-1);
            player.PlayLevelUp();
        }
    }

    /**
     * 随机生成敌人
     */
    public int RandomEnemy()
    {
        int totalProbability = 0;
        for (int i = 0; i < enemyProbability.Length; i++)
        {
            totalProbability += enemyProbability[i];
        }

        int random = Random.Range(0, totalProbability);
        for (int i = 0; i < enemyProbability.Length; i++)
        {
            if (random < enemyProbability[i])
            {
                return i;
            }

            random -= enemyProbability[i];
        }

        return 0;
    }

    /**
     * 改变敌人生成概率
     */
    private void ChangeProbability()
    {
        if (level <= 3)
        {
            enemyProbability[0] += level;
            enemyProbability[1] += 2 * level;
            enemyProbability[2] += 3 * level;
        }
        else if (level <= 6)
        {
            enemyProbability[0] += level;
            enemyProbability[1] += 2 * level;
            enemyProbability[2] += 3 * level;
            enemyProbability[3] += 4 * level;
        }
        else
        {
            enemyProbability[3] += 4 * level;
            enemyProbability[4] += 5 * level;
        }
        
    }
}