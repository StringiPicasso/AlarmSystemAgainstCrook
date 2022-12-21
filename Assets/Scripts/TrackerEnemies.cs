using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerEnemies : MonoBehaviour
{
    [SerializeField] private HomeSignalization _signalization;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _signalization.TurnOnAlarm();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _signalization.TurnOffAlarm();
    }
}

