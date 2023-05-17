using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Itens", menuName = "Novo Item", order = 0)]
public class Itens : ScriptableObject
{
    public string NomeItem;
    public int valorItem;
    public bool presente;
}
