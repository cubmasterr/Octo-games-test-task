using Naninovel;

[CommandAlias("setQuestState")]
public class SetQuestStateCommand : Command
{
    [ParameterAlias("questName")]
    public StringParameter questName;
    [ParameterAlias("questState")]
    public IntegerParameter questState;
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        Engine.GetService<QuestSevice>().SetQuestState(questName, questState);
        return UniTask.CompletedTask;
    }

}

