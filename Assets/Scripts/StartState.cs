using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : GameState
{
    public StartState(GameManager manager) : base(manager) { }

    public override void EnterState()
    {
        Time.timeScale = 0; 
        gameManager.startUI.SetActive(true);
    }

    public override void ExitState()
    {
        gameManager.startUI.SetActive(false);
        Time.timeScale = 1; 
    }
}
