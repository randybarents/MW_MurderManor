using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsnwerChecker : MonoBehaviour
{
    public Button button;

    public Dropdown DropdownLocations;
    public Dropdown DropdownWeapons;
    public Dropdown DropdownNPCs;
    public GameObject Answer;
 
    public bool pressButton = false;
    void Start()
    {
        button = transform.GetComponent<Button>();
        button.onClick.AddListener(() => CheckAnswer(DropdownLocations.captionText.text, DropdownWeapons.captionText.text, DropdownNPCs.captionText.text));
    }

    bool CheckAnswer(string location, string weapon, string npc)
    {
        List<string> textList = new List<string>();

        foreach(var child in Answer.GetComponentsInChildren<Text>())
        {
            if(child.text == location || child.text == weapon || child.text == npc) 
            {
                textList.Add(child.text);
            }
        }

        if(!textList.Contains(location) || !textList.Contains(weapon) || !textList.Contains(npc))
        {
            foreach(var item in textList){
                    Debug.Log(item);
            }
            Debug.Log(weapon);
            Debug.Log("false");
            return false;       
        } 
        else
        {
            Debug.Log("True");
            Debug.Log(location);
            Debug.Log(weapon);
            Debug.Log(npc);
            return true;
        }
    }
}
