using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] TMP_Text finalCoinsDisplay;

    void Start()
    {
        finalCoinsDisplay.text = "COINS COLLECTED: " + MasterInfo.coinCount;
    }
}
