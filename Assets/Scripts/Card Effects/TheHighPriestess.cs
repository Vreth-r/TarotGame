using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "The High Priestess", menuName = "Tarot/Effects/HighPriestest")]
public class TheHighPriestess : Card
{
    public int id = 2;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        // find the second card belonging to opp
        int count = 0;
        Card cardToCopy = null;

        for (int i = 0; i < orderedCards.Length; i++)
        {
            if (ownerships[i] == opponent.ownerNumber)
            {
                count++;
                if (count == 2)
                {
                    cardToCopy = orderedCards[i];
                    break;
                }
            }
        }

        // activate the copied card
        cardToCopy.Activate(self, opponent, orderedCards, ownerships);

        return $"[{cardName}]: {description} [{cardToCopy.cardName}]";
    }
}