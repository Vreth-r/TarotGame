using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "The Lovers", menuName = "Tarot/Effects/Lovers")]
public class TheLovers : Card
{
    public int id = 6;
    public int healAmount = 5;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        self.Heal(healAmount);
        opponent.Heal(healAmount);
        return $"[{cardName}]: {description}";
    }
}