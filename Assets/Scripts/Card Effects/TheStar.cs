using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "The Star", menuName = "Tarot/Effects/Star")]
public class TheStar : Card
{
    public int healthAmount = 9;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        self.SetHealth(healthAmount);
        opponent.SetHealth(healthAmount);
        return $"[{cardName}]: {description}";
    }
}