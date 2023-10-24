using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : MonoBehaviour
    
{ 
    GameObject target;
    Vector3 rotation = new Vector3(0,0,1f);
    float speed = 12f;
    public bool start = false;
    private bool unscrewed = false;
    private float timer = 0;

    [SerializeField] private TooltipLocation tooltip;
    [SerializeField] private int tooltipNumber;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Fuse Target");
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            timer += Time.deltaTime;
            if(timer < 3)
            {
                gameObject.transform.Rotate(rotation, 10 * Time.deltaTime * speed);
                
            }
            else
            {
                start = false;
                unscrewed = true;
                
            }
            
        }
        MoveScrew();
    }
    private void OnMouseDown()
    {
        start = true;
    }
    private void MoveScrew()
    {
        if(unscrewed)
        {
            if (transform.position.z > 21.14f)
            {
                transform.position += new Vector3(0, 0, -1.5f * Time.deltaTime);
            }
            else
            {
                transform.position += new Vector3(1.5f * Time.deltaTime, 0, 0 );
                Invoke("Dtroy", 1f);
            }
        }
        
    }
    public void Dtroy()
    {
        Destroy(gameObject);
    }

    public void OnMouseOver()
    {
        tooltip.ShowTooltip(tooltipNumber);
    }

    public void OnMouseExit()
    {
        tooltip.HideTooltip();
    }
}
