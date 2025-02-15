using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{
    protected GameManager gameManager;

    public GameState(GameManager manager)
    {
        gameManager = manager;
    }

    public virtual void EnterState() { } 
    public virtual void UpdateState() { } 
    public virtual void ExitState() { }   
}

