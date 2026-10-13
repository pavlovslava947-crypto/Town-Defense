using TMPro;
using UnityEngine;
using System.Collections;

public class WheatCollect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _wheatText;
    public float _seconds = 15f;
    private Animator _peasantAnim;
    private int _wheatValue = 0;

   
    void Start()
    {
        _peasantAnim = GetComponent<Animator>();

        StartCoroutine(ScriptLooper());
    }

    

    private IEnumerator ScriptLooper()
    {
        while (true)
        {
            

            yield return new WaitForSeconds(_seconds);

            CollectWheat();
        }
    }

    // Update is called once per frame
   
    void CollectWheat()
    {
        _wheatValue += 1;
        _wheatText.text = _wheatValue.ToString();
        _peasantAnim.SetTrigger("PickUp");

        

    }

   
}
