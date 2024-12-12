using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Data/Level")]
public class LevelData : ScriptableObject
{
    [SerializeField] private int countCupleObject;
    [SerializeField] private float timer;
    [SerializeField] private ItemObjectCollection listItemClones;
    [SerializeField] private List<ItemObject> itemsUnlockIfWin = new List<ItemObject>();

    public int GetCountCupleObject() => countCupleObject;
    public float GetTimerLevel() => timer;
    public List<ItemObject> GetItems() => listItemClones.GetListItemClone();
    public List<ItemObject> GetListItemUnlockIfWin() => itemsUnlockIfWin;
    public ItemObjectCollection GetItemObjectCollection()=>listItemClones;
}
