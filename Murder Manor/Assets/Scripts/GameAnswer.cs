using UnityEngine;

public class GameAnswer {
    private readonly GameObject Weapon;
    private readonly Vector3 Location;
    private readonly GameObject NPC;

    public GameAnswer(GameObject weapon, Vector3 location, GameObject npc) {
        Weapon = weapon;
        Location = location;
        NPC = npc;
    }
}
