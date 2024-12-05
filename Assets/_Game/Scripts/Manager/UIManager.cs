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


    [SerializeField] private TextMeshProUGUI textTimerLevel;

    private void Start()
    {
        SwitchTo(GamePlay);
    }

    public void SetTextTimerLevel(float timer) => textTimerLevel.SetText(timer.ToString());

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
        GameManager.Ins.gameState = GameState.Menu;
    }
    public void UIGamePlay()
    {
        SwitchTo(GamePlay);
        GameManager.Ins.gameState = GameState.GamePlay;
    }
    public void UIPause()
    {
        SwitchTo(Pause);
        GameManager.Ins.gameState = GameState.Pause;
    }

    public void UIWinGame()
    {
        SwitchTo(Win);
        GameManager.Ins.gameState = GameState.Win;
    }

    public void UILoseGame()
    {
        SwitchTo(Lose);
        GameManager.Ins.gameState = GameState.Lose;
    }
}
