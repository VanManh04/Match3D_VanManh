using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Object Collection", menuName = "Data/Item Object Collection")]
public class ItemObjectCollection : ScriptableObject
{
    [SerializeField] private List<ItemObject> items = new List<ItemObject>();
}