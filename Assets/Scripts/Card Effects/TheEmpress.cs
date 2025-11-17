using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "The Empress", menuName = "Tarot/Effects/Empress")]
public class TheEmpress : Card
{
    public int id = 3;
    public int healAmount = 3;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        self.Heal(healAmount);
        return $"[{cardName}]: {description}";
    }
}