using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    [Header("Game Level")]
    [SerializeField] private int GameLevel;
    [SerializeField] private List<LevelData> levelDataList = new List<LevelData>();
    [SerializeField] private LevelData levelData;
    [SerializeField] private float timerLevel;

    [Header("Clone Object")]
    [SerializeField] private List<ItemObject> itemInScenes = new List<ItemObject>();
    [SerializeField] private CloneItemObject cloneItemObjectPrefabs;

    public bool EndGame;

    [ContextMenu("Reset Level")]
    public void ResetLevel() => PlayerPrefs.SetInt("GameLevel", 0);

    public void OnInit()
    {
        EndGame = false;
        Time.timeScale = 1;
        GameLevel = PlayerPrefs.GetInt("GameLevel");
        if (GameLevel >= levelDataList.Count)
        {
            Debug.LogError("Count Level Data Null -> Reset Level");
            GameLevel = 0;
        }
        levelData = levelDataList[GameLevel];
        GameManager.Ins.GameLevel = GameLevel;

        timerLevel = levelData.GetTimerLevel();
        Instantiate(cloneItemObjectPrefabs).SetUpData(levelData.GetItems(), levelData.GetCountCupleObject());
        print(GameLevel);
    }

    private void Start()
    {
        OnInit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(0);

        if (Input.GetKeyDown(KeyCode.K))
            UIManager.Ins.UIMenu();
        if (Input.GetKeyDown(KeyCode.J))
            UIManager.Ins.UIGamePlay();

        if (EndGame)
            return;
        timerLevel -= Time.deltaTime;
        UIManager.Ins.SetTextTimerLevel(timerLevel);

        if (timerLevel <= 0)
        {
            UIManager.Ins.SetTextTimerLevel(0f);
            OnLose();
        }
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
        //UIManager.Ins.UIWinGame();
        //Time.timeScale = 0;
        EndGame = true;
        GameLevel++;
        PlayerPrefs.SetInt("GameLevel", GameLevel);

        if (levelData.GetListItemUnlockIfWin().Count > 0)
        {
            foreach (ItemObject itemObject in levelData.GetListItemUnlockIfWin())
            {
                GameManager.Ins.ItemObjectCollection.AddUnLock(itemObject);
                print("Unlock " + itemObject.name);
            }
        }
        else
            print("No Item");
    }

    public void OnLose()
    {
        Debug.Log("Lose_Game");
        //UIManager.Ins.UILoseGame();
        //Time.timeScale = 0;
        EndGame = true;
        PlayerPrefs.SetInt("GameLevel", GameLevel);
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
