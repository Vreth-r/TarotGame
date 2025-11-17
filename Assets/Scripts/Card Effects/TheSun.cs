using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "The Sun", menuName = "Tarot/Effects/Sun")]
public class TheSun : Card
{
    public int id = 19;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        return $"[{cardName}]: {description}";
    }
}