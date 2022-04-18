using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.3f;

    private MeshRenderer meshRenderer;
    private static readonly int MainTex = Shader.PropertyToID("_MainTex");

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if(GameManager.Instance.IsGameRunning)
            Scroll();
    }

    private void Scroll()
    {
        Vector2 offset = meshRenderer.sharedMaterial.GetTextureOffset(MainTex);

        offset.y += Time.deltaTime * scrollSpeed;

        meshRenderer.sharedMaterial.SetTextureOffset(MainTex,offset);
    }
}//Class
