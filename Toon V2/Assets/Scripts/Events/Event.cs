using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public int currDay;
    public int eventDay;
    public string associatedOccupation;

    public EventManager eventManager;
    public List<string> occupationList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool ContainsOccupation(List<string> list)
    {
        if (list.Contains(associatedOccupation))
        {
            return true;
        }
        else return false;
    }
    public void InitialiseEvent()
    {
        // Add check for current day and target day number
        if (ContainsOccupation(occupationList))
        {

        }
        else
        {
            return;
        }
    }
}
