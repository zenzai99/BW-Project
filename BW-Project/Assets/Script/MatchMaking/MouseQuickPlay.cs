﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseQuickPlay : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{

    private AudioSource audioSource;
    public AudioClip button;

    private Image myImageComponent;
    public Sprite imageColor;
    public Sprite imageBW;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        myImageComponent = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        if (gameObject.name == GameData.instance.characterPlayerName)
        {
            ExtendedScale(gameObject);
            //gameObject.GetComponent<Outline>().enabled = true;
        }
        else
        {
            ReduceScale(gameObject);
            //gameObject.GetComponent<Outline>().enabled = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ExtendedScale(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ReduceScale(gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.PlayOneShot(button);
        Debug.Log("Select " + gameObject.name);
        GameData.instance.characterPlayerName = gameObject.name;
        CameraControl.instance.MoveToShowRoom();

    }

    private void ExtendedScale(GameObject image)
    {
        if (image.transform.localScale.x != 0.6f && image.transform.localScale.y != 0.6f)
        {
            myImageComponent.sprite = imageColor;
            image.transform.localScale = new Vector3(0.6f, 0.6f);
        }
    }

    private void ReduceScale(GameObject image)
    {
        if (image.transform.localScale.x != 0.5f && image.transform.localScale.y != 0.5f)
        {
            myImageComponent.sprite = imageBW;
            image.transform.localScale = new Vector3(0.5f, 0.5f);
        }
    }


}
