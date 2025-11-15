using UnityEngine;

[CreateAssetMenu(fileName = "The Devil", menuName = "Tarot/Effects/Devil")]
public class TheDevil : Card
{
    public int id = 15;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        return;
    }
}