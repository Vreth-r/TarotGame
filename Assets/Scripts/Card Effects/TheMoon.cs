using UnityEngine;

[CreateAssetMenu(fileName = "The Moon", menuName = "Tarot/Effects/Moon")]
public class TheMoon : Card
{
    public int id = 18;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        return;
    }
}