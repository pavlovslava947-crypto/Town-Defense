using System.Collections;
using UnityEngine;

public class WheatCollect : MonoBehaviour
{
    [SerializeField] private int _wheatProduction = 1;
    private Animator _peasantAnim;

    public int WheatProduction => _wheatProduction;

    void Start()
    {
        _peasantAnim = GetComponent<Animator>();
    }
}
