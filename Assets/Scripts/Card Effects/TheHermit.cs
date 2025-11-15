using UnityEngine;

[CreateAssetMenu(fileName = "The Hermit", menuName = "Tarot/Effects/Hermit")]
public class TheHermit : Card
{
    public int id = 9;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        return;
    }
}