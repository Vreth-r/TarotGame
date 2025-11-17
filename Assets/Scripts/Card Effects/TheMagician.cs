using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "The Magician", menuName = "Tarot/Effects/Magician")]
public class TheMagician : Card
{
    public int id = 1;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        // Find this card's index in the order
        int myIndex = -1;
        for (int i = 0; i < orderedCards.Length; i++)
        {
            if (orderedCards[i] == this)
            {
                myIndex = i;
                break;
            }
        }

        // No card to the left -> do nothing
        if (myIndex == 0)
            return $"[{cardName}] has no card to the left — effect does nothing.";

        Card leftCard = orderedCards[myIndex - 1];

        if (leftCard == null)
            return $"[{cardName}] found no card to the left — effect does nothing.";

        // Activate the copied card as if this card cast it
        leftCard.Activate(self, opponent, orderedCards, ownerships);
        return $"[{cardName}]: {description} [{leftCard.cardName}]";
    }
}