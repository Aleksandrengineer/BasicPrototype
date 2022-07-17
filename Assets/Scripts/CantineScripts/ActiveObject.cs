using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ActiveObject : NetworkBehaviour
{
    public GameObject interactableText;
    public GameObject activeObjectWindow;

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player" && !isLocalPlayer)
            interactableText.SetActive(true);
            EnableActiveObjectWindow();
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player")
        interactableText.SetActive(false);
        activeObjectWindow.SetActive(false);
    }

    private void EnableActiveObjectWindow()
    {
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
}
