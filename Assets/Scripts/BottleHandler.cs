using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { None, Simple, Bomber};
public class BottleHandler : MonoBehaviour
{
    public static BottleHandler b;
    List<EnemyType> bottle;

    void Awake()
    {
        b = this;
    }
    void Start()
    {
        bottle = new List<EnemyType>();
    }

    public void ClearBottles()
    {
        bottle[0] = EnemyType.None;
        bottle[1] = EnemyType.None;
    }

    public void GetInBottle(EnemyType type)
    {
        if (bottle.Count >= 8)
            bottle.RemoveAt(7);
        bottle.Add(type);
    }

    public List<EnemyType> GetBottles()
    {
        return bottle;
    }
}
