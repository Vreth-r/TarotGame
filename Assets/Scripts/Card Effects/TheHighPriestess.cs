using UnityEngine;

[CreateAssetMenu(fileName = "The High Priestess", menuName = "Tarot/Effects/HighPriestest")]
public class TheHighPriestess : Card
{
    public int id = 2;
    public override void Activate(Player self, Player opponent, Card leftCard = null)
    {
        return;
    }
}