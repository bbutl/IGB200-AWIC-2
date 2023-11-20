using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTally : MonoBehaviour
{
    public int tally = 0;
    public Bench bench;
    public Roofer roofer;
    public InstallPipe installPipe;
    public Weld weld;
   public DayController dayController;
    public GameObject NPC1;
    public GameObject NPC2;
    public GameObject NPC3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (installPipe.eventComplete)
        {
            tally++;
        }
        if (bench.benchFinish)
        {

            tally++;
        }
        if (roofer.roofFinished)
        {
            tally++;
        }
        if (weld.weldFinish)
        {
            tally++;
        }
        if(tally >= 2 && dayController.day == 5)
        {
            Debug.Log("g");
            NPC1.gameObject.SetActive(true);
            NPC2.gameObject.SetActive(true);
            NPC3.gameObject.SetActive(true);
        }
    }
}
