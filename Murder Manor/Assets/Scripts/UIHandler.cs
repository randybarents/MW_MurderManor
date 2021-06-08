using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public GameObject DropDownMenuLocations;
    public GameObject DropDownMenuWeapons;
    public GameObject DropDownMenuNPCs;
    public GameObject CommitButton;
    public bool isVisible = false;
    void Start()
    {
        DropDownMenuLocations.SetActive(isVisible);
        DropDownMenuWeapons.SetActive(isVisible);
        DropDownMenuNPCs.SetActive(isVisible);
        CommitButton.SetActive(isVisible);
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            isVisible = !isVisible;
            DropDownMenuLocations.SetActive(isVisible);
            DropDownMenuWeapons.SetActive(isVisible);
            DropDownMenuNPCs.SetActive(isVisible);
            CommitButton.SetActive(isVisible);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
