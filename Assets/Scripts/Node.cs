using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class Node : MonoBehaviour
{
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Color _notMoneyColor;
    [Header("Optional")] public GameObject _gun;
    [SerializeField] private Vector3 _positionOffset;

    private Renderer renderNode;
    private Color _defaultColor;

    private BuildManager _buildManager;
   

    private void Start()
    {
        renderNode = GetComponent<Renderer>();
        _defaultColor = renderNode.material.color;
        _buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        
        if(_buildManager.GetGunToBuild == null)
            return;
        
        if (_gun != null)
        {
           _buildManager.DestroyBuild(_gun);
            return;
        }
        
        _buildManager.BuildGunOn(this);
    }


    public Vector3 GetBuildPosition()
    {
        return transform.position + _positionOffset;
    }
    

    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        
        if(!_buildManager.CanBuild)
            return;

        if (_buildManager.HasMoney)
            renderNode.material.color = _hoverColor;
        else renderNode.material.color = _notMoneyColor;
    }

    private void OnMouseExit()
    {
        if(_buildManager.GetGunToBuild == null)
            return;
        
        renderNode.material.color = _defaultColor;
    }
}
