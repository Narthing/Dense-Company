using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //tablet and war scroll positions
    // equipped - X: -5.2889, Y: -0.83
    // unequipped - X: -12.65, Y: -0.83
    public float pickaxedmg = 1;

    public float moneytotal = 0;
    public TMP_Text moneytext;

    public Transform clipboard;

    public bool dirtfound;
    public bool stonefound;
    public bool copperfound;
    public bool coalfound;
    public bool ironfound;
    public bool silverfound;
    public bool quartzfound;
    public bool goldfound;

    public bool clipboardup;
    private void Start()
    {

        moneytotal = 0;
    }

    private void Update()
    {
        if (clipboardup)
        {
            pickaxedmg = 0;
        }
        if (!clipboardup)
        {
            pickaxedmg = 1;
        }

        moneytext.text = moneytotal.ToString();
    }

    
}
