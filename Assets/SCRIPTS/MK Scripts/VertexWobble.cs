using UnityEngine;
using TMPro;

public class VertexWobble : MonoBehaviour
{
    public float vertSpeedOne = 3.3f;
    public float vertSpeedTwo = 2.5f;
    public float wobbleSpeed = 1;
    private TMP_Text textMesh;
    private Mesh mesh;
    private Vector3[] vertices;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        vertices = mesh.vertices;
        for(int i = 0; i < textMesh.textInfo.characterCount; i++)
        {
            TMP_CharacterInfo c = textMesh.textInfo.characterInfo[i];
            int index = c.vertexIndex;
            Vector3 offset = Wobble(Time.time * wobbleSpeed + 1);
            vertices[index] += offset;
            vertices[index + 1] += offset;
            vertices[index + 2] += offset;
            vertices[index + 3] += offset;
        }

        mesh.vertices = vertices;
        textMesh.canvasRenderer.SetMesh(mesh);
    }
    Vector2 Wobble(float time)
    {
        return new Vector2(Mathf.Sin(time * vertSpeedOne), Mathf.Cos(time * vertSpeedTwo));
    }
}
