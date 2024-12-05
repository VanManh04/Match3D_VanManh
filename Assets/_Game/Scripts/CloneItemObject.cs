using System.Collections.Generic;
using UnityEngine;

public class CloneItemObject : MonoBehaviour
{
    [SerializeField] private int countCupleObject;
    [SerializeField] private List<ItemObject> listObjects;
    [SerializeField] private BoxCollider boxRandomSpawn;

    private void OnValidate()
    {
        gameObject.name = "CloneItemObject";
        boxRandomSpawn = GetComponent<BoxCollider>();
    }
    void Start()
    {
        OnInit();
    }

    private void OnInit()
    {

        int random_Index;
        ItemObject objectGame;

        for (int i = 0; i < countCupleObject; i++)
        {
            random_Index = Random.Range(0, listObjects.Count);

            objectGame = Instantiate(listObjects[random_Index], GetRandomPointInBox(boxRandomSpawn), Quaternion.identity);
            objectGame.id_Object = random_Index;
            LevelManager.Ins.AddItemObject_ListItemInScene(objectGame);

            objectGame = Instantiate(listObjects[random_Index], GetRandomPointInBox(boxRandomSpawn), Quaternion.identity);
            objectGame.id_Object = random_Index;
            LevelManager.Ins.AddItemObject_ListItemInScene(objectGame);
        }
        Destroy(this.gameObject);
    }

    public void SetUpData(List<ItemObject> _listObjects,int _countCupleObject)
    {
        countCupleObject = _countCupleObject;
        listObjects = _listObjects;
    }

    private Vector3 GetRandomPointInBox(BoxCollider box)
    {
        Vector3 center = box.center + box.transform.position;
        Vector3 size = box.size;
        Vector3 randomPosition = new Vector3(
            Random.Range(center.x - size.x / 2, center.x + size.x / 2),
            //Random.Range(center.y - size.y / 2, center.y + size.y / 2),
            center.y,
            Random.Range(center.z - size.z / 2, center.z + size.z / 2)
        );
        return randomPosition;
    }
}