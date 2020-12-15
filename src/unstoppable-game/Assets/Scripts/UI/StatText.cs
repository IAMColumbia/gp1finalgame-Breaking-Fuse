using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatText : MonoBehaviour
{
    protected TMPro.TextMeshProUGUI statText;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        statText = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
}
