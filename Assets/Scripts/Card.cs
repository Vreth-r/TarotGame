using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Card", menuName = "Tarot/Card")]
public class Card : ScriptableObject
{
    public string cardName;
    [TextArea] public string description;
    public Sprite artwork;

    public virtual string Activate(Player self, Player opponent, Card[] orderedCards, int[] ownerships)
    {
        return $"[{cardName}]: {description}";
    }
}