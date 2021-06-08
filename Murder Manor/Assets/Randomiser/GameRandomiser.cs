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
    public List<GameObject> Rooms;
    private BloodScript script;
    public Component component;


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
        Location weaponLocation = SelectRandomWeaponLocation(); //weaponlocation
        GameObject npc = SelectRandomNPC();
        GameObject location = SelectRandomLocation();

        Answer = new GameAnswer(murderWeapon, location, npc);

        GetChildComponentByName<Text>(AnswerObject, "Weapon").text = murderWeapon.name;
        GetChildComponentByName<Text>(AnswerObject, "Location").text = location.name;
        GetChildComponentByName<Text>(AnswerObject, "NPC").text = npc.name;

        //PlaceClue(Answer);
        PlaceBloodyWeapons(weaponLocation, murderWeapon);
        PlaceBlood(location);
        foreach (GameObject weapon in Weapons)
        {
            PlaceWeapon(SelectRandomWeaponLocation(), weapon);
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
        Debug.Log("Placed bloody weapon" + location.WeaponPosition);
    }

    private void PlaceWeapon(Location location, GameObject weapon)
    {
        Instantiate(weapon, location.WeaponPosition, Quaternion.identity);
    }

    private GameObject SelectRandomWeapon() {
        int value = Rng.Next(BloodyWeapons.Count);
        return BloodyWeapons[value];
    }

    private GameObject SelectRandomLocation()
    {
        int value = Rng.Next(Rooms.Count);
        return Rooms[value];
    }

    private Location SelectRandomWeaponLocation() {
        int value = Rng.Next(Locations.Count);
        Location currentLocation = Locations[value];
        Locations.RemoveAt(value);
        return currentLocation;
    }

    private GameObject SelectRandomNPC() {
        int value = Rng.Next(NPCs.Count);
        return NPCs[value];
    }

    public void PlaceBlood(GameObject room)
    {
        foreach (GameObject location in Rooms)
        {
            if (location.name == room.name)
            {
                Debug.Log(location.name);
                component = FindComponentInChildWithTag<Component>(location, "BloodTrigger");
                Debug.Log("yes");
                component.gameObject.SetActive(true);
                script.ActivateBlood();

                GameObject test = GameObject.Find(location.name);

                //blood = test.FindComp
                //blood.enable(true);

            }
        }
    }

    public static T FindComponentInChildWithTag<T>(GameObject parent, string tag) where T : Component
    {
        Component component = parent.GetComponent<Component>();
        if (component.tag == tag)
        {
            return component.GetComponent<T>();
        }
        return null;
    }
}
