using UnityEngine;
using UnityEngine.Localization.Tables;

public class DialogueNPC : Interactable
{
    public LocalizationTable targetTable;
    protected override void Interact()
    {
        print("test");
    }
}
