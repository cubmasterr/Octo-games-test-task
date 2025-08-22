using Naninovel;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class MemoryCardButton : MonoBehaviour
{
    [SerializeField] private Image _image;
    private MemoryCardData _data;
    private Button _button;
    private MemoryCardsService _service;
    public MemoryCardData GetCardData() { return _data; }
    public Image GetImage() { return _image; }
    public void SetIteractableButton(bool isInteractable) { _button.interactable = isInteractable; }
    private void Awake()
    {
        _service = Engine.GetService<MemoryCardsService>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonListner);
    }
    private void ButtonListner()
    {
        if (_service.IsAibleToClick()==false) return;
        _image.sprite = _data.sprite;
        _service.CardClicked(this);
    }
    public void Initialise(MemoryCardData data)
    {
        SetIteractableButton(true);
        _data = data;
    }
}