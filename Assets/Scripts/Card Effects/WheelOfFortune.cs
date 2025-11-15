using UnityEngine;

[CreateAssetMenu(fileName = "Wheel of Fortune", menuName = "Tarot/Effects/WoF")]
public class WheelOfFortune : Card
{
    public int id = 10;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        return;
    }
}