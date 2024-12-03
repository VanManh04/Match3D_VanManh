using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    List<ItemObject> items = new List<ItemObject>();
    [SerializeField] Transform point1, point2;

    public void AddItem(ItemObject item)
    {
        if (items.Count == 0)
        {
            //neu nhan 1 item thi di chuyen den vi tri dau tien
            items.Add(item);
            item.OnMove(point1.position, Quaternion.identity, 0.2f);
            item.SetKinematic(true);
        }
        else if (items.Count == 1)
        {
            //neu nhan item thu 2 thi di chuyen den vi tri thu 2
            //item.Type == items[0].Type ||
            if (item.id_Object == items[0].id_Object)
            {
                //check neu la cung loai thi collect
                items.Add(item);
                item.OnMove(point2.position, Quaternion.identity, 0.2f);
                item.SetKinematic(true);

                Collect();
            }
            else
            {
                //khac loai thi nem item di
                item.Force(Vector3.up * 200 + Vector3.forward * 200);
            }
        }
    }

    public void RemoveItem(ItemObject item)
    {
        items.Remove(item);
        item.SetKinematic(false);
    }

    private void Collect()
    {
        foreach (ItemObject item in items)
            LevelManager.Ins.RemoveItemObject_ListItemInScene(item);

        items[0].Collect();
        items[1].Collect();
        items.Clear();
    }
}
