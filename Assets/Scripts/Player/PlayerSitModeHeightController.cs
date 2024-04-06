using Autohand;
using UnityEngine;

public class PlayerSitModeHeightController : MonoBehaviour
{
    [SerializeField] private AutoHandPlayer _autoHandPlayer;
    [SerializeField] private float _sittingHeightOffset;
    
    private void Start()
    {
        _autoHandPlayer.heightOffset = BuildSettings.Instance.PlayerSittingMode ? _sittingHeightOffset : 0;
    }
}
