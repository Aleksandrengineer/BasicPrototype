using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject entryScreen;
    public GameObject registrationScreen;

    public void LoadScene(string sceneName)

    {
        SceneManager.LoadScene(sceneName);
    }

    public void RegistrationScreen()
    {
        entryScreen.SetActive(false);
        registrationScreen.SetActive(true);
    }

    public void EntryScreen()
    {
        registrationScreen.SetActive(false);
        entryScreen.SetActive(true);
;    }
}
