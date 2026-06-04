using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class Elevator_Button : MonoBehaviour
{

    public Card playerCard;

    public Collider playerCO;

    public int requiredPlayerCardIndex;
    public int sceneToLoadIndex;

    public Scene_Loader sceneLoader;

    public Elevator_UI_Handler elevatorUIHandler;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCard = GameObject.FindWithTag("Player").GetComponent<Card>();
        sceneLoader = GameObject.FindWithTag("SceneLoader").GetComponent<Scene_Loader>();
        playerCO = GameObject.FindGameObjectWithTag("PlayerCharacter").GetComponent<Collider>();
        elevatorUIHandler = GameObject.FindWithTag("AufzugUIHandler").GetComponent<Elevator_UI_Handler>();
    }

    // Update is called once per frame

    public void InitiateTransition()
    {
        if(playerCard.currentLevelIndex >= requiredPlayerCardIndex)
        {
            PlayerPrefs.SetString("DoorName", "Aufzug");
            sceneLoader.sceneToLoad = sceneToLoadIndex;
            sceneLoader.StartTransition();
        }
    }

}
