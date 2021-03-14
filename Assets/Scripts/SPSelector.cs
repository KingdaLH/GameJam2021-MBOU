using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SPSelector : MonoBehaviour
{
    public GameObject Menu;

    public GameObject spSelector;

    public void Selector()
    {
        Menu.SetActive(false);
        spSelector.SetActive(true);
    }

    public void Singleplayertouch()
    {
        SceneManager.LoadScene(4);
    }

    public void SingleplayerWASD()
    {
        SceneManager.LoadScene(3);
    }

    public void BackButtonSP()
    {
        if (spSelector == isActiveAndEnabled)
        {
            spSelector.SetActive(false);
            Menu.SetActive(true);
        }
        
        if (Menu == isActiveAndEnabled);
        {
            SceneManager.LoadScene(0);
        }
    }
}