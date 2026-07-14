using UnityEngine;

public class CloseButton : UIButton
{
    [SerializeField] private UIWindow _window;

    protected override void OnClick()
    {
        base.OnClick();
        _window.gameObject.SetActive(false);
    }
}
