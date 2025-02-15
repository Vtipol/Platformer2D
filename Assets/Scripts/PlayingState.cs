using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingState : GameState
{
    public PlayingState(GameManager manager) : base(manager) { }

    public override void EnterState()
    {
        Time.timeScale = 1;
    }
}
