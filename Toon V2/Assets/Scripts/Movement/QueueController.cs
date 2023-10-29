using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
public class QueueController : MonoBehaviour
{
    /*
     * ORDER OF CHARACTERS (BY INTERNAL NAME)
     * 0 - Susan
     * 1 - Plumber
     * 2 - Sarah
     * 3 - Lily
     * 4 - Steve
     * 5 - 
     * 6 - Aiden
     * 7 - Blake
     * 8 - Lachlan
     * 9 - Sean
     * 10 - Sam
     * 11 - Karen
     * */

    [SerializeField] GameObject[] characters;
    [SerializeField] SaveFileManagement saveFileMangement;
    [SerializeField] DayController dayController;
    [SerializeField] DialogueManager dialogueManager;

    private MovementController[] movementCharacters;
    private GenericCharacter[] individualCharacters;

    public int[][] order = new int[8][];
    public int currentCharacter = -1;

    public GameObject pie;
    public SoundManager soundManager;
    private void Awake()
    {
        SelectWorkers();
    }
    void Start()
    {
        order = GenerateOrder();
        GetCharacterScripts();
        Next();
    }

    void Update()
    {
        pie = GameObject.FindGameObjectWithTag("Pie");
        if (Input.GetKeyDown("x") && Time.timeScale != 0)
        {
            Next();
        }
    }

    public void Next()
    {
        //Remove the current character, make the next character enter, and make them start conversation
        if (currentCharacter >=  0)
        {
            movementCharacters[order[dayController.day][currentCharacter]].LeaveShop();
            soundManager.DoorChime();
            if (pie != null)
            {
                Destroy(pie);
            }
        }
        if (currentCharacter < order[dayController.day].Length - 1)
        {
            currentCharacter += 1;
            movementCharacters[order[dayController.day][currentCharacter]].GoToTarget(0);
            int day = dayController.day;
            switch (day)
            {
                case 0:
                    individualCharacters[order[dayController.day][currentCharacter]].StartConversation();
                    break;
                case 1:
                    individualCharacters[order[dayController.day][currentCharacter]].Day2Start();
                    break;
                case 2:
                    individualCharacters[order[dayController.day][currentCharacter]].Day3Start();
                    break;
                case 3:
                    individualCharacters[order[dayController.day][currentCharacter]].Day4Start();
                    break;
                case 4:
                    individualCharacters[order[dayController.day][currentCharacter]].Day5Start();
                    break;
                case 5:
                    individualCharacters[order[dayController.day][currentCharacter]].Day6Start();
                    break;
            }


            }
        else
        {
            DayOver();
        }
        //saveFileMangement.SaveData();
    }

    private void DayOver()
    {
        dialogueManager.ResetHistory();

        if (dayController.day < dayController.finalDay)
        {
            dayController.NextDay();
            currentCharacter = -1;
            Next();
        }
        if (dayController.day == dayController.finalDay)
        {
            //Place every character in the shop
            foreach (MovementController character in movementCharacters)
            {
                character.GoToTarget(2);
            }
        }
    }

    private int[][] GenerateOrder()
    {
        //order[0] = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        //Sean Only
        order[0] = new int[] { 11, 9 };
        //Sean, Susan, Plumber
        order[1] = new int[] { 11, 9, 0, 1 };
        //Sean, 
        order[2] = new int[] { 11, 9, 1};
        order[3] = new int[] { 11, 2, 5 };
        order[4] = new int[] { 11, 7, 10 };
        order[5] = new int[] { 11, 9, 0};
        order[6] = new int[] { 5, 11 };
        order[7] = new int[] { 6, 7, 10, 1 };

        return order;
    }
    
    private void GetCharacterScripts()
    {
        //Get all of the characters' corresponding 'MovementController' scripts
        movementCharacters = new MovementController[characters.Length];
        for (int character = 0; character < movementCharacters.Length; character++)
        {
            movementCharacters[character] = characters[character].GetComponent<MovementController>();
        }

        //Get all of the characters' corresponding uniquelly named scripts
        individualCharacters = new GenericCharacter[characters.Length];
        for (int character = 0; character < individualCharacters.Length; character++)
        {
            individualCharacters[character] = characters[character].GetComponent<GenericCharacter>();
        }
    }
    private void SelectWorkers()
    {
        int select = Random.Range(0, 2);
       if(select == 0)
        {
            characters[1] = GameObject.Find("Carpenter");
        }
        else
        {
            characters[1] = GameObject.Find("Plumber");
        }
    }
}
