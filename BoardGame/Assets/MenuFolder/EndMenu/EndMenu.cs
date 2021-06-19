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
        // Display the Winner Name
        if (Rules.Winner == null)
            GameObject.Find("Name").GetComponent<TextMeshProUGUI>().text = TurnManager.GetInstance().GetCurrentPlayer().ToString();
        else
            GameObject.Find("Name").GetComponent<TextMeshProUGUI>().text = Rules.Winner;
    }
    public void Restart()
    {
        // Restart The game, goes to init state and reset instances
        Rules.states = Rules.MyEnum.INIT;
        CarManager.instance = null;
        TurnManager.instance = null;
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
