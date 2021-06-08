using System;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class GameRandomiser : MonoBehaviour {

    public List<Location> Locations;
    public List<GameObject> LocationObjects;
    public List<GameObject> BloodyWeapons;
    public List<GameObject> Weapons;
    public List<GameObject> NPCs;
    public Transform prefabToPlace;


    private readonly System.Random Rng = new System.Random();
    public GameObject AnswerObject;
    private GameAnswer Answer;

    void Start() {
        Locations = FillObjects();
        GenerateAnswer();
    }

    void Update() {}

    private List<Location> FillObjects()
    {
        List<Location> locations = new List<Location>();
        foreach (GameObject location in LocationObjects)
        {
            locations.Add(new Location(location.name, location.transform.position));
        }
        return locations;
    }

    private void GenerateAnswer() {
        GameObject murderWeapon = SelectRandomWeapon();
        Location location = SelectRandomLocation();
        GameObject npc = SelectRandomNPC();

        Answer = new GameAnswer(murderWeapon, location, npc);

        GetChildComponentByName<Text>(AnswerObject, "Weapon").text = murderWeapon.name;
        GetChildComponentByName<Text>(AnswerObject, "Location").text = location.Name;
        GetChildComponentByName<Text>(AnswerObject, "NPC").text = npc.name;

        //PlaceClue(Answer);
        PlaceBloodyWeapons(location, murderWeapon);
        foreach (GameObject weapon in Weapons)
        {
            PlaceWeapon(SelectRandomLocation(), weapon);
        }
    }

    private T GetChildComponentByName<T>(GameObject obj, string name) where T : Component {
        foreach (T component in obj.GetComponentsInChildren<T>(true)) {
            if (component.gameObject.name == name) {
                return component;
            }
        }
        return null;
    }

    private void PlaceClue(GameAnswer answer)
    {
        int value = 0;
        switch (value)
        {
            case 0:
                PlaceBlood(answer);
                break;
            case 1:
                // Fingerprint
                break;
            default:
                // NPC Object
                break;
        }
    }

    private void PlaceBloodyWeapons(Location location, GameObject bloodyWeapon) 
    {
        Instantiate(bloodyWeapon, location.WeaponPosition, Quaternion.identity);
        Debug.Log("Placed bloody weapon");
    }

    private void PlaceWeapon(Location location, GameObject weapon)
    {
        Instantiate(weapon, location.WeaponPosition, Quaternion.identity);
    }

    private GameObject SelectRandomWeapon() {
        int value = Rng.Next(BloodyWeapons.Count);
        return BloodyWeapons[value];
    }

    private Location SelectRandomLocation() {
        int value = Rng.Next(Locations.Count);
        Location currentLocation = Locations[value];
        Locations.RemoveAt(value);
        return currentLocation;
    }

    private GameObject SelectRandomNPC() {
        int value = Rng.Next(NPCs.Count);
        return NPCs[value];
    }

    public void PlaceBlood(GameAnswer Answer)
    {
        foreach (var location in LocationObjects)
        {

            Debug.Log(location.name);
            if (location.name == Answer.Location.Name)
            {
                Vector3 spawnPoint = location.transform.position;
                Instantiate(prefabToPlace, spawnPoint, prefabToPlace.rotation);
                Debug.Log("Succes");
            }
        }
    }
}
