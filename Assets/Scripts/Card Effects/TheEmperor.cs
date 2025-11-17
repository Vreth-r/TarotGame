using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "The Emperor", menuName = "Tarot/Effects/Emperor")]
public class TheEmperor : Card
{
    public int id = 4;
    public int damage = 4;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        opponent.ApplyDamage(damage);
        return $"[{cardName}]: {description}";
    }
}