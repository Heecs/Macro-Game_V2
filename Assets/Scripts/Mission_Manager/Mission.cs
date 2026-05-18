using UnityEngine;

[CreateAssetMenu(menuName = "Game/Mission")]
public class Mission : ScriptableObject
{
    public string missionName;
    public string missionDescription;

    public int requiredCardLevel;
    public int cardLevelAfterCompletion;

    public bool visible;
    public bool completed;
}
