using UnityEngine;

[CreateAssetMenu(fileName = "The Lovers", menuName = "Tarot/Effects/Lovers")]
public class TheLovers : Card
{
    public int id = 6;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        return;
    }
}