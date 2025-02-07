using UnityEngine;
using UnityEngine.UI;

public class SelectColorUi : MonoBehaviour
{
    public GameObject UiPanel;
    public Button Blue;
    public Button Red;
    public Button Green;

    public Material Reds;
    public Material Blues;
    public Material Greens;

    private GameObject selectedSofa; // Store the selected sofa

    void Start()
    {
        
        Red.onClick.AddListener(ChangeMaterialRed);
        Blue.onClick.AddListener(ChangeMaterialBlue);
        Green.onClick.AddListener(ChangeMaterialGreen);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Clicked on: " + hit.collider.gameObject.name);

                if (hit.collider.CompareTag("Sofa")) // Check tag instead of name because unity use name as sofa(clone1)
                {
                    selectedSofa = hit.collider.gameObject; // Store the sofa
                    UiPanel.SetActive(true); // Show UI panel
                }
                else
                {
                    UiPanel.SetActive(false);//click on other objects
                }
            }
        }
    }

    void ChangeAllMaterials(Material newMaterial)
    {
        if (selectedSofa != null)//if hit detect sofa
        {
            MeshRenderer[] meshRenderers = selectedSofa.GetComponentsInChildren<MeshRenderer>();//Gets all MeshRenderer components attached to the selectedSofa and its child objects
            foreach (MeshRenderer renderer in meshRenderers)// store one by one meshrenderer component in renderer 
            {
                Material[] newMaterials = new Material[renderer.materials.Length];//(renderer.materials.Length)tells us how many materials the object currently has.
                                                                                  // creates a new array of materials with the same size as the existing materials.
                for (int i = 0; i < newMaterials.Length; i++)
                {
                    newMaterials[i] = newMaterial;//In new array already have current material so put new material one by one
                }
                renderer.materials = newMaterials;// assign the new mateial to meshrender
            }
        }
    }

    public void ChangeMaterialRed()//when ever this function button press  it pass change material and set new material in forloop
    {
        ChangeAllMaterials(Reds);
    }

    public void ChangeMaterialBlue()
    {
        ChangeAllMaterials(Blues);
    }

    public void ChangeMaterialGreen()
    {
        ChangeAllMaterials(Greens);
    }

}
