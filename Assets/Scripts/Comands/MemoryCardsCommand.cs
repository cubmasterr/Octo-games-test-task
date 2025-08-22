using Naninovel;

[CommandAlias("memoryCardsMiniGame")]
public class MemoryCardsCommand : Command
{
    public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
       await Engine.GetService<MemoryCardsService>().StarGame();
    }
}
