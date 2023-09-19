using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// A Battle class must be on the same GameObject as this
// Or the battle won't load.
public class BattleController : MonoBehaviour
{
    public bool inBattle;
    private BattleTurnController turnController;
    private List<BattleActor> battleActors;
    public List<BattleActor> sortedActors;
    private DiceRoller dice;

    void Start()
    {
        dice = new DiceRoller();
        battleActors = new List<BattleActor>();
        inBattle = false;
       
    }

    void loadBattle(){
        Debug.Log("Loading battle from GameObject...");
        ArrayList actorNames = new ArrayList();
        try{
            actorNames = gameObject.GetComponent<Battle>().actorNames;
        } catch (NullReferenceException e) {
            Debug.Log("No battle associated with BattleController GameObject!");
            return;
        }
        List<GameObject> actors = new List<GameObject>();

        foreach(string x in actorNames){
            actors.Add(GameObject.Find(x));
        }

        setupBattle(actors);
        startBattle();
    }

    public void setupBattle(List<GameObject> actors)
    {
        List<Character> charactersInScene = findActorsInScene(actors);
        foreach (Character character in charactersInScene){
            BattleActor bActor = generateBattleActorFromCharacter(character);
            int initiative = rollInitiative(bActor);
            bActor.initiative = initiative;
            battleActors.Add(bActor);
        }
        sortedActors = sortInitiativeOrder(battleActors);
    }

    public void startBattle(){
        inBattle = true;
        turnController = gameObject.AddComponent<BattleTurnController>();
        turnController.startBattle(sortedActors);
    }

    private List<BattleActor> sortInitiativeOrder(List<BattleActor> actors){
        return actors.OrderByDescending(actor => actor.initiative).ToList();
    }
    /*
       List<BattleActor> sortedActors = new List<BattleActor>();
        List<BattleActor> temp;
        while(dict.Count != sortedActors.Count){
            temp = new List<BattleActor>();
            foreach (BattleActor x in dict.Keys){
                if (temp.Count == 0){
                    temp.Add(x);
                    continue;
                }
                foreach (BattleActor y in temp){
                    if (dict[y] == dict[x]){
                        temp.Add(x);
                    }
                    if (dict[y] > dict[x]){
                        temp.Clear();
                        temp.Add(x);
                        break;
                    }
                }
            }
            foreach (BattleActor z in temp){
                sortedActors.Add(z);
                dict.Remove(z);
            }
        }
        return sortedActors;
    */

    //Gets character object attached to each provided GameObject
    private List<Character> findActorsInScene(List<GameObject> actors)
    {
        List<Character> chars = new List<Character>();
        foreach (GameObject x in actors){
            chars.Add(x.GetComponent<Character>());
            
        }
        return chars;
    }
     private BattleActor generateBattleActorFromCharacter(Character character){
        return new BattleActor(character, character.gameObject.transform.position, character.type);
    }

    public int rollInitiative(BattleActor ba)
    {
        return dice.rollDice(20) + ba.character.initiativeModifier;
    }

    void exitBattle()
    {
        inBattle = false;
        Destroy(turnController);
        battleActors = null;
        sortedActors = null;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && !inBattle)
        {
            loadBattle();
        }
    }
}
