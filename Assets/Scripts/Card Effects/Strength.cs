using UnityEngine;

[CreateAssetMenu(fileName = "Strength", menuName = "Tarot/Effects/Strength")]
public class Strength : Card
{
    public int id = 8;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        return;
    }
}