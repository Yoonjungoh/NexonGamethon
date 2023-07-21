using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnerController : MonoBehaviour
{
    public float spawnDelay = 1f;
    WaitForSeconds wfs;
    void Start()
    {
        wfs = new WaitForSeconds(spawnDelay);
        StartCoroutine(CoSpawnMonster());
    }
    IEnumerator CoSpawnMonster()
    {
        yield return wfs;
        GameObject go = Managers.Resource.Instantiate("Creature/Monster/Monster");
        float randX = Random.Range(1, 3);
        if (randX == 1)
            randX = -20;
        else
            randX = 20;
        go.transform.position = new Vector3(randX, 1, 1);
        StartCoroutine(CoSpawnMonster());
    }
}
