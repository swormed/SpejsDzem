using UnityEngine;
using UnityEngine.UI;

public class loadLevel1 : MonoBehaviour {
    
    public Button butt;

    void Start()
    {
        Button btn = butt.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
            Application.LoadLevel("scena1");
    }

}
