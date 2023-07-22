using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnerController : MonoBehaviour
{
    public float spawnDelay = 1f;
    WaitForSeconds wfs;
    public float Timer = 0f;
    public MonsterController latestSpawnMonster;
    void Start()
    {

    }
    void Update()
    {

    }
    public void SpawnMonster(string name, int count, float delay)
    {
        spawnDelay = delay;
        for (int i = 0; i < count; i++)
        {
            GameObject go = Managers.Resource.Instantiate($"Creature/Monster/{name}");
            float randX = Random.Range(1, 3);
            if (randX == 1)
                randX = -20;
            else
                randX = 20;
            go.transform.position = new Vector3(randX, 1, 1);
            MonsterController monster = go.GetComponent<MonsterController>();
            Managers.Game.monsters.Add(monster);
            if (i == 0)
            {
                monster.State = Define.CreatureState.Moving;
                Debug.Log("처음 몬스터 움직임");
            }
            else
            {
                if (i > 1)
                    spawnDelay += spawnDelay;
                monster.MovingDelay = spawnDelay;
            }
        }
    }
}
