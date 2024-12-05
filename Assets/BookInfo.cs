using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookInfo : MonoBehaviour
{
    private string title;
    private string autor;
    private int numberOfPages;
    private int numberOfPagesReaded;
    private bool readed;

    [SerializeField] Image cover;

    [SerializeField] TMPro.TextMeshProUGUI titleText;

    UIbookInfo uiBookInfo;

    public void Start()
    {
        uiBookInfo = FindAnyObjectByType<UIbookInfo>();
    }

    public void UpdateBookInfo(string newTitle, string newAutor, int newNumberOfPages)
    {
        title = newTitle;
        autor = newAutor;
        numberOfPages = newNumberOfPages;
        titleText.text = newTitle;
    }

    public void Readed()
    {
        readed = true;
        SendInfo();
    }

    public void SetCover(Sprite newCover)
    {
        cover.sprite = newCover;
    }

    public void SendInfo()
    {
        uiBookInfo.setUIBookInfo(title, autor, numberOfPages, readed);
        uiBookInfo.SetActualBook(this.gameObject);
    }
}
