using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    List<ItemObject> items = new List<ItemObject>();
    [SerializeField] Transform point1, point2;

    [SerializeField] private List<ParticleSystem> VFXs;
    private ParticleSystem VFXCollect;
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

                Invoke(nameof(Collect), .4f);
            }
            else
            {
                //khac loai thi nem item di
                item.Force(Vector3.up * 200 + Vector3.forward * 200);
            }
        }else
        {
            item.OnDrop();
            item.Force(Vector3.up * 200 + Vector3.forward * 200);
        }
    }

    public void RemoveItem(ItemObject item)
    {
        items.Remove(item);
        item.SetKinematic(false);
    }

    private void Collect()
    {
        StartCoroutine(CollectItem());

        VFXCollect = VFXs[Random.Range(0, VFXs.Count)];
        //add tranform thay v? trí VFX
        items[0].OnMove(VFXCollect.gameObject.transform.position, Quaternion.identity, .5f);
        items[1].OnMove(VFXCollect.gameObject.transform.position, Quaternion.identity, .5f);
    }

    private IEnumerator CollectItem()
    {

        yield return new WaitForSeconds(.5f);

        VFXCollect.Play();
        items[0].Collect();
        items[1].Collect();

        foreach (ItemObject item in items)
            LevelManager.Ins.RemoveItemObject_ListItemInScene(item);
        items.Clear();
    }

    public void OnInit()
    {
        items.Clear();
    }
}
