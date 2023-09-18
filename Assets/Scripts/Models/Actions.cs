using System.Collections;
public class Actions
{
    // This is a holder class for all of a characters actions.
    // Every character has an Actions
    // 
    public bool commonActions;
    public Actions(bool commonActions){
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
