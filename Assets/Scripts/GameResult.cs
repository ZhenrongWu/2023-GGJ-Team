using DG.Tweening;
using GGJ;
using GGJ.Characters;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameResult : MonoBehaviour
{
    [SerializeField] private Sprite     puddleResultSprite;
    [SerializeField] private Sprite     moundResultSprite;
    [SerializeField] private Sprite     dieResultSprite;
    [SerializeField] private GameObject restartButton;

    [SerializeField] private AudioClip puddleSE;
    [SerializeField] private AudioClip moundSE;
    [SerializeField] private AudioClip dieSE;

    private Image     _resultImage;
    private Character _character;
    private bool isResult;

    private void Start()
    {
        _resultImage = GameObject.Find("ResultImage").GetComponent<Image>();
        _character   = FindObjectOfType<Character>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (isResult)
            return;

        if (col.transform.name == "Puddle(Clone)")
        {
            SoundManager.Instance?.PlayBGM(puddleSE, false);
            SetResultImage(puddleResultSprite);
            isResult = true;
        }
        else if (col.transform.name == "Mound(Clone)")
        {
            SoundManager.Instance?.PlayBGM(moundSE, false);
            SetResultImage(moundResultSprite);
            isResult = true;
        }
        else if (col.transform.name == "DieArea")
        {
            SoundManager.Instance?.PlayBGM(dieSE, false);
            SetResultImage(dieResultSprite);
            isResult = true;
        }
    }

    private void SetResultImage(Sprite sprite)
    {
        _character.SetSpeed(0);

        _resultImage.sprite = sprite;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_resultImage.DOFade(1, 3))
            .SetDelay(1f)
            .OnComplete(() => restartButton.SetActive(true))
            .SetLink(_resultImage.gameObject);
    }
}