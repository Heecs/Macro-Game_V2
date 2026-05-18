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


}
