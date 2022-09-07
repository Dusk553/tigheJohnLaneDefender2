using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    [SerializeField]
    private EnemyData EnemyData;
    public GameObject[] spawnpoint;
    public GameObject[] chooseMob;
    private int index;
    private int mob;
    private float timer = 1;

    // Update is called once per frame
    void Update()
    {
        timer -= 1 * Time.deltaTime;

        if (timer <= 0)
        {
            index = Random.Range(0, 5);
            mob = Random.Range(1, 4);
            Instantiate(chooseMob[mob], spawnpoint[index].transform.position, Quaternion.identity);
           
            timer = 3;
        }

    }
}
