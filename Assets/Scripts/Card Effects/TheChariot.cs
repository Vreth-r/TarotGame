using UnityEngine;

[CreateAssetMenu(fileName = "The Chariot", menuName = "Tarot/Effects/Chariot")]
public class TheChariot : Card
{
    public int id = 7;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        return;
    }
}