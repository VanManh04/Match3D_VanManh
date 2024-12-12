using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Object Collection", menuName = "Data/Item Object Collection")]
public class ItemObjectCollection : ScriptableObject
{
    private bool canAddItem;
    //s? d?ng enum thay cho prefabs
    [SerializeField] private List<ItemObject> items = new List<ItemObject>();
    [SerializeField] private List<ItemType> itemTypes = new List<ItemType>();

    public void AddUnLock(ItemObject item) => items.Add(item);
    public List<ItemObject> GetListItemClone()=> items;

    [ContextMenu("ResetList")]
    public void ResetList()
    {
        ItemObject itemObject = items[0];
        items.Clear();
        items.Add(itemObject);
        canAddItem = false;
    }

    public bool GetCanAddItem() => canAddItem;
    public void SetCanAddItem(bool _bool) => canAddItem = _bool;
}