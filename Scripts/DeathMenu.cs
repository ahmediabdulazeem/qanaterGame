using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

    public string mainMenuLevel;

    public void RestartGame() {

        FindObjectOfType<GameManger>().Reset();

    }

    public void QuitToMenu() {

        Application.LoadLevel(mainMenuLevel);


    }
}
