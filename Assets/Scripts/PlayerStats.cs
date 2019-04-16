using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
   [SerializeField] private int _startMoney = 400;
   [SerializeField] private int _startLives = 15;
   
        
  [HideInInspector] public static int Money;
  [HideInInspector] public static int Lives;

   private void Start()
   {
      Money = _startMoney;
      Lives = _startLives;
   }
}
