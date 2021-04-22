using System.Collections.Generic;
using UnityEngine;

public class GameRandomiser : MonoBehaviour {
    private readonly List<Location> Locations = new List<Location>() {
        new Location("Entrance Hallway", new Vector3(58.0f, 0.0f, -3.0f), new Vector3(58.0f, 0.0f, -3.0f)),
        new Location("Garage", new Vector3(58.0f, 0.0f, -3.0f), new Vector3(58.0f, 0.0f, -3.0f)),
        new Location("Garage Closet", new Vector3(58.0f, 0.0f, -3.0f), new Vector3(58.0f, 0.0f, -3.0f)),
        new Location("Living Room", new Vector3(58.0f, 0.0f, -3.0f), new Vector3(58.0f, 0.0f, -3.0f)),
        new Location("Dinner Room", new Vector3(58.0f, 0.0f, -3.0f), new Vector3(58.0f, 0.0f, -3.0f)),
        new Location("Kitchen", new Vector3(58.0f, 0.0f, -3.0f), new Vector3(58.0f, 0.0f, -3.0f)),
        new Location("Upper Hallway", new Vector3(58.0f, 0.0f, -3.0f), new Vector3(58.0f, 0.0f, -3.0f)),
        new Location("Bedroom", new Vector3(58.0f, 0.0f, -3.0f), new Vector3(58.0f, 0.0f, -3.0f)),
        new Location("Walk-in Closet", new Vector3(58.0f, 0.0f, -3.0f), new Vector3(58.0f, 0.0f, -3.0f)),
        new Location("Office Room", new Vector3(58.0f, 0.0f, -3.0f), new Vector3(58.0f, 0.0f, -3.0f)),
        new Location("Balcony", new Vector3(58.0f, 0.0f, -3.0f), new Vector3(58.0f, 0.0f, -3.0f)),
        new Location("Attic Stairs", new Vector3(58.0f, 0.0f, -3.0f), new Vector3(58.0f, 0.0f, -3.0f)),
        new Location("Attic", new Vector3(58.0f, 0.0f, -3.0f), new Vector3(58.0f, 0.0f, -3.0f))
    };

    public List<GameObject> WeaponLocations;

    public List<GameObject> Weapons;
    public List<GameObject> NPCs;

    private readonly System.Random Rng = new System.Random();
    private GameAnswer Answer;

    void Start() {
        GenerateAnswer();
        PlaceObjects();
    }

    void Update() {}

    private void GenerateAnswer() {
        GameObject weapon = SelectRandomWeapon();
        Vector3 location = SelectRandomLocation();
        GameObject npc = SelectRandomNPC();

        Answer = new GameAnswer(weapon, location, npc);
        PlaceClue(Answer);
    }

    private void PlaceClue(GameAnswer answer) {
        int value = Rng.Next(3);
        switch (value) {
            case 0:
                // Blood
                break;
            case 1:
                // Fingerprint
                break;
            default:
                // NPC Object
                break;
        }
    }

    private void PlaceObjects() {
        PlaceWeapons();
        PlaceNPCs();
    }

    private void PlaceWeapons() {
        Vector3 location;
        List<Vector3> selectedLocations = new List<Vector3>();
        for (int i = 0; i < Weapons.Count; i++) {
            while (true) {
                location = SelectRandomLocation();
                if (!selectedLocations.Contains(location)) {
                    selectedLocations.Add(location);
                    Instantiate(Weapons[i], location, Quaternion.identity);
                    break;
                }
            }
        }
    }

    private void PlaceNPCs() {
        Vector3 location;
        List<Vector3> selectedLocations = new List<Vector3>();
        for (int i = 0; i < NPCs.Count; i++) {
            while (true) {
                location = SelectRandomLocation();
                if (!selectedLocations.Contains(location)) {
                    selectedLocations.Add(location);
                    Instantiate(NPCs[i], location.normalized, Quaternion.identity);
                    break;
                }
            }
        }
    }

    private GameObject SelectRandomWeapon() {
        int value = Rng.Next(Weapons.Count);
        return Weapons[value];
    }

    private Vector3 SelectRandomLocation() {
        int value = Rng.Next(WeaponLocations.Count);
        return WeaponLocations[value].transform.position;
    }

    private GameObject SelectRandomNPC() {
        int value = Rng.Next(NPCs.Count);
        return NPCs[value];
    }
}
