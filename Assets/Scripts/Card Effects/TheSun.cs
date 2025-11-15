using UnityEngine;

[CreateAssetMenu(fileName = "The Sun", menuName = "Tarot/Effects/Sun")]
public class TheSun : Card
{
    public int id = 19;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        return;
    }
}