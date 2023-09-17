public class Shadowheart : Character
{
   public Shadowheart() : base("Shadowheart"){
        this.charClass = CharClass.Wizard;
        this.hp = 30;
        this.tempHp = 0;
        this.ac = 13;
        this.charAttributes = new Attributes();
        this.charSkills = new Skills();
        this.initiativeModifier = charAttributes.Dexterity.modifier; // + mods from feats, class bonuses, etc..
        this.actionsPerTurn = 1;
        this.bonusActionsPerTurn = 1;
        this.reactionsPerTurn = 1;
        this.movementSpeed = 10;
        this.type = ActorType.PLAYER;
   }

}
