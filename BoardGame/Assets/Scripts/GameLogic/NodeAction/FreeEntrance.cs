using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeEntrance : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Rules.states == Rules.MyEnum.FREE_ENTRANCE || Rules.states == Rules.MyEnum.ENTRANCE_POINT) {
            
            
            if(DropdownMenu.EntrancePosition == "")
            {
                return;
            }
            string[] splitArray = DropdownMenu.EntrancePosition.Split(char.Parse(","));
            DropdownMenu.EntrancePosition = "";
            int region = Buy.RegionNumber(splitArray[0]);
            int position = Buy.RegionNumber(splitArray[1])+1;
            Debug.Log("Reg " +region + " Posisiton "+ position);
            // Add +2 for entrance
            Rules.Owners[region, position] += 2;
            Transform childs = GameObject.Find("Regions").GetComponentInChildren<Transform>();
            childs.GetChild(region).Find("Entrance"+ (position).ToString()).gameObject.SetActive(true);
            if (Rules.PlayerEntrancePoint)
            {
                Rules.PlayerEntrancePoint = false;
                Rules.states = Rules.MyEnum.CHECK_NODE;
            }
            else
            {
                Rules.states = Rules.MyEnum.END_TURN;
            }
            
        }
    }
}
