using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Levels
{

}
public class SpawnWaves : MonoBehaviour
{
    [HideInInspector]
    public Pool[] pool;
    public Transform[] spawn_point;
    public float spawn_delay;

    void Start()
    {
        pool = GetComponentsInChildren<Pool>();

        StartCoroutine(SpawnCor());
    }

    IEnumerator ChngSpawnDelay()
    {
        yield return new WaitForSeconds(60.0f);
        while (spawn_delay>=1.0f)
        {
            spawn_delay -= 0.1f;
            yield return new WaitForSeconds(20.0f);
        }
    }

	IEnumerator SpawnCor()
    {
        float start = Time.time;
        while (true)
        {
            if (GameController.gc.State==GameState.Game)
            {
                int pool_ind = 0;
                if (Time.time-start>10.0f)
                    pool_ind = 0;

                if (Time.time - start > 20.0f)
                    pool_ind = Random.Range(0, 2);

                if (Time.time - start > 40.0f)
                    pool_ind = Random.Range(0, 3);

                if (Time.time - start > 60.0f)
                    pool_ind = Random.Range(0, 4);

                Vector3 pos = spawn_point[Random.Range(0, spawn_point.Length)].position;

                pool[pool_ind].Activate(pos, Quaternion.identity);
                //GameController.gc.enemy_spawned++;
            }



            yield return new WaitForSeconds(spawn_delay);
        }
        
    }
}
