using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RandomUnsplash : MonoBehaviour
{
    private static string _url = "https://picsum.photos/200";

    private Image _unsplash;

    private Coroutine _loadCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        _unsplash = GetComponent<Image>();
        LoadNewImage();
    }

    public void LoadNewImage()
    {
        Debug.Log("LOADING");
        if (_loadCoroutine == null)
            _loadCoroutine = StartCoroutine(LoadNewImageCoroutine());
    }

    private IEnumerator LoadNewImageCoroutine()
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(_url+"?" + Random.value))
        {
            yield return uwr.SendWebRequest();
            string savePath = string.Format("{0}/{1}", Application.persistentDataPath, "unsplash.png");      
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
                if (File.Exists(savePath))     {
                    var fileData = File.ReadAllBytes(savePath);
                    Texture2D texture  = new Texture2D(2, 2);
                    texture.LoadImage(fileData); //..this will auto-resize the texture dimensions.
                }
            }
            else
            {
                var texture = DownloadHandlerTexture.GetContent(uwr);
                _unsplash.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
                Debug.Log(savePath);
                System.IO.File.WriteAllText(savePath, uwr.downloadHandler.text);
            }

            _loadCoroutine = null;
        }
    }
    
}
