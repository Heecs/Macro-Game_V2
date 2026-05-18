using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

[CreateAssetMenu(menuName = "Game/MissionList")]
public class Mission_List : ScriptableObject
{
    public List<Mission> missions;

    public GameObject player;

    public void Refresh()
    {
        foreach (Mission mission  in missions)
        {
            if(player.GetComponent<Card>() != null && player.GetComponent<Card>().currentLevelIndex <= mission.requiredCardLevel)
            {
                if (mission.completed)
                {
                    mission.visible = false;
                }
                else
                {
                    mission.visible = true;
                }
            }
            else
            {
                mission.visible = false;
            }
        }
    }
}
