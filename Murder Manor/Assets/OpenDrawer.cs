using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawer : MonoBehaviour
{
    private bool boxOpened;
    private bool coroutineAllowed;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        boxOpened = false;
        coroutineAllowed = true;
        initialPosition = transform.position;
    }

    private void OnMouseDown()
    {
        Invoke("RunCoroutine", 0f);
    }

    private void RunCoroutine()
    {
        StartCoroutine("OpenThatDrawer");
    }

    private IEnumerator OpenThatDrawer()
    {
        coroutineAllowed = false;
        if (!boxOpened)
        {
            for (float i = 0f; i <= 1f; i += 0.1f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x,
                    transform.localPosition.y,
                    transform.localPosition.z - 0.1f);
                yield return new WaitForSeconds(0f);
            }
            boxOpened = true;
        }
        else
        {
            for (float i = 1f; i >= 0f; i -= 0.1f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x,
                    transform.localPosition.y,
                    transform.localPosition.z + 0.1f);
                yield return new WaitForSeconds(0f);
            }
            transform.position = initialPosition;
            boxOpened = false;
        }
        coroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}