using System;
using System.Collections;
using System.Linq;
using DG.Tweening;
using Helpers;
using Main_Menu;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public partial class ViewController : MonoBehaviour
{
    /*
    public void Awake()
    {
        SetUpLayers();
        AddListeners();
    }

    private void ToggleHandler(bool toggled)
    {
        string layerToChange = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        Image layer = null;
        // Шукаємо лейер в масиві лейерс залежно від імені відповідного тоглу
        foreach (Image tempLayer in layers.Where(tempLayer => tempLayer.name == layerToChange))
        {
            layer = tempLayer;
            break;
        }

        if (toggled)
        {
            activeLayers.Add(layerToChange);
            StartCoroutine(FadeIn(layer));
        }
        else
        {
            activeLayers.Remove(layerToChange);
            StartCoroutine(FadeOut(layer));
        }

        activeLayers.Sort();
        //Спочатку забираємо той тогл, на який натиснув користувач
        //Перевіряємо чи цей тогл змінює базу
        if (layerToChange[layerToChange.Length - 1] == '+')
        {
            ChangeBase();
        }
    }

    private void AddListeners()
    {
        foreach (Transform t in toggleParent)
        {
            t.GetComponent<Toggle>().onValueChanged.AddListener(ToggleHandler);
        }
    }

    private void ChangeBase()
    {
        string baseName = "base_";
        foreach (string activeLayer in activeLayers)
        {
            if (activeLayer[activeLayer.Length - 1] == '+')
            {
                baseName += activeLayer;
            }
        }

        String basePath = $"Sprites/Girls/{MainMenu.levelInfo[1] + 1}/bases/{baseName}";
        baseLayer.GetComponent<Image>().sprite = Resources.Load<Sprite>(basePath);
    }

    private IEnumerator FadeOut(Image layer)
    {
        Material currMaterial = layer.material;
        for (float i = 1f; i >= 0f; i -= 0.03f)
        {
            currMaterial.SetFloat("_Fade", i);
            yield return new WaitForSeconds(.01f);
        }
    }

    private IEnumerator FadeIn(Image layer)
    {
        Material currMaterial = layer.material;
        for (float i = 0f; i <= 1f; i += 0.03f)
        {
            currMaterial.SetFloat("_Fade", i);
            yield return new WaitForSeconds(.01f);
        }
    }

    public void Back()
    {
        if (!activeLayers.Any())
        {
            activeLayers.Add(" ");
        }

        MainMenu.gems[MainMenu.levelInfo[1]].SetLayers(activeLayers);
        SaveSystem.SaveProgress(MainMenu.gems);
        SceneManager.LoadScene("Gallery");
    }

    public void MovePanel()
    {
        if (!sliderMoved)
        {
            sliderPanel.DOAnchorPosX(190, 0.5f).SetEase(Ease.OutSine);
            sliderButton.image.sprite = sliderBtnL;
        }
        else
        {
            sliderPanel.DOAnchorPosX(0,0.5f).SetEase(Ease.InSine);
            sliderButton.image.sprite = sliderBtnR;
        }
        sliderMoved = !sliderMoved; 
    }
    */
}