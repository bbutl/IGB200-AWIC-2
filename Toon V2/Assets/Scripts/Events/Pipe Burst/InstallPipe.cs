using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Dialogue;

public class InstallPipe : MonoBehaviour
{
    public PipeBurst pBurst;
    Vector3 stopMove;
    private bool pipeInstalled = false;
    public bool eventComplete = false;
    private int stepNumber = 1;
    public DialogueManager d;
    private Vector3 orignalPos = new Vector3(-61.8815994f, 4.1500001f, 3.25843453f);
    private Quaternion originalRotation = new Quaternion(0.0308435727f, 0.706433773f, -0.0308435727f, 0.706433773f);
    // Start is called before the first frame update
    void Start()
    {
        stopMove = gameObject.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pipeInstalled == true) { gameObject.transform.position = stopMove; }
        stepNumber = pBurst.stepNumber;
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "New Pipe(Clone)" && pBurst.pipeRemoved == true)
        {
            Destroy(other.gameObject);
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            pipeInstalled = true;
            stepNumber += 1;
        }
        if (other.gameObject.name == "Welder(Clone)" && pipeInstalled)
        {
            Destroy (other.gameObject);
            eventComplete = true;
            
            
            Camera.main.transform.position = orignalPos;
            Camera.main.transform.rotation = originalRotation;
        }
    }
    
}
