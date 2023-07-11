using Coffee.UIEffects;
using DG.Tweening;
using Global;
using Main_Menu;
using UnityEngine;
using UnityEngine.UI;

public class GalleryController : MonoBehaviour
{
    /*
    [SerializeField]
    private RectTransform panelParent;

    [SerializeField]
    private float animationSpeed = 0.6f;

    private int _panelIndex;

    private void Awake()
    {
        _panelIndex = PlayerPrefs.GetInt("GalleryIndex");
        panelParent.anchoredPosition = new Vector2(0, 1080 * _panelIndex);
        int k = 0; // цей лічільниу рахує індекс дівульки в масиві hentaiGirls;
        // це цикл по панелям. Кожна панель - 1 сезон, тобто 3 дівульки.
        for (int i = 0; i < panelParent.childCount; i++)
        {
            // це цикл по дівулькам.
            for (int j = 0; j < 3; j++)
            {
                if (!(MainMenuController.Gems[k].LevelsCompleted > 0))
                {
                    Button previewButton = panelParent.GetChild(i).GetChild(0).GetChild(j).GetComponent<Button>();
                    previewButton.interactable = false;
                    UIEffect effect = previewButton.GetComponent<UIEffect>();
                    effect.effectFactor = 1;
                    effect.blurFactor = 1;
                    previewButton.transform.GetChild(1).GetComponent<Image>().color = Color.white;
                }

                k++;
            }
        }
    }

    // Ця функція двигає велику панель в залежності від індексу
    private void Move()
    {
        panelParent.DOAnchorPos(new Vector2(0, 1080 * _panelIndex), animationSpeed);
        PlayerPrefs.SetInt("GalleryIndex", _panelIndex);
    }

    public void Up()
    {
        if (_panelIndex != 0)
        {
            _panelIndex--;
            Move();
        }
        else
        {
            RectTransform firstPanel = panelParent.GetChild(0).GetComponent<RectTransform>();
            firstPanel.DOShakePosition(0.4f, new Vector3(6, 15, 6), 14)
                .SetEase(Ease.OutQuart).OnComplete(() =>
                {
                    // Якщо не додати це, то панель трохи збивається коли швидко дрочити кнопку.
                    firstPanel.offsetMin = new Vector2(-910, -490);
                    firstPanel.offsetMax = new Vector2(910, 490);
                });
        }
    }

    public void Down()
    {
        if (_panelIndex != 3)
        {
            _panelIndex++;
            Move();
        }
        else
        {
            RectTransform lastPanel = panelParent.GetChild(3).GetComponent<RectTransform>();
            lastPanel.DOShakePosition(0.4f, new Vector3(6, 15, 6), 14).SetEase(Ease.InQuart)
                .OnComplete(() =>
                {
                    // Якщо не додати це, то панель трохи збивається якщо швидко дрочити кнопку.
                    lastPanel.offsetMin = new Vector2(-910, -3730);
                    lastPanel.offsetMax = new Vector2(910, -2750);
                });
        }
    }

    public void ChoosePreview(int girlIndex)
    {
        SceneController.Instance.LoadScene(GameScene.View);
    }
    */
}