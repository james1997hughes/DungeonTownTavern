using System;

public class DiceRoller
{
    Random rand;
    public DiceRoller(){
        rand = new Random();
    }
    public int rollDice(int d){

        return rand.Next(1, d);
    }
    public int rollDice(int d, int modifier){
        return rand.Next(1, d)+modifier;
    }
    public int[] rollDiceWithAdvantage(int d){
        int []x = {rand.Next(1,d), rand.Next(1,d)};
        return x;
    }
     public int[] rollDiceWithAdvantage(int d, int modifier){
        int []x = {rand.Next(1,d)+modifier, rand.Next(1,d)+modifier};
        return x;
    }
}
