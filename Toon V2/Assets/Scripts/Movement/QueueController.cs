using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class QueueController : MonoBehaviour
{
    [SerializeField] MovementController[] characters;
    [SerializeField] Lucy lucy;
    [SerializeField] Sarah sarah;
    [SerializeField] Kate kate;
    [SerializeField] Lily lily;
    [SerializeField] Steve steve;

    public List<int> order = new List<int>();
    public int currentCharacter = -1;

    void Start()
    {
        order = GenerateOrder();
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
        currentCharacter += 1;
        if (currentCharacter < characters.Length)
        {
            StartNextCharacter(order[currentCharacter]);
        }
        if (currentCharacter > 0 && currentCharacter < characters.Length)
        {
            characters[order[currentCharacter - 1]].LeaveShop();
        }
    }

    public void StartNextCharacter(int next)
    {
        characters[next].GoToTarget(0);
        switch (next)
        {
            case 0:
                lucy.StartConversation();
                break;
            case 1:
                sarah.StartConversation();
                break;
            case 2:
                kate.StartConversation();
                break;
            case 3:
                lily.StartConversation();
                break;
            case 4:
                steve.StartConversation();
                break;
            default:
                Debug.Log("Oopsie!");
                break;
        }            
    }

    private List<int> GenerateOrder()
    {

        order.Add(0);
        order.Add(4);
        order.Add(1);
        order.Add(2);
        order.Add(3);
        for (int i = 0; i < characters.Length; i++)
        {
            order.Add(i);
        }
        //List<int> newList = order.OrderBy(_ => _rand.Next()).ToList();
        return order;
    }
}
