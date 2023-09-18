using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAction
{
    //This is a parent class for all character actions.
    //Store here stuff common to all actions, such as a sprite, name, type
    //Single actions, such as Attack, Move, Shove will inherit this class
    CharacterActions charAction;
    public Sprite actionSprite;
    public string actionName;
    public ActionType actionType;
    public CharacterAction(CharacterActions charAction){
        this.charAction = charAction;
    }

}
