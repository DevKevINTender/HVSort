using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ScriptableObjects;
using ScriptableObjects.LevelsSO;
using UnityEditor;
using UnityEngine;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using static PartCom;

public class LevelScrObjGenerator : MonoBehaviour
{
#if (UNITY_EDITOR)

        [ContextMenu("Generate")]
    void Generate()
    {
        List<PartColor> newList = new List<PartColor>();
        newList = FileParse();
        string[] guids1 = AssetDatabase.FindAssets("LevelSO", new[] {"Assets/Resources/ScriptableObjects/LevelsSO/Items"});
       
        foreach (string guid1 in guids1)
        {
            Debug.Log(AssetDatabase.GUIDToAssetPath(guid1));
        }
        
        LevelScrObj asset = ScriptableObject.CreateInstance<LevelScrObj>();
        int count = 0;
        for (int i = 0; i < 10; i++)
        {
            Colum newColum = new Colum();
            for (int j = 0; j < 4; j++)
            {
                if (count < newList.Count)
                {
                    newColum.list.Add(newList[count]);
                    count++;
                }
            }
            asset.list.Add(newColum);
        }
        AssetDatabase.CreateAsset(asset, "Assets/Resources/ScriptableObjects/LevelsSO/Items/LevelSO" + guids1.Length + ".asset");
        AssetDatabase.SaveAssets();
    }
    [ContextMenu("Parse")]
    public List<PartColor> FileParse()
    {
        List<PartColor> newList = new List<PartColor>();
        using (StreamReader r = new StreamReader("E:/PythonProjects/ball-sort-puzzle-bot-master/app/new_file.json"))
        {
            string text = r.ReadToEnd();

            int previousColor = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ',')
                {
                    
                    string color = "";
                    for (int j = previousColor; j < i; j++)
                    {
                        if(text[j] != '"') color += text[j];
                    }
                    previousColor = i+1;
                    newList.Add(getColor(color));
                }
            }
        }
        Debug.Log(newList.Count);
        return newList;
    }

    public PartColor getColor(string colorText)
    {
        PartColor color = (PartColor)System.Enum.Parse(typeof(PartColor), colorText);
        return color;
    }
    #endif
}
