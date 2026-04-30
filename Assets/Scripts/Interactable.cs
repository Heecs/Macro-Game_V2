using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.EventSystems.EventTrigger;

public class Interactable : MonoBehaviour
{

    private InputAction _transitionInput;

    public Collider playerCO;

    public bool canInteract;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        _transitionInput = InputSystem.actions.FindAction("Interact");
        playerCO = GameObject.FindGameObjectWithTag("PlayerCharacter").GetComponent<Collider>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (_transitionInput.WasPressedThisFrame() && canInteract)
        {
            Interact();
        }
    }

    protected virtual void Interact()
    {
        Debug.Log("Interaction for this script not defined");
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other == playerCO)
        {
            canInteract = true;
        }
    }
    public virtual void OnTriggerExit(Collider other)
    {
        if (other == playerCO)
        {
            canInteract = false;
        }
    }
}
