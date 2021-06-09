using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodScript : MonoBehaviour
{

    void Awake()
    {
        GameObject.FindGameObjectWithTag("BloodTrigger").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
