using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleTurnController : MonoBehaviour
{
    private BattleController battleController;
    PlayerInfoController playerInfo;
    EnemyInfoController enemyInfo;
    
    public int turnNumber;
    public bool aiThinking = false;
    public bool battlePaused = true;
    public bool battleInProgress = false;
    private BattleActor currentTurn;
    private List<BattleActor> actors;
    private GameObject UI;
    private GameObject playerInfoUI;

    private GameObject enemyInfoUI;
    private GameObject playerActionsUI;

    public bool isInitialized {get; set;}


    
    

    void Start()
    {
        battleController = gameObject.GetComponent<BattleController>();
        turnNumber = 1;
        isInitialized = true;
    }

    public void startBattle(List<BattleActor> battleActors){
        Debug.Log("TurnController has started Battle");
        actors = battleActors;
        turnNumber = 1;
        battleInProgress = true;
        currentTurn = actors.ElementAt(0);

        playerInfoUI = GameObject.Find("PlayerInfo");
        enemyInfoUI = GameObject.Find("EnemyInfo");
        playerActionsUI = GameObject.Find("PlayerActions");
        UI = GameObject.Find("UI");
        
        displayPortraits(actors);
        StartCoroutine(fadeInCanvasGroup(playerActionsUI.GetComponent<CanvasGroup>()));
        StartCoroutine(fadeInCanvasGroup(playerInfoUI.GetComponent<CanvasGroup>()));

        highlightPlayer(currentTurn);

        updateAllStats(true);
        battlePaused = false;
        Debug.Log("=============== Turn: "+turnNumber+" ===============");

        //playTransitionAnimation();
        //enableUI();
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
        playerInfo = playerInfoUI.GetComponent<PlayerInfoController>();
        enemyInfo = enemyInfoUI.GetComponent<EnemyInfoController>();
        GameObject playerInfoContainerPrefab = Resources.Load<GameObject>("Prefabs/PlayerInfoContainerPrefab");
        GameObject enemyInfoContainerPrefab = Resources.Load<GameObject>("Prefabs/EnemyInfoContainerPrefab");
        foreach (BattleActor ba in battleActors){
            if (ba.character.type == ActorType.PLAYER){
                playerInfo.addPlayerInfoContainer(ba, playerInfoContainerPrefab);
            } else {
                enemyInfo.addEnemyInfoContainer(ba, enemyInfoContainerPrefab);
            }
            
        }
    }
    void enableUI(){
        //battleUI.visible = true;
    }
    void updateAllStats(bool instantly = false){
        battlePaused = true; // This doesn't pause because it launches coroutines
        playerInfo.updateStats(instantly);
        enemyInfo.updateStats(instantly);
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

        aiThinking = false;
        battlePaused = true;

        playerInfo.fadeAllPortraits();
        enemyInfo.fadeAllPortraits();
        //allyInfo.fadeAllAllies();

        updateAllStats();


        if (actors.IndexOf(currentTurn) != actors.Count-1){
            currentTurn = actors.ElementAt(actors.IndexOf(currentTurn)+1);
        }else{
            turnNumber +=1;
            Debug.Log(" =============== Turn: "+turnNumber+" ===============");
            currentTurn = actors.ElementAt(0);
        }

        highlightPlayer(currentTurn);
        battlePaused = false;
    }

    void highlightPlayer(BattleActor ba){
        if (currentTurn.type == ActorType.PLAYER){
            playerInfo.highlightPlayer(currentTurn);
        } else if (currentTurn.type == ActorType.NPC_ENEMY){
            enemyInfo.highlightEnemy(currentTurn);
        } else if (currentTurn.type == ActorType.NPC_FRIENDLY){
            //allyInfo.highlightAlly(currentTurn);
        }
    }

    IEnumerator enemyTurn(BattleActor enemy){
        enemy.takeTurn(this);
        yield return new WaitForSeconds(1f);
        EndTurn();
    }


    // Update is called once per frame

    void Update()
    {

            //Battle logic
            //Check if it's a player, npc, or environment turn
        if (!aiThinking && !battlePaused){
            if (currentTurn.type == ActorType.PLAYER){
                if (Input.GetKeyUp(KeyCode.K))
                {
                    EndTurn();
                }
                return; //If it's a player turn, do nothing. Players will move, attack, and end turn indepentently.
            }
            if (currentTurn.type == ActorType.NPC_ENEMY){
                aiThinking = true;
                StartCoroutine(enemyTurn(currentTurn));
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
