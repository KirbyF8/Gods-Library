using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddBook : MonoBehaviour
{

    [SerializeField] GameObject AddBookPanel;

    [SerializeField] Sprite[] covers;
    [SerializeField] Image cover;

    [SerializeField] GameObject Canvas;

    private int numberOfCovers;
    private int actualCover = 0;

    [SerializeField] GameObject bookPrefab;

    private int numberOfBooks = 0;
    private int distanceBetweenBooks = 150;
    private int distanceFloor = -15;

    [SerializeField] TMP_InputField title;
    [SerializeField] TMP_InputField autor;
    [SerializeField] TMP_InputField numberOfPages;

    private GameObject[] books;

    private void Start()
    {
        numberOfCovers = covers.Length;
    }

    public void NextCover(bool right)
    {
        if (right)
        {
            actualCover++;
            if (actualCover >= numberOfCovers-1)
            {
                actualCover = 0;
            }
            cover.sprite = covers[actualCover];

        } else if (!right)
        {
            actualCover--;
            if (actualCover <= -1)
            {
                actualCover = numberOfCovers-1;
            }
            cover.sprite = covers[actualCover];
        }
    }

    public void OpenAddBook()
    {
   
        title.text = null;
        autor.text = null;
        numberOfPages.text = null;

        AddBookPanel.SetActive(true);
    }

    public void Cancel()
    {
        AddBookPanel.SetActive(false);
    }

    public void AddNewBook()
    {
       
        if (title.text == "" || autor.text == "" || numberOfPages.text == "")
        {
            return;
        }
 

        numberOfBooks++;
        GameObject newBook = Instantiate(bookPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        
        
        newBook.name = title.text;
        newBook.transform.SetParent(Canvas.transform);

        newBook.transform.position = new Vector3((numberOfBooks * distanceBetweenBooks), 0, 0);
        newBook.transform.localPosition = new Vector3(newBook.transform.localPosition.x, distanceFloor, 0);
        

        BookInfo bookinfo;
        bookinfo = newBook.GetComponent<BookInfo>();
        int.TryParse(numberOfPages.text, out int number);

        bookinfo.UpdateBookInfo(title.text, autor.text, number);
        bookinfo.SetCover(covers[actualCover]);

        Cancel();
    }
}
