using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BaseUITab : MonoBehaviour
{
    public string TabName;

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
    
}
