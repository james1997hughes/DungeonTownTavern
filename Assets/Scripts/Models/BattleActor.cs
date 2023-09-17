using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleActor
{
    public Character character;
    public bool playerControlled;
    public ActorType type;
    public ArrayList statusEffects;
    public Vector2 position;

    public int movementLeft;
    public int actionsLeft;
    public int bonusActionsLeft;
    public int reactionsLeft;

    public BattleActor(Character character, Vector2 position, ActorType type){
        this.character = character;
        this.position = position;
        this.movementLeft = character.movementSpeed;
        this.actionsLeft = character.actionsPerTurn;
        this.bonusActionsLeft = character.bonusActionsPerTurn;
        this.reactionsLeft = character.reactionsPerTurn;
        this.type = type;
    }

    public void makeMove(){
        //Make move, deduct movement speed
    }
    public void doAction(){
        //Do action, deduct appropriate action
    }
}
