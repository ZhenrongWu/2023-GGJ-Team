using DG.Tweening;
using GGJ.Characters;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour
{
    [SerializeField] private Sprite puddleResultSprite;
    [SerializeField] private Sprite moundResultSprite;
    [SerializeField] private Sprite dieResultSprite;

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
        _character.enabled = false;

        _resultImage.sprite = sprite;
        _resultImage.DOFade(1, 3);
    }
}