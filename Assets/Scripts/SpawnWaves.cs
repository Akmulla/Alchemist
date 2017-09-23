using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWaves : MonoBehaviour
{
    public Pool[] pool;
    public Transform[] spawn_point;

    void Start()
    {
        pool = GetComponentsInChildren<Pool>();
        StartCoroutine(SpawnCor(0.8f));
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
            }
            yield return new WaitForSeconds(delay);
        }
        
    }
}
