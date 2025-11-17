using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Strength", menuName = "Tarot/Effects/Strength")]
public class Strength : Card
{
    public int id = 8;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        self.sturdy = true;
        return $"[{cardName}]: {description}";
    }
}