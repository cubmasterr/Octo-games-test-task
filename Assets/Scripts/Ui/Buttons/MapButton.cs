using Naninovel;
using Naninovel.UI;
using UnityEngine;
using UnityEngine.UI;

public class MapButton : CustomUI
{
    [SerializeField] private Button _button;
    private LocationPanel _locationPanel;
    protected override void Start()
    {
        base.Start();
        _locationPanel = Engine.GetService<IUIManager>().GetUI<LocationPanel>();
        _button.onClick.AddListener(OnClick);
    }
    private void OnClick() { _locationPanel.Show(); }
}
