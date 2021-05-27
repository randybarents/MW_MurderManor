using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    Animator m_Animator;
    bool doorOpen = false;
    bool RaycastActive = false;
    [SerializeField] private bool pauseInteraction = false;
    [SerializeField] private int waitTimer = 1;
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    public void PlayerInteract()
    {
        if (!pauseInteraction)
        {
            RaycastActive = true;
            Update();
            StartCoroutine(PauseDoorInteraction());
        }
    }

    void Update()
    {
        bool transitioning = false;
        transitioning = GetDoorState();
        if (!transitioning)
        {
            if (Input.GetKey(KeyCode.E)/*|| OVRInput.GetDown(OVRInput.Button.One)*/ || RaycastActive)
            {
                if (doorOpen == false)
                {
                    m_Animator.ResetTrigger("Close");
                    m_Animator.SetTrigger("Open");
                    doorOpen = true;
                }
                else if (doorOpen == true)
                {
                    m_Animator.ResetTrigger("Open");
                    m_Animator.SetTrigger("Close");
                    doorOpen = false;
                }
                RaycastActive = false;
            }
        }
    }

    public bool GetDoorState()
    {
        AnimatorClipInfo[] animation = m_Animator.GetCurrentAnimatorClipInfo(0);

        if (animation[0].clip.name == ("Door ClosedIdle"))
        {
            doorOpen = false;
            return false;
        }
        else if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Door OpenIdle"))
        {
            doorOpen = true;
            return false;
        }
        else
        {
            return true;
        }
    }
    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;

    }

}