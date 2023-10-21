using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePie2 : MonoBehaviour
{
    public Transform a;
    public Transform b;
    public float moveSpeed;
    private Transform current;
    private Transform target;
    private float sinTime;
    public MovePie MP;
    // Start is called before the first frame update
    void Start()
    {
        MP.enabled = false;
        b = GameObject.Find("Pie Target 2").transform;
        current = a;
        target = b;
        transform.position = current.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != target.position)
        {
            sinTime += Time.deltaTime * moveSpeed;
            sinTime = Mathf.Clamp(sinTime, 0, Mathf.PI);
            float t = evaluate(sinTime);
            transform.position = Vector3.Lerp(current.position, target.position, t);
            Invoke("Dtroy", 2.2f);
        }
        else
        {
            Dtroy();
        }
    }
    public float evaluate(float x)
    {
        return 0.5f * Mathf.Sin(x - Mathf.PI / 2) + 0.5f;
    }
    public void Dtroy()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
