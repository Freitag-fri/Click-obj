using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickColorData
{
    public readonly string objectType;          //тип создаваемого объекта (куб, сфера, капсула)
    public readonly int minClicksCount;
    public readonly int maxClicksCount;
    public readonly Color color;


    public ClickColorData(string objectType, int minClicksCount, int maxClicksCount, Color color)
    {
        this.objectType = objectType;
        this.minClicksCount = minClicksCount;
        this.maxClicksCount = maxClicksCount;
        this.color = color;
    }
}
