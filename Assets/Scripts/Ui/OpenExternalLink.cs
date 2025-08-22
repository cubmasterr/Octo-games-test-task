using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OpenExternalLink : MonoBehaviour
{
    [SerializeField] private string _link;
    private Button _button;
    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonListner);
    }
    private void ButtonListner()
    {
        Application.OpenURL(_link);
    }
}

