using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [Header("Character Lists")]
    public List<Character> allCharacters;
    public List<Character> selectedCharacters = new List<Character>();

    [Header("Character")]
    public GameObject person;
    public Character c;


    public int maxCharacters = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
        selectedCharacters = ShuffleList(allCharacters);

        
        //GenerateChars();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Return a list containing a randomised selecction of characters from allCharacters list
    private List<Character> GenerateChars()
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
    private List<Character> ShuffleList(List<Character> listToShuffle)
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
}
