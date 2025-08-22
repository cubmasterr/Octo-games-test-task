using Naninovel;

[CommandAlias("completeCurrentQuest")]
public class CompleteCurentQuestCommand : Command
{
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        Engine.GetService<QuestSevice>().CompleteCurrentQuest();
        return UniTask.CompletedTask;
    }
}
