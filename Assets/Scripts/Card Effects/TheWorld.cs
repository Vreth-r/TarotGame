using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "The World", menuName = "Tarot/Effects/World")]
public class TheWorld : Card
{
    public int id = 21;
    public int healthThreshold = 5;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        if(self.life >= opponent.life + healthThreshold)
        {
            GameVariables.endGame = true;
        }
        return $"[{cardName}]: {description}";
    }
}