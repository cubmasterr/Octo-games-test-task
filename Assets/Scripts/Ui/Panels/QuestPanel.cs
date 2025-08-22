using Naninovel.UI;
using Naninovel;
using UnityEngine;
using System.Linq;
using TMPro;

public class QuestPanel : CustomUI
{
    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField] private TextMeshProUGUI  _discription;
    [SerializeField] private QuestDataCollection _questDataCollection;
    private QuestSevice _questService;
    protected override void Awake()
    {
        base.Awake();
        _questService = Engine.GetService<QuestSevice>();
    }
    public override void Show()
    {
        var questName = _questService.GetCurentQuestName();
        var questStage = _questService.GetQuestState(questName);
        var quest = _questDataCollection.collection.FirstOrDefault(t => t.questName == questName);
        if (quest != null)
        {
            _header.text = quest.questVisualName;
            if (questStage > 0)
            {
                _discription.text = "";
                for (int i = 0; i < questStage; i++)
                {
                    _discription.text += "<s>" + quest.questStagesDescriptions[i] + "</s>\n";
                }
            }
            _discription.text += quest.questStagesDescriptions[questStage];
        }
        base.Show();
    }
}
