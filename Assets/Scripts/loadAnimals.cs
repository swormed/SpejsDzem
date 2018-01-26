using UnityEngine;
using UnityEngine.UI;

public class loadAnimals : MonoBehaviour
{

    public Button butt;

    void Start()
    {
        Button btn = butt.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Application.LoadLevel("animals");
    }

}
