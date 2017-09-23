using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { None, Simple, Bomber};
public class BottleHandler : MonoBehaviour
{
    EnemyType[] bottle;

    void Start()
    {
        bottle = new EnemyType[2];
    }

    public void ClearBottles()
    {
        bottle[0] = EnemyType.None;
        bottle[1] = EnemyType.None;
    }

    public void GetInBottle(EnemyType type)
    {

    }
}
