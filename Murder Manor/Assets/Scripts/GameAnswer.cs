using UnityEngine;

public class GameAnswer {
    public GameObject Weapon { get; }
    public GameObject Location { get; }
    public GameObject NPC { get; }

    public GameAnswer(GameObject weapon, GameObject location, GameObject npc) {
        Weapon = weapon;
        Location = location;
        NPC = npc;
    }
}
