using System;
using UnityEngine;

public static class Events
{
    public static Action<string, string, Vector2> OnTooltipShow;
    public static Action OnTooltipHide;
}