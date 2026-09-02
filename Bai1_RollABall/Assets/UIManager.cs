using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TMP_Text scoreTxt;
    public Transform value;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void UpdateResult(int current, int target)
    {
        scoreTxt.text = $"{current}/{target}";
        //

        value.localScale = new Vector3((float)current/target, 1, 1);
    }    
}
