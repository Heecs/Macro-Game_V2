using UnityEngine;
using System.Collections.Generic;

public class Card : MonoBehaviour
{
    //A List of all Card Levels for a better overview of the different levels and to make it easier to add new levels in the future.
    public List<string> cardLevels;

    //The current Level of the card. This is used to determine which rooms the player can access. The higher the level, the more rooms the player can access.
    public int currentLevelIndex;

    //Increases the Level of the cardand therefore the number of roomms the player can access.
    public void IncreaseLevel()
    {
        if (currentLevelIndex < cardLevels.Count)
        {
            currentLevelIndex += 1;
        }
    }
}
