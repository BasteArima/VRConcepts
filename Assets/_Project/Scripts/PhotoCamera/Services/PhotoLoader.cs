using UnityEngine;

namespace PhotoCamera.Behaviors
{
    public class PhotoLoader
    {
        public Sprite GetPhotoSprite(string filePath)
        {
            var texture = LoadTextureFromFile(filePath);
            var sprite = SpriteFromTexture(texture);
            return sprite;
        }

        private Texture2D LoadTextureFromFile(string filePath)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(filePath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(bytes);
            return texture;
        }

        private Sprite SpriteFromTexture(Texture2D texture)
        {
            Rect rect = new Rect(0, 0, texture.width, texture.height);
            Sprite sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
            return sprite;
        }
    }
}