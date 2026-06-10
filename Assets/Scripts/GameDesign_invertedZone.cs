using UnityEngine;

public class GameDesign_invertedZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GameDesign_characterController>() != null)
        {
            GameDesign_characterController player = other.GetComponent<GameDesign_characterController>();
            player.invertGravity();
            player.hasDoubleJump = true;
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<GameDesign_characterController>() != null)
        {
            other.GetComponent<GameDesign_characterController>().invertGravity();
        }
    }*/
}
