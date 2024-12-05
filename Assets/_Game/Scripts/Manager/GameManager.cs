using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameState gameState;
    [SerializeField] public int GameLevel;
    [field: SerializeField] public ItemObjectCollection ItemObjectCollection { get; private set; }

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnInit()
    {

    }

    public void PauseGame(bool _bool)
    {
        Time.timeScale = _bool ? 0 : 1;
    }
}