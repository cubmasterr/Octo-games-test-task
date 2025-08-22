using Naninovel;
using Naninovel.UI;
using UnityEngine;

public class MemoryCardsPanel : CustomUI
{
    [SerializeField] private Transform _content;
    [SerializeField] private MemoryCardButton _prefab;
    [SerializeField] private MemoryCardDataCollection _memoryCardCollection;
    private PoolMono<MemoryCardButton> _poolMono;
    protected override void Awake()
    {
        base.Awake();
        _poolMono = new PoolMono<MemoryCardButton>(_prefab, _memoryCardCollection.collection.Length, _content);
        _poolMono.IsAutoExpand = false;
    }

    public int StartGame()
    {
        Show();
        for (int i = 0; i < _content.childCount; i++) { _content.GetChild(i).gameObject.SetActive(false); }
        for (int i = _memoryCardCollection.collection.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            MemoryCardData temp = _memoryCardCollection.collection[i];
            _memoryCardCollection.collection[i] = _memoryCardCollection.collection[j];
            _memoryCardCollection.collection[j] = temp;
        }
        foreach (var data in _memoryCardCollection.collection)
        {
            _poolMono.GetFreeElement().Initialise(data);
        }
        return _memoryCardCollection.collection.Length;
    }

}

