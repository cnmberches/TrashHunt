using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;

public static class SaveSystem
{
    static string path = Application.persistentDataPath + "/player.dat";
    static BinaryFormatter formatter = new BinaryFormatter();
    static FileStream stream;

    public static void SavePlayer(PlayerController player, bool isOnBase)
    {
        stream = new FileStream(path, FileMode.Create);

        SaveData playerData = new SaveData(player, isOnBase);

        formatter.Serialize(stream, playerData);
        

        stream.Close();
    }

    //If player just started the game
    public static void OnStart()
    {
        stream = new FileStream(path, FileMode.Create);

        SaveData playerData = new SaveData();
        Debug.Log("Save System: " + playerData.bgMusicVolume);
        formatter.Serialize(stream, playerData);
        stream.Close();
    }

    public static void SaveFromTitleScreen(SaveData prevData, float bgMusicVolume, float fxMusicVolume)
    {
        stream = new FileStream(path, FileMode.Create);

        SaveData playerData = new SaveData(prevData, bgMusicVolume, fxMusicVolume);

        formatter.Serialize(stream, playerData);
        stream.Close();
        
    }

    public static SaveData LoadPlayer()
    {
        if (File.Exists(path))
        {
            stream = new FileStream(path, FileMode.Open);

            SaveData playerData = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return playerData;
        }
        else
        {
            return null;
        }
       
    }
    public static void Delete()
    {
        File.Delete(path);
    }
}
