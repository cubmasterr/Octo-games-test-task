using Naninovel;
using System.Diagnostics;
[CommandAlias("setLocation")]
public class SetLocationCommand : Command
{
    [ParameterAlias("labels")]
    public StringParameter labels;
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        Engine.GetService<ICustomVariableManager>().SetVariableValue("LocationLabel", labels);
        Engine.GetService<IUIManager>().GetUI<MapButton>().Show();
        return UniTask.CompletedTask;
    }
}
