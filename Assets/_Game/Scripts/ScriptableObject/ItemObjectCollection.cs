using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Object Collection", menuName = "Data/Item Object Collection")]
public class ItemObjectCollection : ScriptableObject
{
    [SerializeField] private List<ItemObject> items = new List<ItemObject>();

    public void AddUnLock(ItemObject item) => items.Add(item);
    public List<ItemObject> GetListItem() => items;

    [ContextMenu("ResetList")]
    public void ResetList()
    {
        ItemObject itemObject = items[0];
        items.Clear();
        items.Add(itemObject);
    }
}