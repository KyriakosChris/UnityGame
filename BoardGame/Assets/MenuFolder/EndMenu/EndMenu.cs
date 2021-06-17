using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class EndMenu : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {
        if (TurnManager.GetInstance().GetCurrentPlayer().ToString().Equals("Player 1"))
        {
            GameObject.Find("Name").GetComponent<TextMeshProUGUI>().text = "Player 2";
        }
        else
        {
            TurnManager.GetInstance().EndTurn();
            GameObject.Find("Name").GetComponent<TextMeshProUGUI>().text = "Player 1";
        }
    }
    public void Restart()
    {
        Rules.states = Rules.MyEnum.INIT;
        CarManager.instance = null;
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
