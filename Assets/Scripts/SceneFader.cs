using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    [SerializeField] private Image _image;   
    [Range(0f,10f)]
    [SerializeField] private float _time;

    private void Start()
    {
        _image.color = new Color(0f,0f,0f,1);
        _image.DOFade(0, _time).OnComplete(() => gameObject.SetActive(false));
    }
}
