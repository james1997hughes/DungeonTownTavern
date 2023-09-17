using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string charName;
    public CharClass charClass;
    public int hp;
    public int tempHp;
    public int ac;
    public int initiativeModifier;
    public int actionsPerTurn;
    public int bonusActionsPerTurn;
    public int reactionsPerTurn;
    public int movementSpeed;
    public Attributes charAttributes;
    public Skills charSkills;
    public ActorType type;
    public Actions actions;

    public Character(string name, CharClass charClass, int hp, int tempHp, int ac, Attributes charAttributes, Skills charSkills) {
        this.charName = name;
        this.charClass = charClass;
        this.hp = hp;
        this.tempHp = hp;
        this.ac = ac;
        this.charAttributes = charAttributes;
        this.charSkills = charSkills;
        this.initiativeModifier = charAttributes.Dexterity.modifier; // + mods from feats, class bonuses, etc..
        this.actionsPerTurn = 1;
        this.bonusActionsPerTurn = 1;
        this.reactionsPerTurn = 1;
        this.movementSpeed = 10;
    }
    public Character (string name){}

}
