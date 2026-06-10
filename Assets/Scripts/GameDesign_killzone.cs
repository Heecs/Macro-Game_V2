using UnityEngine;

public class GameDesign_killzone : MonoBehaviour
{
    public GameDesign_Manager manager;

    private void OnTriggerEnter(Collider other)
    {
        manager.GameOver();
    }
}
