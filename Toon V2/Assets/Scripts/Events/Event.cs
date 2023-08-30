using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Event class which all events will inherit from
public class Event : MonoBehaviour
{
    public int currDay;
    public int eventDay;
    public string associatedOccupation;

    public EventManager eventManager;
    public List<string> occupationList;


    

    public bool ContainsOccupation(List<string> list)
    {
        if (list.Contains(associatedOccupation))
        {
            return true;
        }
        else return false;
    }
    public bool InitialiseEvent()
    {
        // Add check for current day and target day number
        if (ContainsOccupation(occupationList))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
