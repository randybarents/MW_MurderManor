using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomDetection : MonoBehaviour
{
    public Text textBox;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            textBox.text = "";
            textBox.text = transform.parent.name;
            Debug.Log("Player entered "+ transform.parent.name);
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player exited " + transform.parent.name);
        }
    }
}
