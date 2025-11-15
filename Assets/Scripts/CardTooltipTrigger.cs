using UnityEngine;
using UnityEngine.EventSystems;

public class CardTooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Card card;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector2 pos = eventData.position;
        Events.OnTooltipShow?.Invoke(card.cardName, card.description, pos);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Events.OnTooltipHide?.Invoke();
    }
}