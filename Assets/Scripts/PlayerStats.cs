using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerStats : MonoBehaviour
{
   [SerializeField] private int _startMoney = 400;
   [SerializeField] private int _startLives = 15;
   
        
  [HideInInspector] public static int Money;
  [HideInInspector] public static int Lives;
  [HideInInspector] public static int Rounds;

   private void Start()
   {
      Money = _startMoney;
      Lives = _startLives;

      Rounds = 0;
      
   }
}
