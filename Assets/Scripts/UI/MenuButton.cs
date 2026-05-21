using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public GameObject MenuCanvas;
    public Animator CardAnim;
    public GameObject MedallienGroup;
    public GameObject QuestText;
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
        
        CardAnim.SetTrigger("Flip");
        MedallienGroup.SetActive(!MedallienGroup.activeSelf);
        QuestText.SetActive(!QuestText.activeSelf);
        //Rückseite anzeigen
        Debug.Log("Flip Menu");
    }


}
