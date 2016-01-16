using UnityEngine;
using System.Collections;

public class menu_buttons : MonoBehaviour {

    public void playGame(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void controlGame(string controlName)
    {
        Application.LoadLevel(controlName);
    }

    public void exitToMain(string toMain)
    {
        Application.LoadLevel(toMain);
    }
}
