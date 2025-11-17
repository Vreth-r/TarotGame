using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "The Tower", menuName = "Tarot/Effects/Tower")]
public class TheTower : Card
{
    public int id = 16;
    public int damageAmount = 5;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        self.ApplyDamage(damageAmount);
        opponent.ApplyDamage(damageAmount);
        return $"[{cardName}]: {description}";
    }
}