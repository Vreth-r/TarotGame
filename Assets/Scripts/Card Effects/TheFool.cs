using UnityEngine;

[CreateAssetMenu(fileName = "The Fool", menuName = "Tarot/Effects/Fool")]
public class TheFool : Card
{
    public int id = 0;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        return;
    }
}