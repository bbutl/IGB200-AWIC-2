using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Dialogue;

public class InstallPipe : MonoBehaviour
{
    public GameObject pea;
    public GameObject shroom;
    public PipeBurst pBurst;
    Vector3 stopMove;
    private bool pipeInstalled = false;
    public bool eventComplete = false;
    private int stepNumber = 1;
    public DialogueManager d;
    private Vector3 orignalPos = new Vector3(-66.677002f, 4.4000001f, 3.56999993f);
    private Quaternion originalRotation = new Quaternion(0, 0.707106829f, 0, 0.707106829f);
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
            
            pea.gameObject.SetActive(true);
            shroom.gameObject.SetActive(true);
            Camera.main.transform.position = orignalPos;
            Camera.main.transform.rotation = originalRotation;
        }
    }
    
}
