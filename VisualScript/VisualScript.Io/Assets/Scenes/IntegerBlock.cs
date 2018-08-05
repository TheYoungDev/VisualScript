using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntegerBlock : MonoBehaviour {

    public int value;
    public InputField InputField;
    public bool followMouse = true;
    public float speed = 6f;
    public Vector3 mousePosition;
    public Canvas myCanvas;
    public GameObject ManagerObject;
    public List<GameObject> ConnectedObjects;

    void Start()
    {
        myCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        ManagerObject = GameObject.Find("ApplicationManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (followMouse)
        {
            FollowMouse();
        }


    }

    public void FollowMouse()
    {

        //usingUI
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
        if (myCanvas != null)
            transform.position = myCanvas.transform.TransformPoint(pos);
        //Cursor.visible = true;
    }
    public void Clicked()
    {
        followMouse = !followMouse;
    }
    public void DestorySelf()
    {
        Destroy(gameObject);
    }

    public void updateValue()
    {
        value = int.Parse(InputField.text);
    }
    public void ClickoutputButton()
    {
        if (ManagerObject.GetComponent<CreateFunctionBlock>().CurrentButton != gameObject && ManagerObject.GetComponent<CreateFunctionBlock>().LastButton != gameObject)
        {
            ManagerObject.GetComponent<CreateFunctionBlock>().buttonClick(gameObject);
           // ConnectedObjects.Add
        }
            

    }
}
