using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleActor
{
    public Character character;
    public bool playerControlled;
    public GameObject playerInfoContainer;
    public GameObject enemyInfoContainer;
    public ActorType type;
    public ArrayList statusEffects;
    public Vector2 position;

    public int initiative { get; set;}

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
        this.initiative = 10; //Always assigned at start of combat
    }

    public void takeTurn(BattleTurnController turnController){
        character.takeTurn(this, turnController);
    }

}
