using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class Elevator : MonoBehaviour
{

    private InputAction _transitionInput;

    public Collider playerCO;

    public GameObject aufzugUI;

    public bool canTry;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _transitionInput = InputSystem.actions.FindAction("Interact");
        playerCO = GameObject.FindGameObjectWithTag("PlayerCharacter").GetComponent<Collider>();
        aufzugUI = GameObject.FindWithTag("AufzugUI");
    }

    // Update is called once per frame
    void Update()
    {
        if (_transitionInput.WasPressedThisFrame() && canTry)
        {
            aufzugUI.SetActive(true);
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
