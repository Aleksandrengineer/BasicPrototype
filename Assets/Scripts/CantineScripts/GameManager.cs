using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject profileGameObject;
    public GameObject userListGameObject;

    public GameObject activeObject;

    public GameObject iteraction_text;

    public void ExitButtonPressed()
    {
        Application.Quit();
    }

    public void ProfileButtonPressed()
    {
        if(profileGameObject.activeInHierarchy == true)
        {
            profileGameObject.SetActive(false);
        }
        else
        {
            profileGameObject.SetActive(true);
        }
    }

    public void UserListButtonPressed()
    {
        if(userListGameObject.activeInHierarchy == true)
        {
            userListGameObject.SetActive(false);
        }
        else
        {
            userListGameObject.SetActive(true);
        }        
    }
}
