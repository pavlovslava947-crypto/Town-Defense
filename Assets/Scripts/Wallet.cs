
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private WheatUI _wheatUI;
    public int _peasantSpawnCost = 5;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSpawnPeasantButtonClick()
    {
        //_peasantSpawnCost += 3;

        _wheatUI.IsHasMoney();

        
    }
}
