using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Death", menuName = "Tarot/Effects/Death")]
public class Death : Card
{
    public int id = 13;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        GameVariables.nextCardNegate = true;
        return $"[{cardName}]: {description}";
    }
}