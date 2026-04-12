using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    private Scene_Loader _sceneLoader;

    private void Start()
    {
        _sceneLoader = GetComponentInParent<Scene_Loader>();
    }

    public void TransitionStartFinished()
    {
        _sceneLoader.LoadNextScene();
    }
}
