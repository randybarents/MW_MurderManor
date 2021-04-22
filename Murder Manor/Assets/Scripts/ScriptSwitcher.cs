using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ScriptSwitcher : MonoBehaviour
{

    private NavMeshAgent npcAgent;
    private Rigidbody npcBody;
    public GameObject PlayerInteractor;


    void OnEnable()
    {
        npcAgent = GetComponent<NavMeshAgent>();
        npcBody = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<NPCMovement>().enabled = false;
            npcAgent.isStopped = true;
            npcBody.constraints = RigidbodyConstraints.FreezePosition;
            PlayerInteractor.GetComponent<NPCInteraction>().enabled = true;
            transform.LookAt(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            npcBody.constraints = RigidbodyConstraints.None;
            npcAgent.isStopped = false;
            PlayerInteractor.GetComponent<NPCInteraction>().enabled = false;
            GetComponent<NPCMovement>().enabled = true;
        }
    }
}
