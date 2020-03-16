using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;



public class GeometryObjectModel : MonoBehaviour
{
    
    public int clickCount;
    //private Color cubeColor;
    public string objectType;

    public GeometryObjectData GeometryObjectData { get; set; }
    public GameData gameData;                       //таймер  

    void Start()
    {
        SetRandomColor();
        
        Observable.Timer(System.TimeSpan.FromSeconds(gameData.observableTime)) // создаем timer Observable
        .Repeat() // делает таймер циклическим
        .Subscribe(_ =>
        { 
            SetRandomColor();   // подписываемся
        });
    }

    public void SetRandomColor()
    {
        var r = Random.Range(0.0f, 1.0f);
        var g = Random.Range(0.0f, 1.0f);
        var b = Random.Range(0.0f, 1.0f);
        GetComponent<MeshRenderer>().material.color = new Color(r, g, b, 1); 
    }

    public void OnClick()
    {
        clickCount++;
        SetColor();
    }

    public void SetColor()
    { 
        foreach(ClickColorData i in GeometryObjectData.clicksData)
        {
            if(objectType == i.objectType && clickCount <= i.maxClicksCount && clickCount >= i.minClicksCount)
            {
                GetComponent<MeshRenderer>().material.color = i.color;
            }
        } 
    }
}
