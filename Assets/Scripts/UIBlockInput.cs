using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBlockInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        transform.SetAsLastSibling();
    }

    public void OnClickHide()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
