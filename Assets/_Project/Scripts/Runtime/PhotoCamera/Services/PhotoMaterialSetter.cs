using UnityEngine;

namespace VRConcepts.Runtime.PhotoCamera.Services
{
    public static class PhotoMaterialSetter
    {
        public static Material GetPhotoMaterial(string filePath)
        {
            var texture = LoadTextureFromFile(filePath);
            var material = new Material(Shader.Find("Universal Render Pipeline/Lit"));
            material.mainTexture = texture;
            return material;
        }

        private static Texture2D LoadTextureFromFile(string filePath)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(filePath);
            var texture = new Texture2D(2, 2);
            texture.LoadImage(bytes);
            return texture;
        }
    }
}