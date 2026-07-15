using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HighlightObject : MonoBehaviour
{
    [SerializeField] private Material _outlineMaterial; 
 
    private Image _image;
    private Material _defaultMaterial;
    private bool _isHighlighted = false;

    protected virtual void Awake()
    {
        _isHighlighted = false;
        _image = GetComponent<Image>();
        _defaultMaterial = _image.material;
    }

    public void Highlight()
    {
        if (_isHighlighted)
            return;

        _image.material = _outlineMaterial;
        _isHighlighted = true;
    }

    public void Dehighlight()
    {
        if (_isHighlighted == false) 
            return;

        _image.material = _defaultMaterial;
        _isHighlighted = false;
    }

    public float GetOutlineWidth()
    {
        return _image.material.GetFloat("_OutlineWidth"); 
    }

    public void SetOutlineWidth(float width)
    {
        _image.material.SetFloat("_OutlineWidth", width);
    }
}