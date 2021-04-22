using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    Animator m_Animator;
    bool doorOpen = false;


    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        bool transitioning = false;
        AnimatorClipInfo[] animation = m_Animator.GetCurrentAnimatorClipInfo(0);
        

            if (animation[0].clip.name == ("Door ClosedIdle"))
            {
                doorOpen = false;
            }
            else if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Door OpenIdle"))
            {

                doorOpen = true;
            }
            else
            {
                transitioning = true;
            }


        //Press the up arrow button to reset the trigger and set another one
        if (Input.GetKey(KeyCode.E)/*|| OVRInput.GetDown(OVRInput.Button.One)*/ && !transitioning)
        {
            if (doorOpen == false)
            {
                //Reset the "Jump" trigger
                m_Animator.ResetTrigger("Close");

                //Send the message to the Animator to activate the trigger parameter named "Crouch"
                m_Animator.SetTrigger("Open");
                doorOpen = true;
            }
            else if (doorOpen == true)
            {
                //Reset the "Crouch" trigger
                m_Animator.ResetTrigger("Open");

                //Send the message to the Animator to activate the trigger parameter named "Jump"
                m_Animator.SetTrigger("Close");
                doorOpen = false;
            }
        }
    }
}