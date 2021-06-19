using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScene : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Change The scene when a player loose. 
        if (Rules.states == Rules.MyEnum.GAME_OVER)
        {
            TurnManager.GetInstance().EndTurn();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
            
            //Debug.Log(TurnManager.GetInstance().GetCurrentPlayer().ToString()+ "  Lost");
        }
    }
}
