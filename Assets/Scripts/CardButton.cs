using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardButton : MonoBehaviour
{
    //public TextMeshProUGUI nameText;
    public Image artworkImage;

    private Card card;
    private UIManager uiManager;

    private bool selected;

    private void OnClick()
    {
        SetSelected(!selected);
        if(uiManager != null)
        {
            uiManager.ToggleCardSelection(card, this);
        }
    }
    public void Setup(Card card, UIManager manager)
    {
        this.card = card;
        if(manager != null)
        {
            this.uiManager = manager;
        }

        //nameText.text = card.cardName;

        if (artworkImage != null && card.artwork != null)
            artworkImage.sprite = card.artwork;

        // Bind button click
        GetComponent<Button>().onClick.AddListener(OnClick);
        SetSelected(false);
    }

    public void SetSelected(bool state)
    {
        selected = state;
        GetComponent<Image>().color = state ? new Color(0.6f,1f,0.6f) : Color.white;
    }
}