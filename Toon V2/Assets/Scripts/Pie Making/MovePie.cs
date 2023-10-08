using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MovePie : MonoBehaviour
{
    public Transform a;
    public Transform b;
    public float moveSpeed;
    private Transform current;
    private Transform target;
    private float sinTime;
    // Start is called before the first frame update
    void Start()
    {
        b = GameObject.Find("Target").transform;
        current = a;
        target = b;
        transform.position = current.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != target.position)
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
    
}
