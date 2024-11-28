using System.Collections.Generic;
using UnityEngine;

public class CloneObjectManager : MonoBehaviour
{
    [SerializeField] private int countCupleObject;
    [SerializeField] private List<ObjectGame> listObjects;
    [SerializeField] private BoxCollider boxRandomSpawn;
    void Start()
    {
        //if (countObject % 2 != 0)
        //    Debug.LogError("Count % 2 != 0");

        int random_Index;
        ObjectGame objectGame;
        //for (int i = 0; i < countCupleObject; i++)
        for (int i = 0; i < countCupleObject / 2; i++)
        {
            random_Index = Random.Range(0, listObjects.Count);
            //do
            //{
            //    random_Index = Random.Range(0, listObjects.Count);
            //    Debug.Log(random_Index);
            //} while (listObjects[random_Index].isLock);

            objectGame = Instantiate(listObjects[random_Index], GetRandomPointInBox(boxRandomSpawn), Quaternion.identity);
            objectGame.id = random_Index;
            ComparisonTable.instance.AddObjectToListObjectInScene(objectGame);

            objectGame = Instantiate(listObjects[random_Index], GetRandomPointInBox(boxRandomSpawn), Quaternion.identity);
            objectGame.id = random_Index;
            ComparisonTable.instance.AddObjectToListObjectInScene(objectGame);
        }
    }

    void Update()
    {
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
