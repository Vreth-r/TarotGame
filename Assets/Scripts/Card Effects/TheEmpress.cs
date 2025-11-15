using UnityEngine;

[CreateAssetMenu(fileName = "The Empress", menuName = "Tarot/Effects/Empress")]
public class TheEmpress : Card
{
    public int id = 3;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        return;
    }
}