using System;
using UnityEngine;
using System.IO;

public class SaveSystem
{
    private static SaveData _saveData = new SaveData();

    [System.Serializable]
    public struct SaveData
    {
        public PlayerSaveInfo PlayerInfo;
    }

    // public const string FILENAME_SAVEDATA = "/savedata.json";
    public static string SaveFileName()
    {
        string saveFile = Application.persistentDataPath + "/save" + ".save";
        return saveFile;

    }

    public static void Save()
    {
        HandleSaveData();
        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(_saveData, true));
    }
    private static void HandleSaveData()
    {
        PlayerData.Instance.Save(ref _saveData.PlayerInfo);
    }
    public static void Load()
    {
        string saveContent = File.ReadAllText(SaveFileName());

        _saveData = JsonUtility.FromJson<SaveData>(saveContent);
        HandleLoadData();
    }
    private static void HandleLoadData()
    {
        PlayerData.Instance.Load(ref _saveData.PlayerInfo);
    }
}


