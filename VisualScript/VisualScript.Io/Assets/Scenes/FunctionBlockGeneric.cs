using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunctionBlockGeneric : MonoBehaviour {

    public bool followMouse = true;
    public float speed = 6f;
    public Vector3 mousePosition;
    public Canvas myCanvas;
    public string InputType;
    public GameObject InputObject;
    public string OutputType;
    public GameObject OutputObject;


    public GameObject LastButton;
    public GameObject CurrentButton;

    void Start () {
        myCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();

    }
	
	// Update is called once per frame
	void Update () {
        if (followMouse)
        {
            FollowMouse();
        }
            
        else
        {

                
        }


    }

    public void FollowMouse()
    {

        //usingUI
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
        if(myCanvas !=null)
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
    public void InputClick(string Type, GameObject GO)
    {
        

    }
    public void OutputClick(string Type, GameObject GO)
    {


    }
    public void conditionalBlock(string Type, GameObject GO)
    {


    }

}
