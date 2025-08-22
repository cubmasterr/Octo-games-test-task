using System;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestDataCollection", menuName = "Scriptable Objects/QuestDataCollection")]
public class QuestDataCollection : ScriptableObject
{
    public QuestData[] collection;
}
[Serializable]
public class QuestData
{
    public string questName;
    public string questVisualName;
    public string [] questStagesDescriptions;
}
