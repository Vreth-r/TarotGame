using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Temperance", menuName = "Tarot/Effects/Temperance")]
public class Temperance : Card
{
    public int id = 14;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        self.patience = true;
        return $"[{cardName}]: {description}";
    }
}