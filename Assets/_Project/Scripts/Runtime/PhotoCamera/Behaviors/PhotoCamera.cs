using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using VRConcepts.Runtime.PhotoCamera.Services;

namespace VRConcepts.Runtime.PhotoCamera.Behaviors
{
    public class PhotoCamera : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _planeLight;
        [SerializeField] private float _planeLightDeactiveDuration;

        [SerializeField] private AudioClip _shootSound;
        [SerializeField] private float _shootVolume = 1f;

        [SerializeField] private ScreenshotCapturer screenshotCapturer;
        [SerializeField] private CanvasPhotoViewer _canvasPhotoViewer;

        [SerializeField] private MeshRenderer _planePicturePrefab;
        [SerializeField] private Transform _planePictureParent;
        
        private void Start()
        {
            _planeLight.gameObject.SetActive(false);
        }

        [Button("Shoot")]
        public void Shoot()
        {
            if (_shootSound)
                AudioSource.PlayClipAtPoint(_shootSound, transform.position, _shootVolume);

            screenshotCapturer.CaptureScreenshot();

            CreatePlanePicture(screenshotCapturer.LastScreenshotPath);
            _canvasPhotoViewer.AddPhoto(screenshotCapturer.LastScreenshotPath);
            
            StopAllCoroutines();
            StartCoroutine(LightPlaneShotCoroutine());
        }

        private IEnumerator LightPlaneShotCoroutine()
        {
            _planeLight.gameObject.SetActive(true);

            yield return new WaitForSeconds(_planeLightDeactiveDuration);
            _planeLight.gameObject.SetActive(false);
        }

        private void CreatePlanePicture(string filePath)
        {
            var picture = Instantiate(_planePicturePrefab, _planePictureParent);
            picture.material = PhotoMaterialSetter.GetPhotoMaterial(filePath);
        }
    }
}