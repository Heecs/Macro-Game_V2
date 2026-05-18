using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]
    public GameObject playerCharacter;
    public Rigidbody playerRB;
    public float movementSpeed = 5f;
    public Vector3 offset;

    private GameObject _playerCamera;

    private InputAction _movementInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCharacter = GameObject.FindWithTag("PlayerCharacter");
        playerRB = playerCharacter.GetComponent<Rigidbody>();
        _movementInput = InputSystem.actions.FindAction("Move");
        _playerCamera = GameObject.FindWithTag("MainCamera");

        _playerCamera.transform.position = playerCharacter.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        Vector2 inputVector = _movementInput.ReadValue<Vector2>();
        Vector3 flatforward = new Vector3(_playerCamera.transform.forward.x, 0, _playerCamera.transform.forward.z).normalized;
        Vector3 flatRight = new Vector3(_playerCamera.transform.right.x, 0, _playerCamera.transform.right.z).normalized;
        Vector3 movementVector = new Vector3(inputVector.x, 0, inputVector.y).normalized;
        Vector3 localMovement = flatforward * movementVector.z + flatRight * movementVector.x;
        playerRB.linearVelocity = localMovement * movementSpeed;
            _playerCamera.transform.position = playerCharacter.transform.position + offset;   
    }
}
