using UnityEngine;

public class GameAnswer {
    public GameObject Weapon { get; }
    public Location Location { get; }
    public GameObject NPC { get; }

    public GameAnswer(GameObject weapon, Location location, GameObject npc) {
        Weapon = weapon;
        Location = location;
        NPC = npc;
    }
}
