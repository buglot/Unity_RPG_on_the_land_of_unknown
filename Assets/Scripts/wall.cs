using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class wall : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public TilemapCollider2D tmc2d;
    public CompositeCollider2D csC2d;
    void Start()
    {
        
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }

        // Set TilemapCollider2D to use CompositeCollider2D
        if (tmc2d != null)
        {
            tmc2d.usedByComposite = true;
        }

        // Set CompositeCollider2D geometry type to Polygon
        if (csC2d != null)
        {
            csC2d.geometryType = CompositeCollider2D.GeometryType.Polygons;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
