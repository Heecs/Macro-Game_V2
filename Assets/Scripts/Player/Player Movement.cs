using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]
    public GameObject playerCharacter;
    public float movementSpeed = 5f;
    private GameObject _player;

    private InputAction _movementInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _movementInput = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        Vector2 movementVector = _movementInput.ReadValue<Vector2>();
        if (movementVector != Vector2.zero)
        {
            Vector3 move = new Vector3(movementVector.x, 0, movementVector.y) * movementSpeed * Time.deltaTime;
            playerCharacter.transform.forward = move;
            _player.transform.Translate(move, Space.World);
        }
    }
}
