using UnityEngine;

[CreateAssetMenu(fileName = "Death", menuName = "Tarot/Effects/Death")]
public class Death : Card
{
    public int id = 13;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        return;
    }
}