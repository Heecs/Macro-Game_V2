using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public class Scene_Loader : MonoBehaviour
{

    public Animator transitionAnimator; // The Animator assigned to the scene transition animation



    public List<string> sceneNames; // List of Scenes the Scene Loader can access.


    public int sceneToLoad;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Update()
    {

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
