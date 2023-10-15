using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public OpenDoor door;
    public Switch sw;
    public GameObject Fuse;
    public GameObject FuseSpawn;
    public bool startMove = false;
    public bool plateMove = false;
    public GameObject Plate;
    private float speed = 1f;
    private bool plateSpawned = false;
    private Vector3 offset = new Vector3 (4, 0, 0);
    private Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        Fuse = Instantiate(Fuse, FuseSpawn.transform.position, Quaternion.identity);
        Fuse.transform.Rotate(0, 270, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        Plate.GetComponent<BoxCollider>().enabled = false;
        MoveFuse();
        MovePlate();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Fuse_Prefab(Clone)")
        {
            Fuse.transform.position = gameObject.transform.position;
            startMove = true;
            Fuse.GetComponent<BoxCollider>().enabled = false;
        }
        
    }
    private void MoveFuse()
    {
        if(startMove)
        {
            if (Fuse.transform.position.z < 21.866)
            {
                Fuse.transform.position += new Vector3(0, 0, (speed * 2f) * Time.deltaTime);
            }
            else if(!plateSpawned)
            {
                plateSpawned = true;
                originalPos = Plate.transform.position;
                Plate = Instantiate(Plate, Plate.transform.position + offset, Quaternion.identity);
                
                Plate.transform.transform.Rotate(0, 270, 0);
                plateMove = true;
            }
        }
        
    }
    private void MovePlate()
    {
        if (plateMove)
        {
            if (Plate.transform.position.x > originalPos.x)
            {
                Plate.transform.position -= new Vector3((speed * 2f) * Time.deltaTime, 0, 0);
            }
            else
            {
                door.close = true;
            }
        }
        
    }
}
