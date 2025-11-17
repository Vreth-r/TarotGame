using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Wheel of Fortune", menuName = "Tarot/Effects/WoF")]
public class WheelOfFortune : Card
{
    public int id = 10;
    public override string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        return "";
    }
}