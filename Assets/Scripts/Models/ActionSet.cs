using System.Collections;
public class ActionSet
{
    // This is a holder class for all of a characters actions.
    // Every character has an ActionSet
    // It is a list of all actions they can take in a turn
    // cast spell is an action - each individual spell is not
    public bool commonActions;
    public ActionSet(bool commonActions){
        this.commonActions = commonActions;
    }
    public ArrayList getActions(){
        ArrayList actions = new ArrayList();
        if (commonActions){
            actions.Add(new CharacterAction(CharacterActions.ATTACK));
            actions.Add(new CharacterAction(CharacterActions.MOVE));
            actions.Add(new CharacterAction(CharacterActions.END_TURN));
        }
        return actions;
    }
}
