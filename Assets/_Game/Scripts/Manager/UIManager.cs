using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TextMeshProUGUI textTimerLevel;

    public void SetTextTimerLevel(float timer)=>textTimerLevel.SetText(timer.ToString());
}
