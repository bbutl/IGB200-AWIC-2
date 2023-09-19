using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManagerOld : MonoBehaviour
{
    [Header("Character Lists")]
    public List<GameObject> allCharacters;
    public List<GameObject> selectedCharacters = new List<GameObject>();
    public List<string> avaliableOccupations = new List<string>();

    [Header("Character")]
    
    public Character c;
    public int maxCharacters = 3;

    // Generate randomly selected characters on start && their assigned occupations
    void Start()
    {

        selectedCharacters = ShuffleList(allCharacters);
        avaliableOccupations = CheckAvaliableOccupations(selectedCharacters);

    }



    //Shuffle list of characters in a random order
    //First x characters are chosen to be instantiated from shuffled list 
    private List<GameObject> ShuffleList(List<GameObject> listToShuffle)
    {
        System.Random rand = new System.Random();
        for (int i = listToShuffle.Count - 1; i > 0; i--)
        {
            var k = rand.Next(i + 1);
            var value = listToShuffle[k];
            listToShuffle[k] = listToShuffle[i];
            listToShuffle[i] = value;
        }
        return listToShuffle;
    }

    //Return list containing the occupations of the selected characters

    public List<string> CheckAvaliableOccupations(List<GameObject> charList)
    {
        List<string> list = new List<string>();
        int index = 0;
        Character c;
        string occupation;
        foreach (GameObject character in charList)
        {
            c = charList[index].GetComponent<Character>();
            occupation = c.Occupation;
            list.Add(occupation);
            index++;
        }
        list = list.GetRange(0, maxCharacters);
        return list;
    }




}
