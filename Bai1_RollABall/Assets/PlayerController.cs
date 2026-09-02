using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public Rigidbody _rigidbody;
    public float moveSpd = 2f;
    int numberCollect = 0;
    int targetCollect = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        //
        DiamondController[] diamonds = FindObjectsOfType<DiamondController>();
        targetCollect = diamonds.Length;
        //
        UIManager.instance.UpdateResult(0, targetCollect);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        _rigidbody.velocity = new Vector3(horizontal * moveSpd, _rigidbody.velocity.y, moveSpd * 2);

    }

    public void UpdateCollect()
    {
        numberCollect++;
        Debug.Log(numberCollect);
        //
        UIManager.instance.UpdateResult(numberCollect, targetCollect);
    }
}
