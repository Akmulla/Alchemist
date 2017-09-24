using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bp;
    public Pool enemy_pool;
    public Pool player_pool;

    void Awake()
    {
        bp = this;
    }
}
