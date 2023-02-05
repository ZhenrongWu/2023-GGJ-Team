using DG.Tweening;
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

    private Image     _resultImage;
    private Character _character;

    private void Start()
    {
        _resultImage = GameObject.Find("ResultImage").GetComponent<Image>();
        _character   = FindObjectOfType<Character>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.name == "Puddle(Clone)")
        {
            SetResultImage(puddleResultSprite);
        }
        else if (col.transform.name == "Mound(Clone)")
        {
            SetResultImage(moundResultSprite);
        }
        else if (col.transform.name == "DieArea")
        {
            SetResultImage(dieResultSprite);
        }
    }

    private void SetResultImage(Sprite sprite)
    {
        _character.SetSpeed(0);

        _resultImage.sprite = sprite;
        _resultImage.DOFade(1, 3).OnComplete(() => restartButton.SetActive(true));
    }
}