using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class Elevator : MonoBehaviour
{

    private InputAction _transitionInput;

    public Card playerCard;

    public Collider playerCO;

    public int requiredPlayerCardIndex;
    public int sceneToLoadIndex;

    public Scene_Loader sceneLoader;

    public GameObject aufzugUI;

    public bool canTry;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _transitionInput = InputSystem.actions.FindAction("Interact");
        playerCard = GameObject.FindWithTag("Player").GetComponent<Card>();
        sceneLoader = GameObject.FindWithTag("SceneLoader").GetComponent<Scene_Loader>();
        playerCO = GameObject.FindGameObjectWithTag("PlayerCharacter").GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_transitionInput.WasPressedThisFrame() && canTry)
        {
            aufzugUI.SetActive(true);
        }
    }

    public void InitiateTransition()
    {
        if(playerCard.currentLevelIndex >= requiredPlayerCardIndex)
        {
            PlayerPrefs.SetString("DoorName", transform.root.name);
            sceneLoader.sceneToLoad = sceneToLoadIndex;
            sceneLoader.StartTransition();
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
