using CodeMonkey.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WindowsQuestPointer : MonoBehaviour
    {
        [SerializeField] private Transform targetTrans;
        [SerializeField] private Camera    playerCamera;
        [SerializeField] private Sprite    arrowSprite;

        private RectTransform _pointerRectTrans;
        private Image         _pointerImage;

        private void Awake()
        {
            _pointerRectTrans = transform.Find("Pointer").GetComponent<RectTransform>();
            _pointerImage     = transform.Find("Pointer").GetComponent<Image>();
        }

        private void Update()
        {
            var     targetTransPos = targetTrans.position;
            Vector3 toPos          = targetTransPos;
            Vector3 fromPos        = Camera.main!.transform.position;
            fromPos.z = 0;
            Vector3 dir   = (toPos - fromPos).normalized;
            float   angle = UtilsClass.GetAngleFromVector(dir);
            _pointerRectTrans.localEulerAngles = new Vector3(0, 0, angle);

            float   borderSize           = 50;
            Vector3 targetPosScreenPoint = Camera.main!.WorldToScreenPoint(targetTransPos);
            bool isOffScreen = targetPosScreenPoint.x              <= borderSize   ||
                               targetPosScreenPoint.x - borderSize >= Screen.width ||
                               targetPosScreenPoint.y              <= borderSize   ||
                               targetPosScreenPoint.y - borderSize >= Screen.height;

            if (isOffScreen)
            {
                _pointerImage.sprite = arrowSprite;
                Vector3 cappedTargetScreenPos = targetPosScreenPoint;
                if (cappedTargetScreenPos.x <= borderSize)
                    cappedTargetScreenPos.x = borderSize;
                if (cappedTargetScreenPos.x >= Screen.width - borderSize)
                    cappedTargetScreenPos.x = Screen.width - borderSize;
                if (cappedTargetScreenPos.y <= borderSize)
                    cappedTargetScreenPos.y = borderSize;
                if (cappedTargetScreenPos.y >= Screen.height - borderSize)
                    cappedTargetScreenPos.y = Screen.height - borderSize;

                Vector3 pointerWorldPos = playerCamera.ScreenToWorldPoint(cappedTargetScreenPos);
                _pointerRectTrans.position = pointerWorldPos;
                var pointerRectLocalPos = _pointerRectTrans.localPosition;
                pointerRectLocalPos             = new Vector3(pointerRectLocalPos.x, pointerRectLocalPos.y, 0);
                _pointerRectTrans.localPosition = pointerRectLocalPos;
            }
            else
            {
                Vector3 pointerWorldPos = playerCamera.ScreenToWorldPoint(targetPosScreenPoint);
                _pointerRectTrans.position = pointerWorldPos;
                var pointerRectLocalPos = _pointerRectTrans.localPosition;
                pointerRectLocalPos             = new Vector3(pointerRectLocalPos.x, pointerRectLocalPos.y, 0);
                _pointerRectTrans.localPosition = pointerRectLocalPos;
            }
        }
    }
}