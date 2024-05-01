using System;
using System.Collections.Generic;
using UnityEngine;

public class SkinPlacement : MonoBehaviour
{
    private const string RenderLayer = "SkinRenderer";

    [SerializeField] private Rotator _rotator;

    private GameObject _currentModel;

    public void IntantiateModel(GameObject model)
    {
        if(_currentModel != null)
        {
            Destroy(_currentModel.gameObject);
        }
        _rotator.ResetRotation();

        _currentModel = Instantiate(model, transform.position, Quaternion.Euler(0,200,0));

        GetRendererLayerMask();

    }
    private void GetRendererLayerMask()
    {
        Transform[] childrens = _currentModel.GetComponentsInChildren<Transform>();

        foreach (var item in childrens)
            item.gameObject.layer = LayerMask.NameToLayer(RenderLayer);
    }
}
