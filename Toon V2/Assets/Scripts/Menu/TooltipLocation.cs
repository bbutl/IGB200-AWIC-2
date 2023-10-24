using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TooltipLocation : MonoBehaviour
{
    [SerializeField] private Transform tooltip;
    [SerializeField] private GameObject self;
    [SerializeField] private TextMeshProUGUI nameText;

    private string[] names = new string[] { "Pie Base", "Pie Lid", "Mince", "Peas", "Mushrooms", "", "", "", "", "", "", "", "", "", "", //0 - 14 Ingredients
        "Pipe Cutter", "Broken Pipe", "New Pipe", "Welder", //15 - 19 Pipe event
        "Screw", "Panel", "Broken Fuse", "New Fuse",}; //20 - 24 Fuse Event

    void Update()
    {
        tooltip.position = Input.mousePosition;
    }

    public void ShowTooltip(int item)
    {
        nameText.text = names[item];
        self.SetActive(true);
    }

    public void HideTooltip()
    {
        self.SetActive(false);
    }
}
