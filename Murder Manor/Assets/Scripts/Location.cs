using UnityEngine;

public class Location {
    public string Name { get; }
    public Vector3 WeaponPosition { get; }
    public Vector3 NPCPosition { get; }

    public Location(string name, Vector3 weaponPosition, Vector3 npcPosition) {
        Name = name;
        WeaponPosition = weaponPosition;
        NPCPosition = npcPosition;
    }
}
