using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class Elevator_UI_Handler : MonoBehaviour
{

    private InputAction _transitionInput;


    public GameObject aufzugUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aufzugUI = GameObject.FindWithTag("AufzugUI");
        aufzugUI.SetActive(false);
    }

    public void CloseAufzugUI()
    {
        aufzugUI.SetActive(false);
    }

    // Update is called once per frame

}
