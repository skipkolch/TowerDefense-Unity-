using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   [SerializeField] private Text _roundsText;
   [SerializeField] private Text _gameOverText;
   [SerializeField] private CanvasGroup _panelCanvasGroup;

   private void OnEnable()
   {
      _roundsText.text = PlayerStats.Rounds.ToString();

      _gameOverText.DOText("GAME OVER", 1f);
      _panelCanvasGroup.DOFade(1, .5f);

   }


   public void Retry()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

   public void Menu()
   {
      Debug.Log("Go to menu.");
   }
}
