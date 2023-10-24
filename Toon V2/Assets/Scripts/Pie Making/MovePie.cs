using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MovePie : MonoBehaviour
{
    public MovePie2 MP2;
    public Transform a;
    public Transform b;
    public float moveSpeed;
    private Transform current;
    private Transform target;
    private float sinTime;
    private Animator animator;
    private GameObject Hands;
    private GameObject ForeArm;
    private Vector3 offset = new Vector3 (-0.09f, 0.5f, 0.5f);
    private bool startMove = false;
    private bool hasRotated = false;
    public DialogueManager dialogueManager;
    public GameObject mesh;
    public GameObject mesh2;
    public GameObject mesh3;
    // Start is called before the first frame update
    void Start()
    {
        b = GameObject.Find("Pie Target").transform;
        current = a;
        target = b;
        transform.position = current.position;
        animator = GameObject.Find("Male Body").GetComponent<Animator>();
        Hands = GameObject.Find("Character1_LeftArm");
        ForeArm = GameObject.Find("Character1_LeftForeArm");
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("isTaking"))
        {
            MP2.enabled = true;
            b = GameObject.Find("Pie Target 2").transform;
            target = b;
            Invoke("Dtroy", 2.2f);
        }
        
        if (transform.position != target.position)
        {
            sinTime += Time.deltaTime * moveSpeed;
            sinTime = Mathf.Clamp(sinTime, 0, Mathf.PI);
            float t = evaluate(sinTime);
            transform.position = Vector3.Lerp(current.position, target.position, t);
        }
        
    }
    public float evaluate(float x)
    {
        return 0.5f * Mathf.Sin(x - Mathf.PI / 2) + 0.5f;
    }
    public void Dtroy()
    {
        mesh.GetComponent<MeshRenderer>().enabled = false;
        mesh2.GetComponent<MeshRenderer>().enabled = false;
        mesh3.GetComponent<MeshRenderer>().enabled = false;
    }
    public void ChangeTarget()
    {
        if(dialogueManager.contentsText.text == "Eat.")
        {
            b = GameObject.Find("Pie Target 2").transform;
        }
        
    }
}
