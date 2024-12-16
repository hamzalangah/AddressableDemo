using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class gameplay : MonoBehaviour
{
    public AssetReference assetReference;
    // Start is called before the first frame update
    void Start()
    {
        LoadAsset();
    }
    void LoadAsset()
    {
        // Asynchronously load the addressable asset
        AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(assetReference);
        handle.Completed += OnAssetLoaded;
    }

    void OnAssetLoaded(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(handle.Result);
        }
        else
        {
            Debug.LogError("Failed to load addressable asset");
        }
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


    // Start is called before the first frame update
   

