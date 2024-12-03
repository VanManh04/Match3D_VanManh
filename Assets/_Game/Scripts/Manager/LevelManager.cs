using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private float timerLevel;
    public Level levelData;

    [SerializeField] private List<ItemObject> itemInScenes = new List<ItemObject>();
    [SerializeField] private GameObject cloneItemObjectPrefabs;

    public void OnInit()
    {
        Instantiate(cloneItemObjectPrefabs);   
        timerLevel = levelData.GetTimerLevel();
    }

    private void Start()
    {
        OnInit();
    }

    private void Update()
    {
        timerLevel -= Time.deltaTime;
        UIManager.Ins.SetTextTimerLevel(timerLevel);

        if (timerLevel <= 0)
            OnLose();
    }

    public void OnStart()
    {

    }

    public void OnPlay()
    {

    }

    private void OnLoad(int level)
    {

    }

    public void OnWin()
    {
        Debug.Log("Win_Game");
    }

    public void OnLose()
    {
        Debug.Log("Lose_Game");
    }

    public void OnDone(ItemObject item)
    {

    }

    public void AddItemObject_ListItemInScene(ItemObject items) => itemInScenes.Add(items);
    public void RemoveItemObject_ListItemInScene(ItemObject items)
    {
        itemInScenes.Remove(items);
        if (itemInScenes.Count <= 0)
            OnWin();
    }
}
