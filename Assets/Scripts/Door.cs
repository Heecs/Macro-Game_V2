using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{

    private InputAction _transitionInput;

    public Card playerCard;

    public Collider playerCO;

    public int requiredPlayerCardIndex;
    public int sceneToLoadIndex;

    public Scene_Loader sceneLoader;

    public bool canTry;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _transitionInput = InputSystem.actions.FindAction("Interact");
        playerCard = GameObject.FindWithTag("Player").GetComponent<Card>();
        sceneLoader = GameObject.FindWithTag("SceneLoader").GetComponent<Scene_Loader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_transitionInput.WasPressedThisFrame() && canTry)
        {
            InitiateTransition();
        }
    }

    public void InitiateTransition()
    {
        if(playerCard.currentLevelIndex >= requiredPlayerCardIndex)
        {
            sceneLoader.sceneToLoad = sceneToLoadIndex;
            sceneLoader.StartTransition();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == GameObject.FindGameObjectWithTag("PlayerCharacter").GetComponent<Collider>())
        {
            canTry = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other == GameObject.FindGameObjectWithTag("PlayerCharacter").GetComponent<Collider>())
        {
            canTry = false;
        }
    }
}
