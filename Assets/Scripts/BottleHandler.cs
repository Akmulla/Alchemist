using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { None, Simple, Bomber};
public class BottleHandler : MonoBehaviour
{
    public static BottleHandler b;
    List<CharData> bottle;

    void Awake()
    {
        b = this;
    }
    void Start()
    {
        bottle = new List<CharData>();
    }

    //public void ClearBottles()
    //{
    //    bottle[0] = EnemyType.None;
    //    bottle[1] = EnemyType.None;
    //}

    public void GetInBottle(CharData type)
    {
        //if (bottle.Count >= 8)
        //    bottle.RemoveAt(7);
        if (bottle.Count <= 8)
            bottle.Add(type);
    }

    public List<CharData> GetBottles()
    {
        return bottle;
    }
}
