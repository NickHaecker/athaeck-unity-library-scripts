using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class StateManager
{
    public static void SaveDataForSave<T>(string url, T data) where T : DataForSave
    {


        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + url;
        FileStream stream = new FileStream(path, FileMode.Create);


        formatter.Serialize(stream, data);
        stream.Close();


        Debug.Log("Save - COMPLETED");


    }
    public static T LoadDataForSave<T>(string url) where T : DataForSave
    {
        string path = Application.persistentDataPath + url;
        if (File.Exists(path))
        {

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            T data = formatter.Deserialize(stream) as T;
            stream.Close();



            return data;

        }

        Debug.Log("Load - NULL");

        return null;
    }
}
