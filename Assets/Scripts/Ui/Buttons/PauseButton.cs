using Naninovel;
using Naninovel.UI;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PauseButton  : MonoBehaviour
{
    private PauseUI _pauseUI;
    private void Start()
    {
        _pauseUI = Engine.GetService<IUIManager>().GetUI<PauseUI>();
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
    private void OnClick()  { _pauseUI.Show();}
}
