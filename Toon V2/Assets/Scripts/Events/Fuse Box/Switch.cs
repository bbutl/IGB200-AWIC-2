using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Slot slot;
    public GameObject Plate;
    public GameObject lightSwitch;
    public GameObject switchBoard;
    private Animator anim;
    public AnimatorOverrideController overrider;
    private bool isOff = false;
    public bool complete = false;
    private float speed = 1f;
    private float timer = 1f;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = switchBoard.GetComponent<Animator>();
        anim.enabled = false;
    }
    void Start()
    {
        lightSwitch.GetComponent<BoxCollider>().enabled = false;
        anim.enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Plate == null)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        Invoke("RemoveLightFuse", 1.5f);
    }
    private void OnMouseDown()
    {
        SetAnimation();
    }
    private void SetAnimation()
    {
        anim.enabled = true;
        anim.runtimeAnimatorController = overrider;
        isOff = true;
    }
    private void RemoveLightFuse()
    {
        if (isOff && !complete)
        {

            if (lightSwitch.transform.position.z > 21.14f)
            {
                lightSwitch.transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
            }
            else if(lightSwitch.transform.position.x < -62.7f)
            {
                lightSwitch.transform.position += new Vector3((speed * 2.5f) * Time.deltaTime, 0, 0);
            }
            else
            {
                complete = true;
                slot.enabled = true;
            }

        }
    }
    public void Dtroy()
    {
        Destroy(lightSwitch);
    }
}
