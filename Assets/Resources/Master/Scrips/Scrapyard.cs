﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrapyard : MonoBehaviour
{
    public static List<ShowClickRes> scrapList = new List<ShowClickRes>(Variables.Poolsize);
    public static List<ShowClickRes> electronicList = new List<ShowClickRes>(Variables.Poolsize);
    public static List<ShowClickRes> plasticList = new List<ShowClickRes>(Variables.Poolsize);

    private Button button;
    public static Vector3 scrapyardPosition;

    public static Image clickImage;
    public static Text clickText;

    public static Image scrapDisplay;
    public static Image electronicsDisplay;
    public static Image plasticsDisplay;
    public static Text displayText;

    void Awake()
    {
        clickImage = Resources.Load<Image>("Prefabs/ClickImage");
        scrapDisplay = Resources.Load<Image>("Prefabs/ScrapImage");
        electronicsDisplay = Resources.Load<Image>("Prefabs/ElectronicsImage");
        plasticsDisplay = Resources.Load<Image>("Prefabs/PlasticsImage");
        clickText = Resources.Load<Text>("Prefabs/DisplayText");
    }

    private void Start()
    {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(Hauke.ScrapyardClick);
        scrapyardPosition = this.gameObject.transform.position;
    }

    public static void DisplayScrapClick()
    {

        ShowClickRes clickRes;
        if (scrapList.Count < scrapList.Capacity)
        {
            clickRes = new ShowClickRes(SortOfRes.scrap);
            scrapList.Add(clickRes);
        }
        else
        {
            foreach (ShowClickRes res in scrapList)
            {
                if (res.image.gameObject.activeSelf)
                {
                    continue;
                }
                else
                {
                    scrapList.Remove(res);
                    clickRes = res;
                    scrapList.Add(clickRes);
                    clickRes = ShowClickRes.SetValues(clickRes,scrapyardPosition);
                    clickRes.image.gameObject.SetActive(true);
                    clickRes.text.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }
    public static void DisplayElectronicClick()
    {

        ShowClickRes clickRes;
        if (electronicList.Count < electronicList.Capacity)
        {
            clickRes = new ShowClickRes(SortOfRes.electronic);
            electronicList.Add(clickRes);            
        }
        else
        {
            foreach (ShowClickRes res in electronicList)
            {
                if (res.image.gameObject.activeSelf)
                {
                    continue;
                }
                else
                {
                    electronicList.Remove(res);
                    clickRes = res;
                    electronicList.Add(clickRes);
                    clickRes = ShowClickRes.SetValues(clickRes,scrapyardPosition);
                    clickRes.image.gameObject.SetActive(true);
                    clickRes.text.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }
    public static void DisplayPlasticsClick()
    {

        ShowClickRes clickRes;
        if (plasticList.Count < plasticList.Capacity)
        {
            clickRes = new ShowClickRes(SortOfRes.plastic);
            plasticList.Add(clickRes);
        }
        else
        {
            foreach (ShowClickRes res in plasticList)
            {
                if (res.image.gameObject.activeSelf)
                {
                    continue;
                }
                else
                {
                    plasticList.Remove(res);
                    clickRes = res;
                    plasticList.Add(clickRes);
                    clickRes = ShowClickRes.SetValues(clickRes,scrapyardPosition);
                    clickRes.image.gameObject.SetActive(true);
                    clickRes.text.gameObject.SetActive(true);
                    break;
                }
            }
        }

}
    public static void BuyWorker()
    {
        if (Variables.playerMoney >= Variables.workerCost)
        {
            Variables.playerMoney = Variables.playerMoney - Variables.workerCost;
            Variables.scrapYardCollector++;
            Hauke.ScrapYardWorkerMultiplierCalculation();
        }
        if (Variables.playerMoney < Variables.workerCost)
        {
            Debug.Log("nicht genug moneten");
        }
    }
}
