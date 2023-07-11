using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;
using Main_Menu;
using UnityEngine;
using UnityEngine.UI;
public partial class ViewController
{
    /*
    [SerializeField]
    private Transform toggleParent;

    [SerializeField]
    private GameObject toggle;

    [SerializeField]
    private GameObject layerImage;

    [SerializeField]
    private Transform layerParent;

    [SerializeField]
    private GameObject baseLayer;

    [SerializeField]
    private RectTransform sliderPanel;
    
    [SerializeField]
    private Button sliderButton;

    [SerializeField]
    private Sprite sliderBtnL;
     
    [SerializeField]
    private Sprite sliderBtnR;
    
    private Sprite[] bases; // Масив, де зберігаються всі спайти з теки bases поточної дівульки
    private List<String> activeLayers;
    private List<Image> layers = new List<Image>(); // В цей ліст записуються всі відкриті шари
    private HentaiGirl currGirl; // Індекс поточної дівульки
    private bool sliderMoved; // Чи панель задвинулась за кадр

    private void SetUpLayers()
    {
        currGirl = MainMenu.gems[MainMenu.levelInfo[1]];
        activeLayers = new List<string>(currGirl.GetLayers());
        string girlPath = currGirl.GetPath();
        bases = Resources.LoadAll<Sprite>(girlPath + "/bases");
        // Перевірка на те, чи є збережені слої
        if (activeLayers.Any())
        {
            ChangeBase();
            // Якщо не один з леєрів не включений то у activeLayers записується строка з пробілом.
            // Це не як не впливає на функціонал, але ця строка вже не потрібна після сетапу, тому
            // видаляємо її.
            activeLayers.Remove(" ");
        }
        else
        {
            // Потрібно якимось чином визначити яка база має в собі всі слої. У цієї бази буде найдовше ім'я
            // Код далі знаходить цю базу та кладе її індекс у longestBaseIndex.
            int longestNameLength = 0;
            int longestBaseIndex = 0;
            for (int i = 0; i < bases.Length; i++)
            {
                int currLength = bases[longestBaseIndex].name.Length;

                if (currLength > longestNameLength)
                {
                    longestNameLength = currLength;
                    longestBaseIndex = i;
                }
            }

            // Тепер змінюємо базовий спрайт.
            baseLayer.GetComponent<Image>().sprite = bases[longestBaseIndex];
        }

        int totalLevels = currGirl.GetTotalLevels();
        // Тепер ініціалізуємо тогли та леєри
        for (int i = totalLevels; i > 0; i--)
        {
            // тут всі лейери, що відкриваються за кокретний рівень i
            Sprite[] spritesForLevel = Resources.LoadAll<Sprite>($"{girlPath}/layers/lvl{i}");

            bool layerUnlocked = currGirl.GetCompletedLevels() >= i;
            foreach (Sprite levelSprite in spritesForLevel)
            {
                // Ініалізуємо лейер 
                GameObject img = Instantiate(layerImage, layerParent, false);
                img.GetComponent<Image>().sprite = levelSprite;
                // Якщо не додати це, то ця лейер перекриває всі кнопки і не можливо їх натиснути
                img.transform.SetSiblingIndex(totalLevels - i + 1);
                img.name = levelSprite.name + "img";
                // Ініціалізуємо окремий матеріал для слою
                img.GetComponent<Image>().material = Instantiate(img.GetComponent<Image>().material);
                // Якщо цей лейер відкритий, додаємо його до лісту layers
                if (layerUnlocked)
                {
                    layers.Add(img.GetComponent<Image>());
                    // Якщо лейер не є активним ставимо галочку та робимо його прозорим
                    if (!activeLayers.Contains(img.name))
                    {
                        GameObject.Find(levelSprite.name[0].ToString()).GetComponent<Toggle>().isOn = false;
                        img.GetComponent<Image>().material.SetFloat("_Fade", 0f);
                    }
                }
            }
        }
        // тут ми видаляємо ті тогли, відповідні леєери яких не використовуються
        foreach (Transform child in toggleParent)
        {
            bool isToggleValid = false;
            foreach (Image layer in layers)
            {
                if (child.name == layer.name[0].ToString())
                {
                    child.name = layer.name;
                    isToggleValid = true;
                    break;
                }
            }

            if (!isToggleValid)
            {
                Destroy(child.gameObject);
            }
        }
    }
    */
}