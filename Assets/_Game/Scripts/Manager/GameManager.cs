using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private GameState gameState;
    [SerializeField] public int GameLevel;
    [field: SerializeField] public ItemObjectCollection ItemsLevel { get; private set; }

    void Start()
    {
        gameState = GameState.GamePlay;
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

    public GameState GetGameState() => gameState;

    public void ChangeState(GameState _gameState)
    {
        gameState = _gameState;
    }
}