using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Tarot/Card")]
public class Card : ScriptableObject
{
    public string cardName;
    [TextArea] public string description;
    public Sprite artwork;

    public virtual void Activate(Player self, Player opponent, Card leftcard = null)
    {
        Debug.Log($"{cardName} activated.");
    }
}