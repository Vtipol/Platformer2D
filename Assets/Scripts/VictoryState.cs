using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryState : GameState
{
    public VictoryState(GameManager manager) : base(manager) { }

    public override void EnterState()
    {
        Time.timeScale = 0; 
        gameManager.victoryUI.SetActive(true);
    }

    public override void ExitState()
    {
        gameManager.victoryUI.SetActive(false);
    }
}

