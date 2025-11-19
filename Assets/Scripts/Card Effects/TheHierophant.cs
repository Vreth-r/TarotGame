using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "The Hierophant", menuName = "Tarot/Effects/Hierophant")]
public class TheHierophant : Card
{
    // yes i thought of infinite recursion
    // no im not doing anything about it trust the semantics
    public int id = 5;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        // Find both cards owned by self
        List<int> selfIndices = new List<int>();

        for (int i = 0; i < orderedCards.Length; i++)
        {
            if (ownerships[i] == self.ownerNumber)
                selfIndices.Add(i);
        }

        // Find THIS card’s index
        int thisIndex = -1;
        for (int i = 0; i < orderedCards.Length; i++)
        {
            if (orderedCards[i] == this)
            {
                thisIndex = i;
                break;
            }
        }

        // If somehow not found, fail safely
        if (thisIndex == -1)
            return $"[{cardName}] could not locate itself in order.";

        // Identify the OTHER card
        int otherIndex = (selfIndices[0] == thisIndex) ? selfIndices[1] : selfIndices[0];
        Card otherCard = orderedCards[otherIndex];

        if (otherCard == null)
            return $"[{cardName}] found no card to copy.";
        
        if(otherCard.cardName == "The High Priestess" || otherCard.cardName == "The Magician" || otherCard.cardName == "The Hierophant")
        {
            return $"Can't copy other copy card!";
        }

        // Activate the other card's effect as if this card played it
        otherCard.Activate(self, opponent, orderedCards, ownerships);

        return $"[{cardName}]: {description} [{otherCard.cardName}]";
    }
}