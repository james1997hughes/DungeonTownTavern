public class Shadowheart : Character
{
   public Shadowheart() : base("Shadowheart"){

        this.charName = "Shadowheart";
        this.charClass = CharClass.Wizard;
        this.hp = 30;
        this.tempHp = 0;
        this.maxHp = 60;
        this.ac = 13;

        //Attributes
        Attributes shadowHeartAttributes = new Attributes();
        shadowHeartAttributes.Charisma.value = 20;
        this.charAttributes = shadowHeartAttributes;

        //Skills
        Skills shadowHeartSkills = new Skills();
        shadowHeartSkills.AnimalHandling.isProficient = true;
        this.charSkills = shadowHeartSkills;


        this.initiativeModifier = charAttributes.Dexterity.modifier; // + mods from feats, class bonuses, etc..

        //These should be calculated
        this.actionsPerTurn = 1;
        this.bonusActionsPerTurn = 1;
        this.reactionsPerTurn = 1;
        this.movementSpeed = 10;

        this.actions = new ActionSet(commonActions: true);

        this.type = ActorType.PLAYER;
   }

}
