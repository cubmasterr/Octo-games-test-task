using Naninovel;
using Naninovel.UI;
using System.Linq;
using UnityEngine;

public class LocationPanel : CustomUI
{
    [SerializeField] private int _mapOtionalCount;
    [SerializeField] private Transform _content;
    [SerializeField] private LocationButton _prefab;
    [SerializeField] private LocationsDataCollection _locationsDataCollection;
    private PoolMono<LocationButton> _poolMono;
    private ICustomVariableManager _customVariableManager;
    protected override void Awake()
    {
        base.Awake();
        _poolMono = new PoolMono<LocationButton>(_prefab, _mapOtionalCount, _content);
        _poolMono.IsAutoExpand = true;
        _customVariableManager = Engine.GetService<ICustomVariableManager>();
    }
    public override void Show()
    {
        base.Show();
        SetLabels();
    }
    private void SetLabels()
    {
        var labels = _customVariableManager.GetVariableValue("LocationLabel");
        for (int i = 0; i < _content.childCount; i++) { _content.GetChild(i).gameObject.SetActive(false); }
        foreach (var label in labels.Split(',')) 
        {
            var splitedLabel = label.Split("_");
            var id = splitedLabel[0];
            var locationsData = _locationsDataCollection.collection.FirstOrDefault(t => t.locationsId == id);
            if (locationsData != null)
            {
                _poolMono.GetFreeElement().Initialise(locationsData, splitedLabel[1] == "true");
            }
        }
    }
}
