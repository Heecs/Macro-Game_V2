using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public GameObject MenuCanvas;
    void Start()
    {
        MenuCanvas.SetActive(false);
    }


    public void ToggleMenu()
    {
        MenuCanvas.SetActive(!MenuCanvas.activeSelf);
    }


    public void FlipMenu()
    {
        MenuCanvas.SetActive(false);
        //Animation machen
        //Rückseite anzeigen
        Debug.Log("Flip Menu");
    }


}
