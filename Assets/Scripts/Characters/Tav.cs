public class Tav : Character
{
   public Tav() : base("Tav"){

        this.charClass = CharClass.Wizard;
        this.hp = 99;
        this.tempHp = 0;
        this.maxHp = 99;
        this.ac = 20;

        //Attributes
        Attributes tavAttributes = new Attributes();
        tavAttributes.Charisma.value = 20;
        this.charAttributes = tavAttributes;

        //Skills
        Skills tavSkills = new Skills();
        tavSkills.AnimalHandling.isProficient = true;
        this.charSkills = tavSkills;


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
