using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleTurnController : MonoBehaviour
{
    private BattleController battleController;
    public int turnNumber;
    public bool battleInProgress = false;
    private BattleActor currentTurn;
    private List<BattleActor> actors;
    private GameObject UI;
    private GameObject playerInfoUI;
    private GameObject playerActionsUI;


    
    

    void Start()
    {
        battleController = gameObject.GetComponent<BattleController>();
        turnNumber = 0;
        UI = GameObject.Find("UI");

    }

    public void startBattle(List<BattleActor> battleActors){
        Debug.Log("TurnController has started Battle");
        actors = battleActors;
        turnNumber = 1;
        battleInProgress = true;
        currentTurn = actors.ElementAt(0);
        
        displayPortraits(battleActors);
        playerInfoUI = GameObject.Find("PlayerInfo");
        playerActionsUI = GameObject.Find("PlayerActions");
        StartCoroutine(fadeInCanvasGroup(playerActionsUI.GetComponent<CanvasGroup>()));
        StartCoroutine(fadeInCanvasGroup(playerInfoUI.GetComponent<CanvasGroup>()));
        playTransitionAnimation();
        enableUI();
    }

    IEnumerator fadeInCanvasGroup(CanvasGroup group){
        while (group.alpha != 1.0f){

            if (group.alpha > 1.0f){ group.alpha = 1.0f;}
            if (group.alpha < 1.0f){
                group.alpha += 0.3f * Time.deltaTime;
            }

            yield return null;
        }
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
        Debug.Log("Ending turn " + turnNumber + " of " + currentTurn.character.charName);
        if (actors.IndexOf(currentTurn) != actors.Count-1){
            currentTurn = actors.ElementAt(actors.IndexOf(currentTurn)+1);
        }else{
            turnNumber +=1;
            Debug.Log(" =============== Turn: "+turnNumber+" ===============");
            currentTurn = actors.ElementAt(0);
        }

    }


    // Update is called once per frame

    void Update()
    {

            //Battle logic
            //Check if it's a player, npc, or environment turn

            if (currentTurn.type == ActorType.PLAYER){
                if (Input.GetKeyUp(KeyCode.K))
                {
                    EndTurn();
                }
                return; //If it's a player turn, do nothing. Players will move, attack, and end turn indepentently.
            }
            if (currentTurn.type == ActorType.NPC_ENEMY){
                //CalculateMove();
                //doMove();
                EndTurn();
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
