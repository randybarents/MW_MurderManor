using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodScript : MonoBehaviour
{

    public GameObject blood;

    void Awake()
    {
        GameObject.FindGameObjectWithTag("BloodTrigger");
        blood.SetActive(false);
    }

    public void ActivateBlood()
    {
        blood.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
