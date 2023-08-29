using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [Header("Character Lists")]
    public List<GameObject> allCharacters;
    public List<GameObject> selectedCharacters = new List<GameObject>();
    public List<string> avaliableOccupations = new List<string>();
    [Header("Character")]
    public GameObject person;
    public Character c;


    public int maxCharacters = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
        selectedCharacters = ShuffleList(allCharacters);
        avaliableOccupations = CheckAvaliableOccupations(selectedCharacters);
        
        //GenerateChars();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Return a list containing a randomised selecction of characters from allCharacters list
    private List<GameObject> GenerateChars()
    {
        c = person.GetComponent<Character>();
        for (int i = 0; i <maxCharacters; i++)
        {
            
            
        }
        return allCharacters;
       /* foreach (Character c in allCharacters)
        {
            selectedCharacters = allCharacters.Sort((a, b)=> 1 - 2 * Random.Range(0, 1));
        }
        return selectedCharacters;
       */

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

    //Return list containing the occupations of chosen characters

    public List<string> CheckAvaliableOccupations(List<GameObject> charList)
    {
        List<string> list = new List<string>();
        int index = 0;
        Character c;
        string occupation;
        foreach(GameObject character in charList)
        {
            c = charList[index].GetComponent<Character>();
            occupation = c.Occupation;
            list.Add(occupation);
            //list.Add(charList[index].GetComponent<Character>().Occupation);
            index++;
        }
        return list;
    }

    


}
