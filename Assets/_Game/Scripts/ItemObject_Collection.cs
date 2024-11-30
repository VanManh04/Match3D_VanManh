using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Object Collection", menuName = "Data/ItemObject_Collection")]
public class ItemObject_Collection : ScriptableObject
{
    [SerializeField] private bool unLock;
 //   [SerializeField] private List<ItemObject> itemObjects = new List<ItemObject>();
}
