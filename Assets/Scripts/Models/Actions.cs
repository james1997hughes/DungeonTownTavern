using System.Collections;
public class Actions
{
    public bool commonActions;
    public Actions(bool commonActions){
        this.commonActions = commonActions;
    }
    public ArrayList getActions(){
        ArrayList actions = new ArrayList();
        if (commonActions){
            //Add common actions to actions
        }
        return actions;
    }
}
