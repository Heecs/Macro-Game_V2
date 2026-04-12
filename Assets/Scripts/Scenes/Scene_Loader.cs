using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Scene_Loader : MonoBehaviour
{
    public Animator transitionAnimator;

    private InputAction _transitionInput;

    public string sceneToLoad;
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
        SceneManager.LoadScene(sceneToLoad);
    }
}
