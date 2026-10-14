using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Caro : MonoBehaviour
{
    public Button caroBtn;
    public TMP_Text valueText;
    public int currentValue = -1;

    private void Awake()
    {
        caroBtn = GetComponent<Button>();
        //
        caroBtn.onClick.AddListener(delegate
        {
            if (currentValue != 0) return;
            Fill(1);
            //
            GameManager.instance.HandleBoard(1);
        });
    }

    public void Fill(int value)
    {
        this.currentValue = value;
        switch(value)
        {
            case 1:
                valueText.text = "X";
                break;
            case 2:
                valueText.text = "O";
                break;

            default:
                valueText.text = "";
                break;
        }    
    }    
}
