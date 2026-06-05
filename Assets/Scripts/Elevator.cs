using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class Elevator : MonoBehaviour
{

    private InputAction _transitionInput;

    public Collider playerCO;

    public Elevator_UI_Handler aufzugUIHandler;

    public bool canTry;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _transitionInput = InputSystem.actions.FindAction("Interact");
        playerCO = GameObject.FindGameObjectWithTag("PlayerCharacter").GetComponent<Collider>();
        aufzugUIHandler = GameObject.FindWithTag("AufzugUIHandler").GetComponent<Elevator_UI_Handler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_transitionInput.WasPressedThisFrame() && canTry)
        {
            aufzugUIHandler.OpenAufzugUI();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == playerCO)
        {
            canTry = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other == playerCO)
        {
            canTry = false;
        }
    }
}
