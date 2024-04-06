using NaughtyAttributes;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

[ExecuteInEditMode]
public class AnimationFrameToDefaultTransform : MonoBehaviour
{
    [SerializeField] private AnimationClip _animationClip;
    [SerializeField] private int _frame;

    [Button()]
    public void ApplyPose()
    {
        if (_animationClip == null)
        {
            Debug.LogError("Animation clip is not assigned");
            return;
        }

        EditorCurveBinding[] bindings = AnimationUtility.GetCurveBindings(_animationClip);

        foreach (var binding in bindings)
        {
            string path = binding.path;
            string propertyName = binding.propertyName;
            GameObject target = FindChildByPath(transform, path);

            if (target != null)
            {
                AnimationCurve curve = AnimationUtility.GetEditorCurve(_animationClip, binding);
                Keyframe[] keyframes = curve.keys;
                if (keyframes.Length > 1)
                {
                    Keyframe secondKeyframe = keyframes[_frame];
                    float value = secondKeyframe.value;
                    ApplyPropertyToTransform(target.transform, propertyName, value);
                }
            }
        }
    }

    private GameObject FindChildByPath(Transform parent, string path)
    {
        Transform target = parent.Find(path);
        return target != null ? target.gameObject : null;
    }

    private void ApplyPropertyToTransform(Transform target, string propertyName, float value)
    {
        switch (propertyName)
        {
            case "m_LocalPosition.x":
                target.localPosition = new Vector3(value, target.localPosition.y, target.localPosition.z);
                break;
            case "m_LocalPosition.y":
                target.localPosition = new Vector3(target.localPosition.x, value, target.localPosition.z);
                break;
            case "m_LocalPosition.z":
                target.localPosition = new Vector3(target.localPosition.x, target.localPosition.y, value);
                break;
            case "m_LocalRotation.x":
                Quaternion currentRotation = target.localRotation;
                target.localRotation = new Quaternion(value, currentRotation.y, currentRotation.z, currentRotation.w);
                break;
            case "m_LocalRotation.y":
                currentRotation = target.localRotation;
                target.localRotation = new Quaternion(currentRotation.x, value, currentRotation.z, currentRotation.w);
                break;
            case "m_LocalRotation.z":
                currentRotation = target.localRotation;
                target.localRotation = new Quaternion(currentRotation.x, currentRotation.y, value, currentRotation.w);
                break;
            case "m_LocalRotation.w":
                currentRotation = target.localRotation;
                target.localRotation = new Quaternion(currentRotation.x, currentRotation.y, currentRotation.z, value);
                break;
            case "m_LocalScale.x":
                target.localScale = new Vector3(value, target.localScale.y, target.localScale.z);
                break;
            case "m_LocalScale.y":
                target.localScale = new Vector3(target.localScale.x, value, target.localScale.z);
                break;
            case "m_LocalScale.z":
                target.localScale = new Vector3(target.localScale.x, target.localScale.y, value);
                break;
            default:
                Debug.LogWarning($"Unsupported property: {propertyName}");
                break;
        }
    }
}
#endif
