using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakePhoto : MonoBehaviour
{
    public Camera myCamera;
    public RenderTexture myTexture;
    public RawImage myImage;
    public Canvas myCanvas;
    private bool _isTakePhoto;

    private bool _isTakingPhoto;
    // Start is called before the first frame update
    void Start()
    {
        myCamera.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            _isTakePhoto = true;
        }
    }

    private void FixedUpdate()
    {
        if (_isTakePhoto && !_isTakingPhoto)
        {
            StartCoroutine(StartTakePhoto());
        }
    }

    IEnumerator StartTakePhoto()
    {
        myCamera.gameObject.SetActive(true);
        _isTakingPhoto = true;
        yield return new WaitForSeconds(0.5f);
        var image = Instantiate(myImage,myCanvas.transform);
        image.texture = myTexture;
        myCamera.gameObject.SetActive(false);
        _isTakePhoto = false;
        _isTakingPhoto = false;
    }
    
}
