using UnityEngine;

[CreateAssetMenu(fileName = "The World", menuName = "Tarot/Effects/World")]
public class TheWorld : Card
{
    public int id = 21;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        return;
    }
}