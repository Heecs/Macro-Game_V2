using TMPro;
using UnityEditor.Localization;
using UnityEngine;
using UnityEngine.Localization;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textOutput;
    public GameObject dialogueUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deactivateTextField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void activateTextField()
    {
        dialogueUI.SetActive(true);
    }
    private void deactivateTextField()
    {
        dialogueUI.SetActive(false);
    }

    public void InitiateDialogue(string firstLine)
    {
        activateTextField();
        textOutput.text = firstLine;
    }

    public void changeText(string line)
    {
        textOutput.text = line;
    }

    public void endDialogue()
    {
        textOutput.text = "";
        deactivateTextField();
    }
}
