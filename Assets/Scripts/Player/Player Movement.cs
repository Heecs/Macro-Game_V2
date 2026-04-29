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

        Vector3 movementVector = new Vector3(inputVector.x, 0, inputVector.y).normalized;

            Vector3 move = new Vector3(movementVector.x, 0, movementVector.y) * movementSpeed * Time.deltaTime;
            playerRB.linearVelocity = movementVector * movementSpeed;
            _playerCamera.transform.position = playerCharacter.transform.position + offset;   
    }
}
