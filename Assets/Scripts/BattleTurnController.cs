using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleTurnController : MonoBehaviour
{
    private BattleController battleController;
    public int turnNumber = 0;
    private bool waitingForInput = false;
    private bool turnInProgress = false;
    private bool battleInProgress = false;
    private BattleActor currentTurn;
    private List<BattleActor> actors;

    
    

    void Start()
    {
        battleController = gameObject.GetComponent<BattleController>();
    }

    public void startBattle(List<BattleActor> battleActors){
        actors = battleActors;
        turnNumber = 1;
        battleInProgress = true;
        currentTurn = actors.ElementAt(0);
        
        displayPortraits(battleActors);
        playTransitionAnimation();
        enableUI();
    }



    void displayPortraits(List<BattleActor> battleActors){
        //Display turn UI - player + enemy portraits, health, etc.
    }
    void enableUI(){
        //battleUI.visible = true;
    }
    void playTransitionAnimation(){

    }
    void disableUI(){
        //battleUI.visible = false;
    }
    void TurnTransition(){
        //Move camera to new subject
        //Highlight subject portrait in ui
    }
    void EndTurn(){
        if (actors.IndexOf(currentTurn) != actors.Count-1){
            currentTurn = actors.ElementAt(actors.IndexOf(currentTurn)+1);
        }else{
            currentTurn = actors.ElementAt(0);
        }

    }


    // Update is called once per frame
    int buffer = 0;
    void Update()
    {
        buffer++;
        if (battleInProgress && buffer>=5){
            buffer = 0;
            //Battle logic
            //Check if it's a player, npc, or environment turn

            if (currentTurn.type == ActorType.PLAYER && waitingForInput){
                return; //If it's a player turn, and no moves have been made: do nothing
            }
            if (currentTurn.type == ActorType.PLAYER && !waitingForInput){
                //Handle player actions as an event - don't 'queue' them then handle here.
                //All that should be here is the following:
                //EndTurn();
            }
            if (currentTurn.type == ActorType.NPC_ENEMY){
                //CalculateMove();
                //doMove();
                //EndTurn();
            }
            if (currentTurn.type == ActorType.NPC_NEUTRAL){
                //CalculateMove();
                //doMove();
                //EndTurn();
            }
            if (currentTurn.type == ActorType.NPC_FRIENDLY){
                //CalculateMove();
                //doMove();
                //EndTurn();
            }
            if (currentTurn.type == ActorType.ENVIRONMENT){
                //EnvironmentTurn();
                //EndTurn();
            }

        }
    }
}
