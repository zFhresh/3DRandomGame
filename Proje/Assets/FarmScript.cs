using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmScript : MonoBehaviour
{
    [SerializeField]
    DictionaryKeyValue[] DicValues;
    FarmData Farm = new FarmData();
    private void Start() {
        foreach (DictionaryKeyValue DicValue in DicValues) {
            Farm.AnimalCounts.Add(DicValue.Key , DicValue.Value);
        }
        AddAnimal("sa");
    }
    public void FeedAnimals() {

    }
    public void AddAnimal(string name) {
        Farm.AnimalCounts["Pig"] += 1;
        Debug.Log(Farm.AnimalCounts["Pig"]);
    }
}
[System.Serializable]
public class FarmData {
    public Dictionary<string,int> AnimalCounts = new Dictionary<string, int>();
    public FarmData() {
    }

}
[System.Serializable]
public class DictionaryKeyValue {
    public string Key;
    public int Value;
    public DictionaryKeyValue(string _key , int _Value) {
        Key = _key;
        Value = _Value;
    }
}
