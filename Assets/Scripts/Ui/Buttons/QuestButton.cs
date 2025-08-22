using Naninovel;
using Naninovel.UI;
using UnityEngine;
using UnityEngine.UI;

public class QuestButton : CustomUI
{
    [SerializeField] private Button _button;
    private QuestPanel _questPanel;

    protected override void Start()
    {
        base.Start();
        _questPanel = Engine.GetService<IUIManager>().GetUI<QuestPanel>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick() { _questPanel.Show(); }
}
