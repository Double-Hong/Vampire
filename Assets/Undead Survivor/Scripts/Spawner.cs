using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;

    public Transform[] spawnPoints;

    private float timer; //计时器

    private float spawnTime = 2f; //刷怪间隔

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            timer = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        int i = GameManager.instance.RandomEnemy();
        GameObject newEnemy = Instantiate(enemy[i]);
        newEnemy.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        
    
    }
}