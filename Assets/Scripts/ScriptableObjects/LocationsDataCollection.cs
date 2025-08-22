using System;
using UnityEngine;

[CreateAssetMenu(fileName = "LocationsData", menuName = "Scriptable Objects/LocationsData")]
public class LocationsDataCollection : ScriptableObject
{
    public LocationsData[] collection;
}
[Serializable]
public class LocationsData 
{
    public string locationsId;
    public string locationsName;
    public Sprite locationsSprite;
}