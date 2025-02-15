using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameState
{
    public GameOverState(GameManager manager) : base(manager) { }

    public override void EnterState()
    {
        Time.timeScale = 0;
        gameManager.gameOverUI.SetActive(true);
    }

    public override void ExitState()
    {
        gameManager.gameOverUI.SetActive(false);
    }
}
