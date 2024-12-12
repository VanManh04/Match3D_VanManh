using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [Header("Stage")]
    [SerializeField] private Stage stage;
    private bool endGame;

    [Header("Game Level")]
    [SerializeField] private int GameLevel;
    [SerializeField] private List<LevelData> levelDataList = new List<LevelData>();
    [SerializeField] private LevelData levelData;
    [SerializeField] private float timerLevel;

    [Header("Clone Object")]
    [SerializeField] private List<ItemObject> itemInScenes = new List<ItemObject>();
    [Space]
    [SerializeField] private int countCupleObject;
    [SerializeField] private List<ItemObject> listObjects;
    [SerializeField] private BoxCollider boxRandomSpawn;

    [ContextMenu("Reset Level")]
    public void ResetLevel()
    {
        levelDataList[0].GetItemObjectCollection().ResetList();
        PlayerPrefs.SetInt("GameLevel", 0);
    }

    public void OnInit(bool _loadNextLevel)
    {
        endGame = false;
        stage.OnInit();
        ClearItemInScene();

        LoadLevel(_loadNextLevel);
        CloneObject();

        print(GameLevel);
    }

    private void Start()
    {
        OnInit(true);
    }

    private void Update()
    {
        if (endGame)
            return;

        timerLevel -= Time.deltaTime;
        UIManager.Ins.SetTextTimerLevel(timerLevel);

        if (timerLevel <= 0)
        {
            UIManager.Ins.SetTextTimerLevel(0f);
            OnLose();
        }
    }

    public void OnWin()
    {
        Debug.Log("Win_Game");
        endGame = true;
        UIManager.Ins.UIWinGame();
        GameLevel++;
        PlayerPrefs.SetInt("GameLevel", GameLevel);
        GameManager.Ins.ItemsLevel.SetCanAddItem(true);
    }

    public void OnLose()
    {
        Debug.Log("Lose_Game");
        endGame = true;
        UIManager.Ins.UILoseGame();

        PlayerPrefs.SetInt("GameLevel", GameLevel);
    }

    private void AddNewItemUnlockLevel()
    {
        if (levelData.GetListItemUnlockIfWin().Count > 0)
        {
            foreach (ItemObject itemObject in levelData.GetListItemUnlockIfWin())
            {
                GameManager.Ins.ItemsLevel.AddUnLock(itemObject);
                print("Unlock " + itemObject.name);
            }
        }
        else
            print("No Item");
    }
    public void RemoveItemObject_ListItemInScene(ItemObject items)
    {
        itemInScenes.Remove(items);
        if (itemInScenes.Count <= 0)
            Invoke(nameof(OnWin), .7f);
    }


    #region Clone Object
    private void SetUpDataCloneObjectLevel()
    {
        countCupleObject = levelData.GetCountCupleObject();
        listObjects = levelData.GetItems();
    }
    private void CloneObject()
    {
        SetUpDataCloneObjectLevel();

        int random_Index;
        ItemObject objectGame;

        for (int i = 0; i < countCupleObject; i++)
        {
            random_Index = Random.Range(0, listObjects.Count);

            objectGame = Instantiate(listObjects[random_Index], GetRandomPointInBox(boxRandomSpawn), Random.rotation);
            objectGame.id_Object = random_Index;
            itemInScenes.Add(objectGame);

            objectGame = Instantiate(listObjects[random_Index], GetRandomPointInBox(boxRandomSpawn), Random.rotation);
            objectGame.id_Object = random_Index;
            itemInScenes.Add(objectGame);
        }
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

    #endregion

    #region LoadLevel
    private void LoadLevel(bool _autoLoadLevel)
    {
        if (_autoLoadLevel)
        {
            GameLevel = PlayerPrefs.GetInt("GameLevel");
            if (GameManager.Ins.ItemsLevel.GetCanAddItem())
            {
                AddNewItemUnlockLevel();
                GameManager.Ins.ItemsLevel.SetCanAddItem(false);
            }
        }
        if (GameLevel >= levelDataList.Count)
        {
            Debug.LogWarning("Count Level Data Null -> Reset Level");
            ResetLevel();
            GameLevel = 0;
        }
        levelData = levelDataList[GameLevel];
        GameManager.Ins.GameLevel = GameLevel;

        timerLevel = levelData.GetTimerLevel();
        UIManager.Ins.SetTextLevel(GameLevel);
    }

    #endregion


    public void NextLevel()
    {
        UIManager.Ins.UIGamePlay();

        OnInit(true);
    }


    public void RePlay()
    {
        GameLevel--;
        GameManager.Ins.GameLevel = GameLevel;

        UIManager.Ins.UIGamePlay();

        OnInit(false);
    }

    public void Continue()
    {
        UIManager.Ins.UIGamePlay();
    }

    public void PlayAgain()
    {
        UIManager.Ins.UIGamePlay();

        OnInit(false);
    }

    private void ClearItemInScene()
    {
        if (itemInScenes.Count > 0)
        {
            foreach (ItemObject item in itemInScenes)
                if (item != null)
                    Destroy(item.gameObject);

            itemInScenes.Clear();
        }
    }
}
