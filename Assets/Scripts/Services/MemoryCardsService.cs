using Naninovel;
using UnityEngine;

[InitializeAtRuntime]
public class MemoryCardsService : IEngineService
{
    private MemoryCardsPanel _memoryCardsPanel;
    private MemoryCardButton _last;
    private int _memoryCardsCount = 0;
    private int _cardClickedCount = 0;
    private int _cardClickedMaxCount = 2;
    private int _cardTurnedCount = 0;
    private float _timeToTurn = 1;
    private float _enabledAlpha = 1;
    private float _disabledAlpha = 0;
    private UniTaskCompletionSource _taskCompletionSource;
    public UniTask  InitializeServiceAsync()
    {
        return UniTask.CompletedTask;
    }
    public async UniTask StarGame()
    {
        _memoryCardsPanel = Engine.GetService<UIManager>().GetUI<MemoryCardsPanel>();
        _taskCompletionSource = new();
        _cardClickedCount = 0;
        _cardTurnedCount = 0;
        _memoryCardsCount = _memoryCardsPanel.StartGame();
        await _taskCompletionSource.Task;
    }
    public async UniTask CardClicked(MemoryCardButton button)
    {
        button.SetIteractableButton(false);
        _cardClickedCount++;
        await Fade(new MemoryCardButton[] { button }, _disabledAlpha, _enabledAlpha, _timeToTurn);
        if (_last == null) _last = button;
        else 
        {
            if (_last.GetCardData().type == button.GetCardData().type)
            {
                _cardTurnedCount+=2;
                if (_cardTurnedCount >= _memoryCardsCount)
                {
                    _memoryCardsPanel.Hide();
                    _taskCompletionSource?.TrySetResult();
                }
            }
            else
            {
                await Fade(new MemoryCardButton[] { button, _last }, _enabledAlpha, _disabledAlpha, _timeToTurn);
                button.SetIteractableButton(true);
                _last.SetIteractableButton(true);
            }
            _cardClickedCount = 0;
            _last = null;
        }

    }
    public async UniTask Fade(MemoryCardButton[] buttons, float from, float to, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(from, to, elapsed / duration);
            foreach (MemoryCardButton button in buttons)
            {
                Color color = button.GetImage().color;
                button.GetImage().color = new Color(color.r, color.g, color.b, alpha);
            }
            await UniTask.Yield();
        }
        foreach (MemoryCardButton button in buttons)
        {
            Color color = button.GetImage().color;
            button.GetImage().color = new Color(color.r, color.g, color.b, to);
        }
    }


    public void ResetService() { }
    public void DestroyService() { }

    public bool IsAibleToClick()
    {
        return _cardClickedCount < _cardClickedMaxCount;
    }
}
