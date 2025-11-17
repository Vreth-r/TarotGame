using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "The Hermit", menuName = "Tarot/Effects/Hermit")]
public class TheHermit : Card
{
    public int id = 9;
    public int healAmount = 2;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        if(self.life > opponent.life)
        {
            self.Heal(healAmount);
        }
        return $"[{cardName}]: {description}";
    }
}