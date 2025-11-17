using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Judgement", menuName = "Tarot/Effects/Judgement")]
public class Judgement : Card
{
    public int id = 20;
    public int cardsToDraw = 1;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        self.DrawCards(cardsToDraw);

        return $"[{cardName}]: {description}";
    }
}