using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NameFigure
{
    public string[] INFO;
}

public class MainController : MonoBehaviour
{
    NameFigure jsonName = new NameFigure();
    private GeometryObjectData geometryObjectData;

    void Start()
    {
        string json = File.ReadAllText(Application.dataPath + "/Scenes/Resources/ListObjectType.txt");  //загружаем названия фигур
        jsonName = JsonUtility.FromJson<NameFigure>(json);
        geometryObjectData = Resources.Load("Prefab/GeometryObjectData") as GeometryObjectData;         //загружаем условия смены цвета
    }

    void Update()
    {
        ClickMouse();
    }


    void ClickMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))                         //увеличиваем счетчик
            {
                GameObject click = hit.transform.gameObject;
                if(click.GetComponent<GeometryObjectModel>() != null)
                {
                    click.GetComponent<GeometryObjectModel>().OnClick();
                }
                
            }
            else                                                            //создаем обект 
            {
                Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                GameObject buf;
                GameObject randPrefab = RandFigure();
                buf = Instantiate(randPrefab, position, Quaternion.identity);
                if(buf.GetComponent<GeometryObjectModel>())
                {
                    buf.GetComponent<GeometryObjectModel>().objectType = randPrefab.name;
                    buf.GetComponent<GeometryObjectModel>().GeometryObjectData = geometryObjectData;
                }
                else
                {
                    Destroy(buf);
                    Debug.Log("Нету скрипта GeometryObjectModel у " + randPrefab.name.ToString());
                    return;
                }

                buf.transform.SetParent(this.transform); 
            }
        }
    }

    GameObject RandFigure()
    {
        int numFigure = jsonName.INFO.Length;
        var num = Random.Range(0, numFigure);
        GameObject buf = Resources.Load("Prefab/" + jsonName.INFO[num]) as GameObject;

        return buf;
    }
}
