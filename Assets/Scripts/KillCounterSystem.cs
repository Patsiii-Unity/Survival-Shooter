using TMPro;
using UnityEngine;

public class KillCounterSystem : MonoBehaviour
{
    //Variablendefinition
    public TextMeshProUGUI killCounterText;

    public int killCounter = 0;

    //killCounter erhöhen
    public void IncreaseKillCounter()
    {
        killCounter = killCounter + 1;

        killCounterText.text = killCounter.ToString();
    }
}
