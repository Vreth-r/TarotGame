using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CardTooltipManager : MonoBehaviour
{
    public RectTransform tooltipRoot;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descText;

    private Canvas canvas;
    private RectTransform canvasRect;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        canvasRect = canvas.transform as RectTransform;

        HideTooltip();
    }

    private void OnEnable()
    {
        Events.OnTooltipShow += HandleShow;
        Events.OnTooltipHide += HandleHide;
    }

    private void OnDisable()
    {
        Events.OnTooltipShow -= HandleShow;
        Events.OnTooltipHide -= HandleHide;
    }

    private void HandleShow(string name, string desc, Vector2 pointerPos)
    {
        nameText.text = name;
        descText.text = desc;

        UpdatePosition(pointerPos);
        tooltipRoot.gameObject.SetActive(true);
    }

    private void HandleHide()
    {
        HideTooltip();
    }

    private void Update()
    {
        if (!tooltipRoot.gameObject.activeSelf)
            return;

        // Continually follow mouse
        Vector2 mousePos = Mouse.current.position.ReadValue();
        UpdatePosition(mousePos);
    }

    private void UpdatePosition(Vector2 screenPos)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect,
            screenPos,
            canvas.worldCamera,
            out Vector2 localPos
        );

        Vector2 offset = new Vector2(200, 75);
        Vector2 targetPos = localPos + offset;

        tooltipRoot.anchoredPosition = ClampToCanvas(targetPos);
    }

    private Vector2 ClampToCanvas(Vector2 pos)
    {
        Vector2 tooltipSize = tooltipRoot.sizeDelta;
        Vector2 canvasSize = canvasRect.sizeDelta;

        float halfTooltipW = tooltipSize.x * tooltipRoot.pivot.x;
        float halfTooltipH = tooltipSize.y * tooltipRoot.pivot.y;

        float minX = -canvasSize.x / 2 + halfTooltipW;
        float maxX =  canvasSize.x / 2 - halfTooltipW;

        float minY = -canvasSize.y / 2 + halfTooltipH;
        float maxY =  canvasSize.y / 2 - halfTooltipH;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        return pos;
    }

    public void HideTooltip()
    {
        tooltipRoot.gameObject.SetActive(false);
    }
}
