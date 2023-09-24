using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class QueueController : MonoBehaviour
{
    /*
     * ORDER OF CHARACTERS (BY INTERNAL NAME)
     * 0 - Lucy
     * 1 - Kate
     * 2 - Sarah
     * 3 - Lily
     * 4 - Steve
     * 5 - Sean
     * 6 - Aiden
     * 7 - Blake
     * 8 - Lachlan
     * 9 - Rohen
     * 10 - Sam
     * 11 - Karen
     * */

    [SerializeField] GameObject[] characters;
    [SerializeField] SaveFileManagement saveFileMangement;
    [SerializeField] DayController dayController;

    private MovementController[] movementCharacters;
    private GenericCharacter[] individualCharacters;

    public List<int>[] order;
    public int currentCharacter = -1;

    void Start()
    {
        order = GenerateOrder();
        GetCharacterScripts();
        Next();
    }

    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            Next();
        }
    }

    public void Next()
    {
        //Remove the current character, make the next character enter, and make them start conversation
        if (currentCharacter < movementCharacters.Length - 1)
        {
            currentCharacter += 1;
            movementCharacters[order[dayController.day][currentCharacter]].GoToTarget(0);
            individualCharacters[order[dayController.day][currentCharacter]].StartConversation();
        }
        else
        {
            DayOver();
        }
        if (currentCharacter > 0)
        {
            movementCharacters[order[dayController.day][currentCharacter - 1]].LeaveShop();
        }
        saveFileMangement.SaveData();
    }

    private void DayOver()
    {
        dayController.NextDay();
        currentCharacter = -1;
        Next();
    }

    private List<int>[] GenerateOrder()
    {
        order = new List<int>[dayController.finalDay];

        //Day 1
        order[0].Add(0);
        order[0].Add(4);
        order[0].Add(1);
        order[0].Add(2);
        order[0].Add(3);
        order[0].Add(5);
        order[0].Add(6);
        order[0].Add(7);
        order[0].Add(8);
        order[0].Add(9);
        order[0].Add(10);
        order[0].Add(11);

        //Day 2
        order[1].Add(0);
        order[1].Add(4);
        order[1].Add(1);

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
}
