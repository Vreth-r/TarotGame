using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "The Devil", menuName = "Tarot/Effects/Devil")]
public class TheDevil : Card
{
    public int id = 15;
    public int healthCost = 6;
    public int cardsToDraw = 2;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        self.ApplyDamage(healthCost);
        self.DrawCards(cardsToDraw);
        return $"[{cardName}]: {description}";
    }
}