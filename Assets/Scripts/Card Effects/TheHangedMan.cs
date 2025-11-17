using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "The Hanged Man", menuName = "Tarot/Effects/HangedMan")]
public class TheHangedMan : Card
{
    public int id = 12;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        self.protection = true;
        opponent.protection = true;
        return $"[{cardName}]: {description}";
    }
}