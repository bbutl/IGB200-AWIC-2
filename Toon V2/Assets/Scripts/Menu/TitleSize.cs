using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSize : MonoBehaviour
{
    [SerializeField] private GameObject self;
    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;
    [SerializeField] private float speed;

    private float currentSize = 1;
    private int direction = 1;

    void Update()
    {
        currentSize += speed * direction * Time.deltaTime;
        self.transform.localScale = new Vector3(currentSize, currentSize, 1);

        if (currentSize > maxSize)
        {
            direction = -1;
        }
        if (currentSize < minSize)
        {
            direction = 1;
        }
    }
}
