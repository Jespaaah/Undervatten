using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class UnderWaterEffect : MonoBehaviour
{
    public Material _mat;
    

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, _mat);
    }
}
