using UnityEngine;
using UnityEngine.UI;

public class BasicDoorRaycast : MonoBehaviour
{
    [Header("Raycast Parameters")]
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string exludeLayerName = null;

    private DoorTrigger raycasted_obj;

    [Header("Key Codes")]
    [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;

    [Header("UI Parameters")]
    
    private bool doOnce;

    private const string interactableTag = "InteractiveObject";

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int mask = 1 << LayerMask.NameToLayer(exludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
             if (hit.collider.CompareTag(interactableTag))
             {
                if (!doOnce)
                {
                    raycasted_obj = hit.collider.gameObject.GetComponent<DoorTrigger>();
                }
                doOnce = true;

                if (Input.GetKeyDown(openDoorKey))
                {
                   raycasted_obj.PlayerInteract();
                }
             }
        }
        else
        {
            raycasted_obj = null;
            doOnce = false;
        }
    }
}