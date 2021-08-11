using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuScenesScript : MonoBehaviour
{
    public GameObject UIPanel, helppanel, optionspanel;

    public void back()
    {
        UIPanel.SetActive(true);
        helppanel.SetActive(false);
        optionspanel.SetActive(false);

    }
    public void Help()
    {
        helppanel.SetActive(true);
        UIPanel.SetActive(false);
        optionspanel.SetActive(false);

    }
    public void options()
    {
        optionspanel.SetActive(true);
        UIPanel.SetActive(false);
        helppanel.SetActive(false);

    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
