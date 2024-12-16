using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class splash : MonoBehaviour
{

    void Start()
    {
    }

    public void gotomainmenu()
    {
        SceneManager.LoadScene("mainmenu");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
