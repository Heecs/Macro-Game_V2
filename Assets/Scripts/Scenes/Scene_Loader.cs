using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections.Generic; 

public class Scene_Loader : MonoBehaviour
{
    public Animator transitionAnimator;

    private InputAction _transitionInput;

    public List<string> sceneNames; // List of scene names to load

    public int sceneToLoad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _transitionInput = InputSystem.actions.FindAction("Interact");
    }

    void Update()
    {
        if (_transitionInput.WasPressedThisFrame())
        {
            OnInteract();
        }
    }

    public void OnInteract()
    {
        transitionAnimator.SetTrigger("Start_Transition");
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneNames[sceneToLoad]);
    }
}
