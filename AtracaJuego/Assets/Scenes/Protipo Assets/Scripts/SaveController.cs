using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveController
{
    public static void Save(int scene, bool[] combinaciones)
    {
        SaveData data = new SaveData { escena = scene, combos = combinaciones };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/save.txt", json);
    }
    public static SaveData Load()
    {
        string file = File.ReadAllText(Application.persistentDataPath + "/save.txt");
        SaveData loaddata = JsonUtility.FromJson<SaveData>(file);
        return loaddata;
    }
    public static bool saveExists()
    {
        return File.Exists(Application.persistentDataPath + "/save.txt");
    }
}
public class SaveData
{
  public  int escena;
 public   bool[] combos;
}