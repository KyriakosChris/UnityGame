using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeEntrance : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        /* 
         * If a Player is in Free entrance Node and has a region with at least one house, he can build an entrance where he wants to build it. Otherwhise, if
         * he pass by an entry pass through, he can buy an entrance when the same conditions are met.
         * */
        if (Rules.states == Rules.MyEnum.FREE_ENTRANCE || Rules.states == Rules.MyEnum.ENTRANCE_POINT) {
            
            
            if(DropdownMenu.EntrancePosition == null)
            {
                return;
            }
            string[] splitArray = DropdownMenu.EntrancePosition.Split(char.Parse(","));
            DropdownMenu.EntrancePosition = null;
            int region =  Rules.RegionNumber(splitArray[0]);
            int position = Rules.RegionNumber(splitArray[1])+1;

            //Debug.Log("Reg " +region + " Posisiton "+ position);

            // Add +2 for entrance
            Rules.Owners[region, position] += 2;
            Transform childs = GameObject.Find("Regions").GetComponentInChildren<Transform>();
            childs.GetChild(region).Find("Entrance"+ (position).ToString()).gameObject.SetActive(true);
            FindObjectOfType<AudioManager>().Play("BuildSound");
            if (Rules.PlayerEntrancePoint)
            {
                Rules.PlayerEntrancePoint = false;
                Rules.Checkmoney();
                Rules.states = Rules.MyEnum.CHECK_NODE;
            }
            else
            {
                Rules.states = Rules.MyEnum.END_TURN;
            }
            

        }
    }
}
