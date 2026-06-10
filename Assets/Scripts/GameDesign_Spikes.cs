using UnityEngine;

public class GameDesign_Spikes : MonoBehaviour
{
    public GameDesign_Manager manager;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameDesign_Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            print("Player hit spikes");
            manager.GameOver();
        }
    }
}
