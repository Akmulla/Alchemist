using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { None, Simple, Bomber};
public class BottleHandler : MonoBehaviour
{
    public static BottleHandler b;
    List<BottleData> bottle;

    void Awake()
    {
        b = this;
    }
    void Start()
    {
        bottle = new List<BottleData>();
    }


    public void AddBottle(BottleData type)
    {
        if (bottle.Count >= 8)
            bottle.RemoveAt(7);
        bottle.Add(type);
    }

    public void RemoveBottle(BottleData data)
    {
        bottle.Remove(data);
    }

    public List<BottleData> GetBottles()
    {
        return bottle;
    }
}
