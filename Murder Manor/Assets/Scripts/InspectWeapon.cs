using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectWeapon : MonoBehaviour
{
    public GameObject weapon;
    public GameObject prefabPosition;
    public bool inspectionHappening;

    // Start is called before the first frame update
    void Start()
    {
        inspectionHappening = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CheckWeapon();
        }
        if (inspectionHappening)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                weapon.transform.Rotate(new Vector3(0, 0.5f, 0));       //rotate left
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                weapon.transform.Rotate(new Vector3(0, -0.5f, 0));      //rotate right
            }
            if (Input.GetKey(KeyCode.UpArrow) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                if (weapon.transform.localScale.z < 10)
                {
                    weapon.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);    //zoom in
                }
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                weapon.transform.Rotate(new Vector3(0, 0, 0.5f));       //rotate up
            }
            if (Input.GetKey(KeyCode.DownArrow) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                if (weapon.transform.localScale.z > 1)
                {
                    weapon.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);    //zoom out
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                weapon.transform.Rotate(new Vector3(0, 0, -0.5f));      //rotate down
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                inspectionHappening = false;        //stop inspection
                Destroy(weapon);                    //de-instantieër weapon
            }
        }
    }

    public void PlayerInteract()
    {
        weapon = Instantiate(weapon, prefabPosition.transform.position, prefabPosition.transform.rotation , prefabPosition.transform);
        inspectionHappening = true;
    }

    public void CheckWeapon()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position,transform.forward,out hit))
        {
            if (hit.transform.tag == "Weapon")
            {
                weapon = hit.transform.gameObject;
                PlayerInteract();
            }
        }
    }
}
