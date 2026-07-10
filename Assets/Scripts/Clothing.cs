using System.Collections;
using UnityEngine;

[RequireComponent(typeof(DragDrop))]
public class Clothing : MonoBehaviour
{
    [SerializeField] private ClothingTypes _type;

    public ClothingTypes Type => _type;
}