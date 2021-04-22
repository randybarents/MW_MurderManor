using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.Windows.Speech;
using System;
using System.Linq;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{

    private string chefFile = @"Assets/Resources/ChefScenario1.txt";
    private string chefFile2 = @"Assets/Resources/ChefScenario2.txt";
    private string gardenerFile = @"Assets/Resources/GardenerScenario1.txt";
    private string gardenerFile2 = @"Assets/Resources/GardenerScenario2.txt";
    private string mechanicFile = @"Assets/Resources/MechanicScenario1.txt";
    private string mechanicFile2 = @"Assets/Resources/MechanicScenario2.txt";

    private int scenarioNumber = 1;


    public Text screenText;

    private string npcType;

    private float textDuration = 6f;

    private KeywordRecognizer keywordRecognizer;

    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    // Start is called before the first frame update
    void Start()
    {
        actions.Add("Murder info", Help);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Chef")
        {
            npcType = "Chef";
        }
        else if (other.tag == "Gardener")
        {
            npcType = "Gardener";
        }
        else if (other.tag == "Mechanic")
        {
            npcType = "Mechanic";
        }
    }

    private void Help()
    {
        if (npcType == "Chef" && scenarioNumber == 1)
        {
            StartCoroutine("ReadChef");
        }
        else if (npcType == "Chef" && scenarioNumber == 2)
        {
            StartCoroutine("ReadChef2");
        }
        else if (npcType == "Gardener" && scenarioNumber == 1)
        {
            StartCoroutine("ReadGardener");
        }
        else if (npcType == "Gardener" && scenarioNumber == 2)
        {
            StartCoroutine("ReadGardener2");
        }
        else if (npcType == "Mechanic" && scenarioNumber == 1)
        {
            StartCoroutine("ReadMechanic");
        }
        else if (npcType == "Mechanic" && scenarioNumber == 2)
        {
            StartCoroutine("ReadMechanic2");
        }
    }

    private IEnumerator ReadChef()
    {
        using (StreamReader sr = new StreamReader(chefFile))
        {
            screenText.text = sr.ReadToEnd();
        }
        yield return new WaitForSeconds(textDuration);

        screenText.text = "";
    }

    private IEnumerator ReadChef2()
    {
        using (StreamReader sr = new StreamReader(chefFile2))
        {
            screenText.text = sr.ReadToEnd();
        }
        yield return new WaitForSeconds(textDuration);

        screenText.text = "";
    }

    private IEnumerator ReadGardener()
    {
        using (StreamReader sr = new StreamReader(gardenerFile))
        {
            screenText.color = Color.green;
            screenText.text = sr.ReadToEnd();
        }
        yield return new WaitForSeconds(textDuration);

        screenText.text = "";
        screenText.color = Color.black;
    }

    private IEnumerator ReadGardener2()
    {
        using (StreamReader sr = new StreamReader(gardenerFile2))
        {
            screenText.color = Color.green;
            screenText.text = sr.ReadToEnd();
        }
        yield return new WaitForSeconds(textDuration);

        screenText.text = "";
        screenText.color = Color.black;
    }

    private IEnumerator ReadMechanic()
    {
        using (StreamReader sr = new StreamReader(mechanicFile))
        {
            screenText.color = Color.red;
            screenText.text = sr.ReadToEnd();
        }
        yield return new WaitForSeconds(textDuration);

        screenText.text = "";
        screenText.color = Color.black;
    }

    private IEnumerator ReadMechanic2()
    {
        using (StreamReader sr = new StreamReader(mechanicFile2))
        {
            screenText.color = Color.red;
            screenText.text = sr.ReadToEnd();
        }
        yield return new WaitForSeconds(textDuration);

        screenText.text = "";
        screenText.color = Color.black;
    }
}
