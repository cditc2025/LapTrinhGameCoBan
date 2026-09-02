using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler( transform.rotation.eulerAngles + Vector3.up * 180f * Time.deltaTime );
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController.instance.UpdateCollect();
        gameObject.SetActive(false);
    }
}
