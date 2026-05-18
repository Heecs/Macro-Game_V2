using System;
using UnityEngine;

public class Mission_Manager : MonoBehaviour
{
    public Mission_List missionList;

    public Card playerCard;

    private void Start()
    {
        playerCard = GameObject.FindWithTag("Player").GetComponent<Card>();
        missionList.player = GameObject.FindWithTag("Player");
    }

    public Boolean CheckIfMissionAvailable(Mission mission)
    {
        if(mission.requiredCardLevel <= playerCard.currentLevelIndex && mission.visible)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void TaskFinished()
    {
        missionList.Refresh();
    }
}
