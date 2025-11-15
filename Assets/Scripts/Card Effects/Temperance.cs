using UnityEngine;

[CreateAssetMenu(fileName = "Temperance", menuName = "Tarot/Effects/Temperance")]
public class Temperance : Card
{
    public int id = 14;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        return;
    }
}