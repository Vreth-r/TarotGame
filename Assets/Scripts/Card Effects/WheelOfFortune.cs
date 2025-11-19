using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Wheel of Fortune", menuName = "Tarot/Effects/WoF")]
public class WheelOfFortune : Card
{
    public int id = 10;

    [Header("THIS IS ARRAY INDEX, SO 0-3 NOT 1-4")]
    public int slotA = 1;
    public int slotB = 2;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        GameVariables.RequestSwap(slotA,slotB);
        return $"[{cardName}]: {description}";
    }
}