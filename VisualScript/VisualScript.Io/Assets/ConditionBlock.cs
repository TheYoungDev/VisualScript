

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionBlock : MonoBehaviour
{

    public bool followMouse = true;
    public float speed = 6f;
    public Vector3 mousePosition;
    public Canvas myCanvas;
    public string InputType;
    public GameObject InputObject;
    public string OutputType;
    public GameObject OutputObject;
    public GameObject Output_Object;
    public List<GameObject> OutputObjectList;

    public GameObject ManagerObject;
    public int A;
    public int B;
    public int Call = 0;


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
        if(Output_Object != null && Output_Object.GetComponent<DebugBlock>())
        {
           // Debug.Log("test");
            if(A==B)
                Output_Object.GetComponent<DebugBlock>().LogMessage("True");
            else
                Output_Object.GetComponent<DebugBlock>().LogMessage("False");
        }
        if (InputObject != null && InputObject.GetComponent<DebugBlock>())
        {
            // Debug.Log("test");
           
            A=InputObject.GetComponent<IntegerBlock>().value;

        }

    }

    public void FollowMouse()
    {

        //useing UI
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
    public void ClickAButton()
    {

        if (ManagerObject.GetComponent<CreateFunctionBlock>().CurrentButton != null)
        {
            GameObject OtherButton = ManagerObject.GetComponent<CreateFunctionBlock>().CurrentButton;
            if (OtherButton.GetComponent<IntegerBlock>())
            {
                A = OtherButton.GetComponent<IntegerBlock>().value;
                InputObject = OtherButton;
            }
        }
        else if (ManagerObject.GetComponent<CreateFunctionBlock>().CurrentButton != gameObject && ManagerObject.GetComponent<CreateFunctionBlock>().LastButton != gameObject)
        {
            ManagerObject.GetComponent<CreateFunctionBlock>().buttonClick(gameObject);
        }
 
        ManagerObject.GetComponent<CreateFunctionBlock>().buttonClick(gameObject);
    }
    public void ClickBButton()
    {
        if (ManagerObject.GetComponent<CreateFunctionBlock>().CurrentButton != null)
        {
            GameObject OtherButton = ManagerObject.GetComponent<CreateFunctionBlock>().CurrentButton;
            if (OtherButton.GetComponent<IntegerBlock>())
            {
                B = OtherButton.GetComponent<IntegerBlock>().value;
                OutputObject = OtherButton;
            }
        }
        else if (ManagerObject.GetComponent<CreateFunctionBlock>().CurrentButton != gameObject && ManagerObject.GetComponent<CreateFunctionBlock>().LastButton != gameObject)
            ManagerObject.GetComponent<CreateFunctionBlock>().buttonClick(gameObject);

    }


    public void ClickEqualsButton()
    {

        /* (ManagerObject.GetComponent<CreateFunctionBlock>().CurrentButton != null)
        {
            Debug.Log("== connection");
            GameObject OtherButton = ManagerObject.GetComponent<CreateFunctionBlock>().CurrentButton;

        }*/
        if (ManagerObject.GetComponent<CreateFunctionBlock>().CurrentButton == null)
        {
            ManagerObject.GetComponent<CreateFunctionBlock>().buttonClick(gameObject);
        }
        if (Output_Object == null && ManagerObject.GetComponent<CreateFunctionBlock>().CurrentButton !=gameObject)
        {
            Output_Object = ManagerObject.GetComponent<CreateFunctionBlock>().CurrentButton;
        }
        if (Output_Object.GetComponent<DebugBlock>())
        {
                if (A == B)
                Output_Object.GetComponent<DebugBlock>().LogMessage("True");
                else
                Output_Object.GetComponent<DebugBlock>().LogMessage("False");


            Output_Object = ManagerObject.GetComponent<CreateFunctionBlock>().CurrentButton; 
                OutputObjectList.Add(Output_Object);

        }
        else
        {
            if (ManagerObject.GetComponent<CreateFunctionBlock>().LastButton != null) {
                Debug.Log("yes");
                Output_Object = ManagerObject.GetComponent<CreateFunctionBlock>().LastButton;
                if (Output_Object.GetComponent<DebugBlock>()) { 
                    if (A == B)
                        Output_Object.GetComponent<DebugBlock>().LogMessage("True");
                    else
                        Output_Object.GetComponent<DebugBlock>().LogMessage("False");

                    Debug.Log("y2es");
                    Output_Object = ManagerObject.GetComponent<CreateFunctionBlock>().LastButton;
                    OutputObjectList.Add(OutputObject);

                }
            }
        }
        if (ManagerObject.GetComponent<CreateFunctionBlock>().CurrentButton != gameObject && ManagerObject.GetComponent<CreateFunctionBlock>().LastButton != gameObject)
        {
            ManagerObject.GetComponent<CreateFunctionBlock>().buttonClick(gameObject);
        }



    }



    public void OutputClick(string Type, GameObject GO)
    {


    }
    public void ConditionalBlock(string Type, GameObject GO)
    {


    }
}
