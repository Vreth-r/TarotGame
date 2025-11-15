using UnityEngine;

[CreateAssetMenu(fileName = "Justice", menuName = "Tarot/Effects/Justice")]
public class Justice : Card
{
    public int id = 11;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        return;
    }
}