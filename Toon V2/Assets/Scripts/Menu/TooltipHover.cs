using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipHover : MonoBehaviour
{
    public TooltipLocation tooltipLocation;
    public int tooltipIndex;

    public void OnMouseOver()
    {
        tooltipLocation.ShowTooltip(tooltipIndex);
    }

    public void OnMouseExit()
    {
        tooltipLocation.HideTooltip();
    }
}
