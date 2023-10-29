using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SaveFileManagement : MonoBehaviour
{
    [SerializeField] private CharacterRandomisation[] characterRandomisation;
    [SerializeField] private Text[] fileNames;
    [SerializeField] private StateController[] saveStateSlots;

    private string path;
    private string persistentPath;
    private SaveGameStreamReadWriteable saveFileReadWriteable;

    public static SaveGame saveGame;
    public static SaveFile saveFile;
    public static SaveState saveState;

    public Camera camera;


    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            SaveData();
        }
        if (Input.GetKeyDown("w"))
        {
            LoadData();
        }
    }

    public void OpenFiles()
    {
        if (saveGame == null)
        {
            saveFileReadWriteable = new SaveGameStreamReadWriteable();
            SetPaths();
            //Whenever the save file layout is changed, run the game with the next line uncommented once
            MakeFile();
            LoadData();
        }
    }

    private void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }

    public void SaveData()
    {
        //saveGame.saveGames[saveGame.currentFile] = saveData;
        ConvertFromSGToSGReadWriteable();

        string savePath = path;
        string json = JsonUtility.ToJson(saveFileReadWriteable);
        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }

    public void MakeFile()
    {
        string savePath = path;
        string json = JsonUtility.ToJson(saveFileReadWriteable);
        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }

    public void LoadData()
    {
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();

        saveFileReadWriteable = JsonUtility.FromJson<SaveGameStreamReadWriteable>(json);
        ConvertFromSGReadWriteableToSG();
        //saveData = saveGame.saveGames[saveGame.currentFile];
    }

    public void SaveToState(int state)
    {
        SaveCameraView(camera, state);
        saveFile.saveStates[state] = saveState;

        SaveData();
        UpdateSaveSlotMenu();
    }

    public void LoadFromState(int state)
    {

    }

    private void SaveCameraView(Camera cam, int stateNo)
    {
        RenderTexture screenTexture = new RenderTexture(Screen.width, Screen.height, 16);
        cam.targetTexture = screenTexture;
        RenderTexture.active = screenTexture;
        cam.Render();
        Texture2D renderedTexture = new Texture2D(Screen.width, Screen.height);
        renderedTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        RenderTexture.active = null;
        byte[] byteArray = renderedTexture.EncodeToPNG();
        System.IO.File.WriteAllBytes(Application.dataPath + $"/Captures/saveStateIcon{stateNo}.png", byteArray);
        //AssetDatabase.Refresh();
    }

    public void UpdateSaveSlotMenu()
    {
        for (int i = 0; i < 8; i++)
        {
            saveStateSlots[i].UpdateSaveStateSlot(saveFile.saveStates[i].day[0], saveFile.saveStates[i].day[1], saveFile.saveStates[i].day[2], !saveFile.saveStates[i].repairProgress[9]);
            saveStateSlots[i + 8].UpdateSaveStateSlot(saveFile.saveStates[i].day[0], saveFile.saveStates[i].day[1], saveFile.saveStates[i].day[2], !saveFile.saveStates[i].repairProgress[9]);
        }
    }

    public void UpdateSaveFileMenu()
    {

    }

    public void SetCharacterAppearances()
    {
        /*
        for (int character = 0; character < characterRandomisation.Length; character++)
        {
            for (int element = 0; element < 15; element++)
            {
                characterRandomisation[character].ChangeValue(element, saveDataList.characterRandomisations[saveDataList.currentFile * 450 + character * 15 + element]);
                characterRandomisation[character].ChangeName(saveDataList.characterNames[saveDataList.currentFile * 30 + character * 15]);
            }
        }*/
    }

    public void UpdateSaveFileUIElements()
    {
        /*
        for (int file = 0; file < fileNames.Length; file++)
        {
            if (file % 3 == -1)
            {
                fileNames[file].text = $"File {file % 3}: (Empty)";
            }
        }
        */
    }

    private void ConvertFromSGReadWriteableToSG()
    {
        saveGame = new SaveGame(saveFileReadWriteable.SFcurrentFile, saveFileReadWriteable.SFsliderOptions, saveFileReadWriteable.SFotherOptions,
            saveFileReadWriteable.SFcurrentState, saveFileReadWriteable.SFplayerNames, saveFileReadWriteable.SFtools, saveFileReadWriteable.SFcustomerFavour,
            saveFileReadWriteable.SFcustomerAppearence, saveFileReadWriteable.SFday, saveFileReadWriteable.SFrepairProgress);
        saveFile = saveGame.saveFiles[saveGame.currentFile];
        saveState = new SaveState(saveFile.currentState, saveFile.saveStates[saveFile.currentState].customerFavour,
            saveFile.saveStates[saveFile.currentState].customerAppearence, saveFile.saveStates[saveFile.currentState].day, 
            saveFile.saveStates[saveFile.currentState].repairProgress);
    }

    private void ConvertFromSGToSGReadWriteable()
    {
        saveFileReadWriteable.SFcurrentFile = saveGame.currentFile;
        saveFileReadWriteable.SFsliderOptions = saveGame.sliderOptions;
        saveFileReadWriteable.SFotherOptions = saveGame.otherOptions;
        saveFileReadWriteable.SFcurrentState = saveGame.saveFiles[saveGame.currentFile].currentState;
        for (int i = 0; i < 3; i++)
        {
            saveFileReadWriteable.SFplayerNames[i] = saveGame.saveFiles[i].playerName;
        }
        for (int a = 0; a < 3; a++)
        {
            for (int b = 0; b < 20; b++)
            {
                saveFileReadWriteable.SFtools[a * 20 + b] = saveGame.saveFiles[a].tools[b];
            }
        }
        for (int a = 0; a < 3; a++)
        {
            for (int b = 0; b < 8; b++)
            {
                for (int c = 0; c < 20; c++)
                {
                    saveFileReadWriteable.SFcustomerFavour[a * 160 + b * 20 + c] = saveGame.saveFiles[a].saveStates[b].customerFavour[c];
                }
                for (int c = 0; c < 300; c++)
                {
                    saveFileReadWriteable.SFcustomerAppearence[a * 2400 + b * 300 + c] = saveGame.saveFiles[a].saveStates[b].customerAppearence[c];
                }
                for (int c = 0; c < 3; c++)
                {
                    saveFileReadWriteable.SFday[a * 24 + b * 3 + c] = saveGame.saveFiles[a].saveStates[b].day[c];
                }
                for (int c = 0; c < 10; c++)
                {
                    saveFileReadWriteable.SFrepairProgress[a * 80 + b * 10 + c] = saveGame.saveFiles[a].saveStates[b].repairProgress[c];
                }
            }
        }
    }
}

public class SaveGame
{
    public int currentFile = 0;
    public float[] sliderOptions = new float[] { 1f, 1f, 0.5f };
    public int[] otherOptions = new int[16];
    public SaveFile[] saveFiles = new SaveFile[3];

    public SaveGame(int SFcurrentFile, float[] SFsliderOptions, int[] SFotherOptions,
        int SFcurrentState, string[] SFplayerNames, bool[] SFtools, int[] SFcustomerFavour, int[] SFcustomerAppearence, int[] SFday, bool[] SFreapairProgress)
    {
        currentFile = SFcurrentFile;
        sliderOptions = SFsliderOptions;
        otherOptions = SFotherOptions;

        for (int file = 0; file < saveFiles.Length; file++)
        {
            saveFiles[file] = new SaveFile(file, SFcurrentState, SFplayerNames, SFtools,
                SFcustomerFavour, SFcustomerAppearence, SFday, SFreapairProgress);
        }
    }
}

public class SaveFile
{
    public int currentState = 0;
    public string playerName = "Player";
    public bool[] tools = new bool[20];
    public SaveState[] saveStates = new SaveState[8];

    public SaveFile(int file, int SFcurrentState, string[] SFplayerNames, bool[] SFtools, 
        int[] SFcustomerFavour, int[] SFcustomerAppearence, int[] SFday, bool[] SFreapairProgress)
    {
        currentState = SFcurrentState;
        playerName = SFplayerNames[file];
        tools = SFtools[(file * 20)..((file * 20) + 20)];

        for (int state = 0; state < saveStates.Length; state++)
        {
            saveStates[state] = new SaveState(state, SFcustomerFavour, SFcustomerAppearence, SFday, SFreapairProgress);
        }
    }
}

public class SaveState
{
    public int[] customerFavour = new int[20];
    public int[] customerAppearence = new int[300];
    public int[] day = new int[3];
    public bool[] repairProgress = new bool[10];

    public SaveState(int state, int[] SFcustomerFavour, int[] SFcustomerAppearence, int[] SFday, bool[] SFreapairProgress)
    {
        customerFavour = SFcustomerFavour[(state * 20)..((state * 20) + 20)];
        customerAppearence = SFcustomerAppearence[(state * 300)..((state * 300) + 300)];
        day = SFday[(state * 3)..((state * 3) + 3)];
        repairProgress = SFreapairProgress[(state * 10)..((state * 10) + 10)];
    }
}

public class SaveGameStreamReadWriteable
{
    public int SFcurrentFile = 0;
    public float[] SFsliderOptions = new float[] { 1f, 1f, 0.5f };
    public int[] SFotherOptions = new int[16];

    public int SFcurrentState = 0;
    public string[] SFplayerNames = new string[3];
    public bool[] SFtools = new bool[60];

    public int[] SFcustomerFavour = new int[480];
    public int[] SFcustomerAppearence = new int[7200];
    public int[] SFday = new int[84];
    public bool[] SFrepairProgress = new bool[240];
}

//When changing file turn off auto!!!!

/*
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
    public int currentCustomer = 0;
}*/

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
