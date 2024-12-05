using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIbookInfo : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI titleText;
    [SerializeField] TMPro.TextMeshProUGUI autorText;
    [SerializeField] TMPro.TextMeshProUGUI numberOfPagesText;

    [SerializeField] Image readedImg;

    [SerializeField] Sprite check;
    [SerializeField] Sprite cross;

    public GameObject actualBook;

    public void setUIBookInfo(string title, string autor, int numberOfPages, bool readed)
    {
        titleText.text = "Title: " + title;
        autorText.text = "Autor: " + autor;
        numberOfPagesText.text = "Nº of pages " + numberOfPages;

        
        if (readed)
        {
            readedImg.sprite = check;
        }else
        {
            readedImg.sprite = cross;
        }
    }

    public void readActualBook()
    {
        if (actualBook != null)
        {
            Debug.Log("a");
            BookInfo bookinfo = actualBook.GetComponent<BookInfo>();
            bookinfo.Readed();

            
        }
    }

    public void SetActualBook(GameObject actual)
    {
        actualBook = actual;
    }

    public void RemoveActualBook()
    {
        Destroy(actualBook);
    }
}
