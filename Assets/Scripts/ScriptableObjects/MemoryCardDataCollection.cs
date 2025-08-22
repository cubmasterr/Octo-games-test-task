using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MemoryCardDataCollection", menuName = "Scriptable Objects/MemoryCardDataCollection")]
public class MemoryCardDataCollection : ScriptableObject
{
    public MemoryCardData[] collection;
}
[Serializable]
public class MemoryCardData
{
    public MemoryCardDataType type;
    public Sprite sprite;
}
public enum MemoryCardDataType
{
    House,
    Park,
    Market
}