using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tool : MonoBehaviour
{
    [SerializeField] private string toolName;
    [SerializeField] private string toolDesc;
    private GameObject toolUI;
    private TextMeshProUGUI toolNameText;
    // Start is called before the first frame update
    void Start()
    {
        toolUI = GameObject.Find("Tool UI");
        toolNameText = toolUI.GetComponent<TextMeshProUGUI>();
        toolUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        toolUI.SetActive(true); 
        toolNameText.text = $"Tool Name: {toolName}";
    }
    private void OnMouseExit()
    {
        toolUI.SetActive(false);
    }
}
