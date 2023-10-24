using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SaveFileManagement : MonoBehaviour
{
    [SerializeField] private CharacterRandomisation[] characterRandomisation;
    [SerializeField] private Text[] fileNames;

    private string path;
    private string persistentPath;

    public GameData saveDataList;

    void Start()
    {
        saveDataList = new GameData();
        SetPaths();
        //Whenever the save file layout is changed, run the game with the next line uncommented once
        //SaveData();
        LoadData();
    }

    private void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }

    public void SaveData()
    {
        string savePath = path;
        string json = JsonUtility.ToJson(saveDataList);
        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }

    public void LoadData()
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
                characterRandomisation[character].ChangeValue(element, saveDataList.characterRandomisations[saveDataList.currentFile * 450 + character * 15 + element]);
                characterRandomisation[character].ChangeName(saveDataList.characterNames[saveDataList.currentFile * 30 + character * 15]);
            }
        }
    }

    public void UpdateSaveFileUIElements()
    {
        for (int file = 0; file < fileNames.Length; file++)
        {
            if (file % 3 == -1)
            {
                fileNames[file].text = $"File {file % 3}: (Empty)";
            }
        }
    }
}

public class GameData
{
    public int currentFile = 0;
    public float[] sliderOptions = new float[] { 1f, 1f, 0.5f };
    public int[] otherOptions = new int[16];
    public string playerName;
    public int day = -1;
    public int[] characterRandomisations = new int[1350];
    public int[] characterNames = new int[90];
    public int[] playerFavour = new int[3];
    public int[] playerFlags = new int[120];
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

public class SFM : SaveFileManagement
{
    //This class is used as a shorthand for writing 'SaveFileManagement'
}