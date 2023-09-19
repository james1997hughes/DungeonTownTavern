public class BasicEnemy : Character
{
   public BasicEnemy() : base("Basic Enemy"){

        this.charClass = CharClass.Rogue;
        this.hp = 5;
        this.tempHp = 0;
        this.maxHp = 5;
        this.ac = 5;

        //Attributes
        Attributes attributes = new Attributes();
        attributes.Charisma.value = 20;
        this.charAttributes = attributes;

        //Skills
        Skills skills = new Skills();
        skills.AnimalHandling.isProficient = true;
        this.charSkills = skills;


        this.initiativeModifier = charAttributes.Dexterity.modifier; // + mods from feats, class bonuses, etc..

        //These should be calculated
        this.actionsPerTurn = 1;
        this.bonusActionsPerTurn = 1;
        this.reactionsPerTurn = 1;
        this.movementSpeed = 10;

        this.actions = new ActionSet(commonActions: true);

        this.type = ActorType.NPC_ENEMY;
   }

}
