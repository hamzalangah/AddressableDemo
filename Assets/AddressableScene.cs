using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

public class AddressableScene : MonoBehaviour
{
    [SerializeField] private AssetReference addressableScenename;
    [SerializeField] AsyncOperationHandle<SceneInstance> handle;
    // Start is called before the first frame update
    void Start()
    {
        LoadAddressableScene(addressableScenename);
    }
    public async void LoadAddressableScene(AssetReference sceneName)
    {
        handle = Addressables.LoadSceneAsync(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
        await handle.Task;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
