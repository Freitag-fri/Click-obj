using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GeometryObjectData", menuName = "GeometryObjectData", order = 51)]
public class GeometryObjectData : ScriptableObject
{
    public List<ClickColorData> clicksData = new List<ClickColorData>();
    public GeometryObjectData()
    {
        clicksData.Add(new ClickColorData("Cube", 3, 5, Color.red));
        clicksData.Add(new ClickColorData("Cube", 6, 8, Color.green));

        clicksData.Add(new ClickColorData("Capsule", 1, 2, Color.yellow));
        clicksData.Add(new ClickColorData("Capsule", 4, 6, Color.white));

        clicksData.Add(new ClickColorData("Sphere", 2, 5, Color.black));
        clicksData.Add(new ClickColorData("Sphere", 6, 7, Color.blue));
    } 
}
