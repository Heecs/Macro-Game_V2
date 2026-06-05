using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public class Scene_Loader : MonoBehaviour
{

    public Animator transitionAnimator; // The Animator assigned to the scene transition animation

    public Rigidbody player;

    public List<string> sceneNames; // List of Scenes the Scene Loader can access.


    public int sceneToLoad;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Player is Placed at the door from where he enters the room
        player = GameObject.FindWithTag("PlayerCharacter").GetComponent<Rigidbody>();
        if(PlayerPrefs.GetString("DoorName") != null)
        {
            player.transform.position = new Vector3(GameObject.Find(PlayerPrefs.GetString("DoorName")).transform.position.x, player.transform.position.y, GameObject.Find(PlayerPrefs.GetString("DoorName")).transform.position.z) + GameObject.Find(PlayerPrefs.GetString("DoorName")).transform.forward * 2;
        }
    }
    public void StartTransition()
    {
            transitionAnimator.SetTrigger("Start_Transition");
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneNames[sceneToLoad]);
    }
}
