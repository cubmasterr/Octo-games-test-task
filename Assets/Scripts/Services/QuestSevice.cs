using Naninovel;
using System;

[InitializeAtRuntime]
public class QuestSevice : IEngineService
{
    private ICustomVariableManager _variableManager;
    private UIManager _uIManager;

    public UniTask InitializeServiceAsync()
    {
        _variableManager = Engine.GetService<ICustomVariableManager>();
        _uIManager = Engine.GetService<UIManager>();
         if(GetCurentQuestName()!="") _uIManager.GetUI<QuestButton>().Show();
        return UniTask.CompletedTask;
    }
    public void CompleteCurrentQuest()
    {
        var currentQuest = GetCurentQuestName();
        _variableManager.SetVariableValue("currentQuest", "");
        _uIManager.GetUI<QuestPanel>().Hide();
        _uIManager.GetUI<QuestButton>().Hide();
    }
    public void StartCurentQuest(string questName)
    {
        _uIManager.GetUI<QuestButton>().Show();
        _variableManager.SetVariableValue("currentQuest", questName);
        SetQuestState(questName, 0);
    }
    public string GetCurentQuestName()
    {
        if (_variableManager.VariableExists("currentQuest") == false) return "";
        return _variableManager.GetVariableValue("currentQuest");
    }
    public int GetQuestState(string questName)
    {
        if(_variableManager.VariableExists(questName + "Stage")==false) return 0;
        var variable = _variableManager.GetVariableValue(questName + "Stage");
        return Convert.ToInt32(variable);
    }
    public void SetQuestState(string questName, int questState)
    {
        _variableManager.SetVariableValue(questName + "Stage", questState.ToString());
    }

    public void ResetService() { }
    public void DestroyService() { }
}
