using UnityEngine;
using System;

public static class GameVariables
{
    // for death
    public static bool nextCardNegate = false;

    // for the fool
    public static bool addARound = false;

    // for the world
    public static bool endGame = false;

    public static bool requestSwap = false;
    public static int swapA = -1;
    public static int swapB = -1;

    public static void RequestSwap(int a, int b)
    {
        requestSwap = true;
        swapA = a;
        swapB = b;
    }

    public static void ClearSwap()
    {
        requestSwap = false;
        swapA = -1;
        swapB = -1;
    }
}