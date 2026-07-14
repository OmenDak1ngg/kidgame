
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem.gameObject.SetActive(false);
    }

    private void Highlight(IHiglightable obj)
    {
      //  _particleSystem.transform.position = obj.GetPosition();
        _particleSystem.gameObject.SetActive(true);
    }
}
