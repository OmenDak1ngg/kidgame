using UnityEngine;
using UnityEngine.UI;

public class OutlineChanger : MonoBehaviour
{
    [SerializeField] private UIToggle _toggle;
    [SerializeField] private Clothing[] _clothings;
    
    [SerializeField] private Material _outlineMaterial;

    private void OnEnable()
    {
        _toggle.Changed += Change;
    }

    private void OnDisable()
    {
        _toggle.Changed -= Change;
    }

    private void Change(bool value)
    {
        if (value)
        {
            foreach(Clothing clothing in _clothings)
            {
                clothing.GetComponent<Image>().material = _outlineMaterial;
            }
        }
        else
        {
            foreach (Clothing clothing in _clothings)
            {
                clothing.GetComponent<Image>().material = null;
            }
        }

        SaveSystem.SaveOutlineEnabled(value ? 1 : 0);
    }
}
