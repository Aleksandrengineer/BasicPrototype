using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ActiveObject : NetworkBehaviour
{
    public GameObject activeObjectWindow;

    /*private void OnTriggerStay(Collider other) 
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && activeObjectWindow.activeInHierarchy == false)
        {    
            activeObjectWindow.SetActive(true);
            interactableText.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.E) && activeObjectWindow.activeInHierarchy == true)
        {
            activeObjectWindow.SetActive(false);
            interactableText.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (other.tag == "Player" && !isLocalPlayer)
        interactableText.SetActive(false);
        activeObjectWindow.SetActive(false);
    }*/

    public void EnableActiveObjectWindow()
    {
        if (Input.GetKeyDown(KeyCode.E) && activeObjectWindow.activeInHierarchy == false)
        {    
            activeObjectWindow.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && activeObjectWindow.activeInHierarchy == true)
        {
            activeObjectWindow.SetActive(false);
        }
    }


}
