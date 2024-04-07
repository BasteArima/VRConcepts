using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace PhotoCamera.Behaviors
{
    public class CanvasPhotoViewer : MonoBehaviour
    {
        [SerializeField] private GalleryPhoto _photoPrefab;
        [SerializeField] private Transform _photosParent;

        [SerializeField] private Image _bigPhotoView;
        [SerializeField] private Button _closeBigPhotoViewButton;

        [Header("Controllers")]
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _nextButton;
        [SerializeField] private Button _deleteButton;

        private List<Sprite> _addedSprite;
        private int _currentPageIndex;
        private PhotoLoader _photoLoader;

        private void Awake()
        {
            _photoLoader = new PhotoLoader();
            _addedSprite = new List<Sprite>();
            SetSubscribers();
            OnCloseBitPhotoViewButton();
        }

        private void Start()
        {
            var photosFolderPath = Path.Combine(Application.persistentDataPath, GameConstants.PHOTO_PHOLDERS_NAME);
            LoadAllPhotos(photosFolderPath);
        }

        private void SetSubscribers()
        {
            _closeBigPhotoViewButton.onClick.AddListener(OnCloseBitPhotoViewButton);
            _backButton.onClick.AddListener(OnBackButton);
            _nextButton.onClick.AddListener(OnNextButton);
            _deleteButton.onClick.AddListener(OnDeleteButton);
        }

        private void LoadAllPhotos(string folderPath)
        {
            string[] fileNames = Directory.GetFiles(folderPath);
            foreach (var filePath in fileNames)
            {
                if (Path.GetExtension(filePath).Equals(".png", StringComparison.OrdinalIgnoreCase))
                    AddPhoto(filePath);
            }
        }

        private void OpenBigPhoto(int id)
        {
            SetPage(id);
            _photosParent.gameObject.SetActive(false);
            _bigPhotoView.gameObject.SetActive(true);
        }

        private void SetPage(int pageIndex)
        {
            _bigPhotoView.sprite = _addedSprite[pageIndex];
            CheckButtonStatuses(pageIndex);
        }

        private void CheckButtonStatuses(int pageIndex)
        {
            if (pageIndex == 0)
            {
                _backButton.gameObject.SetActive(false);
                _nextButton.gameObject.SetActive(true);
            }
            else if (pageIndex >= _addedSprite.Count - 1)
            {
                _backButton.gameObject.SetActive(true);
                _nextButton.gameObject.SetActive(false);
            }
            else
            {
                _backButton.gameObject.SetActive(true);
                _nextButton.gameObject.SetActive(true);
            }
        }

        private void OnBackButton()
        {
            _currentPageIndex--;
            SetPage(_currentPageIndex);
        }

        private void OnNextButton()
        {
            if (_currentPageIndex >= _addedSprite.Count - 1) return;
            _currentPageIndex++;
            SetPage(_currentPageIndex);
        }

        private void OnDeleteButton()
        {
        }

        private void OnCloseBitPhotoViewButton()
        {
            _bigPhotoView.gameObject.SetActive(false);
            _photosParent.gameObject.SetActive(true);
        }

        public void AddPhoto(string filePath)
        {
            var photo = Instantiate(_photoPrefab, _photosParent);
            var photoSprite = _photoLoader.GetPhotoSprite(filePath);
            _addedSprite.Add(photoSprite);
            photo.Id = _addedSprite.IndexOf(photoSprite);
            photo.FilePath = filePath;
            photo.GetComponent<Image>().sprite = photoSprite;
            photo.GetComponent<Button>().onClick.AddListener(() => OpenBigPhoto(photo.Id));
        }
    }
}