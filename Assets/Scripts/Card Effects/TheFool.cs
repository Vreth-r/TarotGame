using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "The Fool", menuName = "Tarot/Effects/Fool")]
public class TheFool : Card
{
    public int id = 0;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        if(self.life == opponent.life)
        {
            GameVariables.addARound = true;
        }
        return $"[{cardName}]: {description}";
    }
}