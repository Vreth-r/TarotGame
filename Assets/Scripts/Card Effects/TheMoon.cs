using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "The Moon", menuName = "Tarot/Effects/Moon")]
public class TheMoon : Card
{
    public int id = 18;
    public int cardsToDraw = 1;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        opponent.DrawCards(cardsToDraw);
        return $"[{cardName}]: {description}";
    }
}