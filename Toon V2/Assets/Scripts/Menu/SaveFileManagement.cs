using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SaveFileManagement : MonoBehaviour
{
    [SerializeField] private CharacterRandomisation[] characterRandomisation;

    private string path;
    private string persistentPath;

    public static GameData saveDataList;

    void Start()
    {
        saveDataList = new GameData();
        SetPaths();
        //Whenever the save file layout is changed, run the game with the next line uncommented once
        //SaveData(0);
        LoadData(0);
    }

    private void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }

    public void SaveData(int file)
    {
        string savePath = path;
        string json = JsonUtility.ToJson(saveDataList);
        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }

    public void LoadData(int file)
    {
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();

        saveDataList = JsonUtility.FromJson<GameData>(json);
    }

    public void SetCharacterAppearances()
    {
        for (int character = 0; character < characterRandomisation.Length; character++)
        {
            for (int element = 0; element < 15; element++)
            {
                characterRandomisation[character].ChangeValue(element, saveDataList.characterRandomisations[saveDataList.currentFile * 450 + character + element]);
                characterRandomisation[character].ChangeName(saveDataList.characterNames[saveDataList.currentFile * 30 + character]);
            }
        }
    }
}

public class GameData
{
    public int currentFile = 0;
    public float[] sliderOptions = new float[] { 1f, 1f, 0.5f };
    public int[] otherOptions = new int[16];
    public int[] characterRandomisations = new int[1350];
    public int[] characterNames = new int[90];
}

/*
 * Save file layout:
 * 
 * 
 * Character randomisation element is savefile * 450 + character * 15 + element
 * Elements are:
 *  1 - randomPhyscialHead
 *  2 - randomPhyscialHands
 *  3 - randomPhyscialHair
 *  4 - randomPhyscialEyes
 *  5 - randomPhyscialClothesOuter
 *  6 - randomPhyscialClothesInner
 *  7 & 8 - Unused
 *  9 - randomColourSkin
 *  10 - randomColourHair
 *  11 - randomColourEyes
 *  12 - randomColourClothesOuter
 *  13 - randomColourClothesInner
 *  14 & 15 - Unused
 * 
 * 
 */