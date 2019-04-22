using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private Text _moneyText;


    // Update is called once per frame
    private void Update()
    {
        _moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
