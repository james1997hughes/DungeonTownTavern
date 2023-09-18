using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public bool inBattle;

    private BattleTurnController turnController;
    private Dictionary<BattleActor, int> battleActors;
    public List<BattleActor> sortedActors;
    private DiceRoller dice;

    void Start()
    {
        dice = new DiceRoller();
        battleActors = new Dictionary<BattleActor, int>();
        inBattle = false;
       
    }

    void testBattle(){
        Debug.Log("TEST BATTLE START");
        List<GameObject> actors = new List<GameObject>();
        actors.Add(GameObject.Find("Enemy1"));
        actors.Add(GameObject.Find("Enemy2"));
        setupBattle(actors);
        startBattle();
    }

    public void setupBattle(List<GameObject> actors)
    {
        List<Character> charactersInScene = findActorsInScene(actors);


        foreach (Character character in charactersInScene){
            BattleActor bActor = generateBattleActorFromCharacter(character);
            battleActors.Add(bActor, rollInitiative(bActor));
        }
        sortedActors = sortInitiativeOrder(battleActors);

    }

    public void startBattle(){
        inBattle = true;
        turnController = gameObject.AddComponent<BattleTurnController>();
        turnController.startBattle(sortedActors);
    }

    private List<BattleActor> sortInitiativeOrder(Dictionary<BattleActor, int> dict){
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
            }
        }
        return sortedActors;
    }

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
            testBattle();
        }
    }
}
