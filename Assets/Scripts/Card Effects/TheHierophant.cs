using UnityEngine;

[CreateAssetMenu(fileName = "The Hierophant", menuName = "Tarot/Effects/Hierophant")]
public class TheHierophant : Card
{
    public int id = 5;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        return;
    }
}