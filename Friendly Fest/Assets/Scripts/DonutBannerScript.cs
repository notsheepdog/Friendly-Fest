using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutBannerScript : MonoBehaviour
{
    public Level1 lv1;
    public GameObject banner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        banner.SetActive(lv1.paperSigned);
    }
}
