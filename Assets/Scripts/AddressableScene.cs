using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

public class AddressableScene : MonoBehaviour
{
    [SerializeField] private AssetReference addressableSceneName; // Scene reference
    [SerializeField] private AssetReference addressableTexture;   // Texture reference

    private AsyncOperationHandle<SceneInstance> sceneHandle;
    private AsyncOperationHandle<Texture> textureHandle;

    void Start()
    {
        // Load the scene
        LoadAddressableScene(addressableSceneName);

        // Load the texture
        LoadAddressableTexture(addressableTexture);
    }

    // Method to load the scene
    public async void LoadAddressableScene(AssetReference sceneReference)
    {
        if (sceneReference.RuntimeKeyIsValid())
        {
            sceneHandle = Addressables.LoadSceneAsync(sceneReference, UnityEngine.SceneManagement.LoadSceneMode.Single);
            await sceneHandle.Task;
            if (sceneHandle.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log("Scene loaded successfully.");
            }
            else
            {
                Debug.LogError("Failed to load the scene.");
            }
        }
        else
        {
            Debug.LogError("Invalid scene reference.");
        }
    }

    // Method to load the texture
    public async void LoadAddressableTexture(AssetReference textureReference)
    {
        if (textureReference.RuntimeKeyIsValid())
        {
            textureHandle = Addressables.LoadAssetAsync<Texture>(textureReference);
            await textureHandle.Task;
            if (textureHandle.Status == AsyncOperationStatus.Succeeded)
            {
                Texture loadedTexture = textureHandle.Result;
                Debug.Log("Texture loaded successfully.");
                // Optionally, apply the texture to a material
                ApplyTextureToMaterial(loadedTexture);
            }
            else
            {
                Debug.LogError("Failed to load the texture.");
            }
        }
        else
        {
            Debug.LogError("Invalid texture reference.");
        }
    }

    // Optional: Apply the loaded texture to a material
    private void ApplyTextureToMaterial(Texture texture)
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null && renderer.material != null)
        {
            renderer.material.mainTexture = texture;
        }
        else
        {
            Debug.LogWarning("No Renderer or Material found on the GameObject.");
        }
    }

    void OnDestroy()
    {
        // Release assets when the GameObject is destroyed
        if (sceneHandle.IsValid())
        {
            Addressables.UnloadSceneAsync(sceneHandle);
        }
        if (textureHandle.IsValid())
        {
            Addressables.Release(textureHandle);
        }
    }
}
