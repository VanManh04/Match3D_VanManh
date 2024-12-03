using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int level;
    [SerializeField] private List<Level> levels = new List<Level>();

    void Start()
    {
        LevelManager.Ins.levelData = levels[level];
    }

    void Update()
    {

    }

    public void OnInit()
    {

    }


}