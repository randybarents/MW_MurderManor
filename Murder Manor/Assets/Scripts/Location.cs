using UnityEngine;

public class Location {
    public string Name { get; }
    public Vector3 WeaponPosition { get; }

    public Location(string name, Vector3 weaponPosition) {
        Name = name;
        WeaponPosition = weaponPosition;
    }
}
