using Naninovel;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LocationButton : MonoBehaviour
{
    private string _label;
    private IUIManager _uiManager;
    [SerializeField] private Image _image;
    [SerializeField] private Text[] _texts;
    [SerializeField] private GameObject _locked;
    public void Initialise(LocationsData data,bool isEnabled) 
    {
        _label = data.locationsId;
        foreach (var text in _texts) { text.text = data.locationsName; }
        _image.sprite = data.locationsSprite;
        _uiManager = Engine.GetService<IUIManager>();
        var button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        button.enabled = isEnabled;
        _locked.SetActive(!isEnabled);
    }
    private void OnClick()
    {
        _uiManager.GetUI("MapUI").Hide();
        var scriptPlayer = Engine.GetService<IScriptPlayer>();
        scriptPlayer.PlayFromLabel(_label);
    }
}
