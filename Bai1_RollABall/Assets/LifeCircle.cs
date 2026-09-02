using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCircle : MonoBehaviour
{
    private void Awake(){    Debug.Log("Awake"); }

    private void OnEnable() { Debug.Log("OnEnable"); }

    // Start is called before the first frame update
    void Start() {  Debug.Log("Start"); }

    float fixUpdateTime = 0;

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate " + (Time.time - fixUpdateTime));
        fixUpdateTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log("Update " + Time.deltaTime);
    }

    private void LateUpdate()
    {
        //Debug.Log("LateUpdate " + Time.deltaTime);
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy");    
    }
}
