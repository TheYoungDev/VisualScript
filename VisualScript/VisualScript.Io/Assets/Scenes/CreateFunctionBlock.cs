using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public struct CurrentInput {
    string type;
    GameObject InputObject;

}
public struct CurrentOutput
{
    string type;
    GameObject InputObject;

}*/



public class CreateFunctionBlock : MonoBehaviour {

    public MonoBehaviour BlockScript;//not used
    public GameObject[] BlockSprite;
    public int Index;
    public Camera MainCam;
    public GameObject parent;
    public string InputType;
    public GameObject InputObject;
    public string OutputType;
    public GameObject OutputObject;
    public List<GameObject> InputObjects;
    public List<GameObject> OutputObjects;


    public GameObject LastButton;
    public GameObject CurrentButton;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    public void Create_FunctionBlock(int _index)
    {
        if (_index > BlockSprite.Length)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray))
        {
            GameObject GO = Instantiate(BlockSprite[_index], Input.mousePosition, Quaternion.identity);
            GO.transform.parent = parent.transform;
        }
           
        //    Instantiate(BlockSprite, transform.position, transform.rotation);
        else
        {
            GameObject GO = Instantiate(BlockSprite[_index], new Vector2(0, 0), Quaternion.identity);
            GO.transform.parent = parent.transform;
        }
           
    }
    public void InputClick(string Type, GameObject GO)
    {
        InputObjects.Add(GO);

    }
    public void OutputClick(string Type, GameObject GO)
    {
        OutputObjects.Add(GO);

    }
    public void conditionalBlock(string Type, GameObject GO)
    {


    }
    public void buttonClick(GameObject GO)
    {
        LastButton = CurrentButton;
        CurrentButton = GO;
    }


}
