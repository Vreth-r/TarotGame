using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Justice", menuName = "Tarot/Effects/Justice")]
public class Justice : Card
{
    public int id = 11;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        opponent.SetHealth(self.life);
        return $"[{cardName}]: {description}";
    }
}