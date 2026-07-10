using System.Collections;
using UnityEngine;


public class Clothing : MonoBehaviour
{
    [SerializeField] private ClothingTypes _type;

    public ClothingTypes Type => _type;
}