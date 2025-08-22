using Naninovel;

[CommandAlias("startCurentQuest")]
public class StartCurentQuestCommand : Command
{
    [ParameterAlias("questName")]
    public StringParameter questName;
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        Engine.GetService<QuestSevice>().StartCurentQuest(questName);
        return UniTask.CompletedTask;
    }
}
