using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelselection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void playgame()
    {
        SceneManager.LoadScene("gameplay");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
