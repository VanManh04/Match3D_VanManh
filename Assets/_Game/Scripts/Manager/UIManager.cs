using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("Game State")]
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject GamePlay;
    [SerializeField] private GameObject Pause;
    [SerializeField] private GameObject Win;
    [SerializeField] private GameObject Lose;


    [Header("Game Level")]
    [SerializeField] private TextMeshProUGUI Level;
    [SerializeField] private TextMeshProUGUI textTimerLevel;

    private void Start()
    {
        SwitchTo(GamePlay);
    }

    public void SetTextTimerLevel(float timer) => textTimerLevel.SetText(timer.ToString());
    public void SetTextLevel(int level) => Level.SetText("Level: " + level.ToString());

    public void SwitchTo(GameObject _menu)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            //bool fadeScreen = .get
            transform.GetChild(i).gameObject.SetActive(false);
        }

        if (_menu != null)
        {
            _menu.SetActive(true);
            if (GameManager.Ins != null)
            {
                if (_menu == GamePlay)
                    GameManager.Ins.PauseGame(false);
                else
                    GameManager.Ins.PauseGame(true);
            }
        }
    }

    public void UIMenu()
    {
        SwitchTo(Menu);
        GameManager.Ins.ChangeState(GameState.Menu);
    }
    public void UIGamePlay()
    {
        SwitchTo(GamePlay);
        GameManager.Ins.ChangeState(GameState.GamePlay);
    }
    public void UIPause()
    {
        SwitchTo(Pause);
        GameManager.Ins.ChangeState(GameState.Pause);
    }

    public void UIWinGame()
    {
        SwitchTo(Win);
        GameManager.Ins.ChangeState(GameState.Win);
    }

    public void UILoseGame()
    {
        SwitchTo(Lose);
        GameManager.Ins.ChangeState(GameState.Lose);
    }

    public void RePlay() => LevelManager.Ins.RePlay();
    public void NextLevel() => LevelManager.Ins.NextLevel();
    public void PlayAgain() => LevelManager.Ins.PlayAgain();
    public void Continue() => LevelManager.Ins.Continue();
}
