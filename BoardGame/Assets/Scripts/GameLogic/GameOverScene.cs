using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScene : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Rules.states == Rules.MyEnum.GAME_OVER)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
            
            Debug.Log(TurnManager.GetInstance().GetCurrentPlayer().ToString()+ "  Lost");
        }
    }
}
