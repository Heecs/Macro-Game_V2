using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using UnityEngine.ResourceManagement.AsyncOperations;

public class DialogueNPC : Interactable
{

    public string stringTableCollectionName = "TestTable";
    public List<String> dialogueKeys;
    private DialogueManager manager;


    private List<String> lines;
    private bool wasActive = false;
    private int currentLine = 0;


    protected override void Start()
    {
        base.Start();
        manager = GameObject.FindWithTag("DialogueManager").GetComponent<DialogueManager>();
    }

    protected override void Interact()
    {
        if (currentLine < lines.Count)
        {
            if (lines[currentLine] != null && !wasActive)
            {
                wasActive = true;
                manager.InitiateDialogue(lines[currentLine]);
                currentLine++;
            }
            else if (lines[currentLine] != null)
            {
                manager.changeText(lines[currentLine]);
                currentLine++;
            }
        }
        else
        {
            manager.endDialogue();
            wasActive = false;
            currentLine = 0;
        }
    }

    void OnEnable()
    {
        StartCoroutine(LoadStrings());
        LocalizationSettings.SelectedLocaleChanged += OnSelectedLocaleChanged;
    }

    void OnDisable()
    {
        LocalizationSettings.SelectedLocaleChanged -= OnSelectedLocaleChanged;
    }

    void OnSelectedLocaleChanged(Locale obj)
    {
        StartCoroutine(LoadStrings());
    }

    IEnumerator LoadStrings()
    {
        var loadingOperation = LocalizationSettings.StringDatabase.GetTableAsync(stringTableCollectionName);
        yield return loadingOperation;

        if (loadingOperation.Status == AsyncOperationStatus.Succeeded)
        {
            var stringTable = loadingOperation.Result;
            lines = new List<string>();
            foreach(string key in dialogueKeys)
            {
                lines.Add(GetLocalizedString(stringTable, key));
            }
        }
        else
        {
            Debug.LogError("Could not load String Table\n" + loadingOperation.OperationException.ToString());
        }
    }

    string GetLocalizedString(StringTable table, string entryName)
    {
        var entry = table.GetEntry(entryName);
        return entry.GetLocalizedString();
    }

    void OnGUI()
    {
        if (!LocalizationSettings.InitializationOperation.IsDone)
        {
            GUILayout.Label("Initializing Localization");
            return;
        }
    }
}
