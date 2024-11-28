using System.Collections.Generic;
using UnityEngine;

public class ComparisonTable : MonoBehaviour
{
    public static ComparisonTable instance;

    [SerializeField] private List<ObjectGame> objectInTableList = new List<ObjectGame>();
    [SerializeField] private List<ObjectGame> listObjectInScene = new List<ObjectGame>();

    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }

    public void AddObjectList(ObjectGame _objectInScene)
    {
        if (objectInTableList.Count >= 1)
            Comparsion(_objectInScene);
        else
        {
            _objectInScene.InTable();
            objectInTableList.Add(_objectInScene);
        }
    }

    public void RemoveObjectList(ObjectGame _objectInScene) => objectInTableList.Remove(_objectInScene);

    public void Comparsion(ObjectGame _objectInScene)
    {
        if (objectInTableList[0].id == _objectInScene.id)
        {
            //Remove Object Check Win
            listObjectInScene.Remove(_objectInScene);
            Destroy(_objectInScene.gameObject);

            listObjectInScene.Remove(objectInTableList[0]);
            Destroy(objectInTableList[0].gameObject);

            objectInTableList.Clear();

            if (listObjectInScene.Count <= 0)
                Debug.Log("Win-Game");
        }
        else
            _objectInScene.OutTable();
    }

    public void AddObjectToListObjectInScene(ObjectGame _objectInScene) => listObjectInScene.Add(_objectInScene);
}
