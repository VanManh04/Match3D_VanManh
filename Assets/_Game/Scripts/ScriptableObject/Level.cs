using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Level",menuName ="Data/Level")]
public class Level : ScriptableObject
{
    [SerializeField] private int countCupleObject;
    [SerializeField] private float timer;
    [SerializeField] private List<ItemObject> items = new List<ItemObject>();

    public int GetCountCupleObject() => countCupleObject;
    public List<ItemObject> GetItems() => items;
    public float GetTimerLevel() => timer;
}
