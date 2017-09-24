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
        StartCoroutine(SpawnCor(spawn_delay));
    }

	IEnumerator SpawnCor(float delay)
    {
        while (true)
        {
            if (GameController.gc.State==GameState.Game)
            {
                int pool_ind = Random.Range(0, pool.Length);
                Vector3 pos = spawn_point[Random.Range(0, spawn_point.Length)].position;

                pool[pool_ind].Activate(pos, Quaternion.identity);
                //GameController.gc.enemy_spawned++;
            }
            yield return new WaitForSeconds(delay);
        }
        
    }
}
