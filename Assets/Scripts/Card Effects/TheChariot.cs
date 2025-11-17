using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "The Chariot", menuName = "Tarot/Effects/Chariot")]
public class TheChariot : Card
{
    public int id = 7;
    public int lifeThreshold = 2;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        if(opponent.life <= lifeThreshold)
        {
            opponent.SetHealth(0);
        }
        return $"[{cardName}]: {description}";
    }
}