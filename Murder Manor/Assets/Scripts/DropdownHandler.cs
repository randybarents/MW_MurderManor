using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{
    public bool isVisible = false;
    public List<Dropdown> DropDownMenu;
    public List<GameObject> Locations = new List<GameObject>();
    //private List<string> Locations = new List<string>{"Kitchen", "Garage", "Dinner Room", "Living Room", "Main Bedroom", "Child Bedroom", "Closet", "Mainhall", "Upper Hallway", "Toilet", "Attic", "Bathroom", "Balcony"};
    public List<GameObject> Weapons = new List<GameObject>();
    public List<GameObject> NPCs = new List<GameObject>();
    void Start()
    {
      var dropDown = DropDownMenu;
      var Items = new List<GameObject>();

      foreach(var menu in dropDown)
      {
        menu.options.Clear();

        switch(menu.name)
        {
          case "DropdownLocations" :
            Items = Locations;
            foreach(var item in Items)
            {
                menu.options.Add(new Dropdown.OptionData() { text = item.name});
            }
              menu.captionText.text = Items[0].name;
              DropdownItemSelected(menu);
              menu.onValueChanged.AddListener(delegate { DropdownItemSelected(menu); });
            break;

          case "DropdownWeapons" :
            Items = Weapons;
            foreach(var item in Weapons)
            {
                menu.options.Add(new Dropdown.OptionData() { text = item.name});
            }
              menu.captionText.text = Items[0].name;
              DropdownItemSelected(menu);
              menu.onValueChanged.AddListener(delegate { DropdownItemSelected(menu); });
            break;

          case "DropdownNPCs" :
          Items = NPCs;
            foreach(var item in NPCs)
            {
                menu.options.Add(new Dropdown.OptionData() { text = item.name});
            }
              menu.captionText.text = Items[0].name;
              DropdownItemSelected(menu);
              menu.onValueChanged.AddListener(delegate { DropdownItemSelected(menu); });
                break;
            }
        }   
    }

    void DropdownItemSelected(Dropdown dropDown)
    {
        int index = dropDown.value;
    }
}
