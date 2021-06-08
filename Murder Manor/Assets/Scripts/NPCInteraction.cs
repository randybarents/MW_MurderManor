﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.Windows.Speech;
using System;
using System.Linq;
using UnityEngine.UI;
using System.Globalization;
using Newtonsoft.Json;

public class NPCInteraction : MonoBehaviour {
    private const float TextDuration = 6.0f;

    public GameObject Answer;
    private GameObject weaponChild;
    private GameObject npcChild;
    private GameObject locationChild;
    public Text ScreenText;
    private Dictionary<string, string> Scenarios;
    private readonly int ScenarioNumber = 1;
    private string NPCType;

    private KeywordRecognizer keywordRecognizer;
    private readonly Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start() {
        weaponChild = Answer.transform.Find("Weapon").gameObject;
        npcChild = Answer.transform.Find("NPC").gameObject;
        locationChild = Answer.transform.Find("Location").gameObject;
        string scenarioJson = File.ReadAllText("Assets/Resources/Scenarios.json");
        Scenarios = JsonConvert.DeserializeObject<Dictionary<string, string>>(scenarioJson);
        actions.Add("help", Help);
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech) {
        actions[speech.text].Invoke();
    }

    private void OnTriggerStay(Collider other) {
        NPCType = other.tag;
    }

    private void Help() {
        Debug.Log("Heard");
        string key = $"scenario.{NPCType}.{ScenarioNumber.ToString(CultureInfo.InvariantCulture)}";
        StartCoroutine(Place(key, new string[] { weaponChild.GetComponent<Text>().ToString(), npcChild.GetComponent<Text>().ToString(), locationChild.GetComponent<Text>().ToString() }));
    }

    private IEnumerator Place(string key, params string[] args) {
        ScreenText.color = Color.yellow;
        if (Scenarios.TryGetValue(key, out string text)) {
            ScreenText.text = string.Format(text, args);
            yield return new WaitForSeconds(TextDuration);
        }
        ScreenText.text = "";
    }
}
