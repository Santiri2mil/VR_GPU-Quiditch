using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// There is a limitation in Unity, you can't draw more than 1024 objects
// To draw more than that number, we have to render in batches
// In this case sectiona of a 1000 objects.
// Limitation: It has to be the same mesh and material to instance.
public class ObjData
{
    public Vector3 pos;
    public Vector3 scale;
    public Quaternion rot;

    public Matrix4x4 matrix
    {
        get
        {
            return Matrix4x4.TRS(pos, rot, scale);
        }
    }

    public ObjData(Vector3 pos, Vector3 scale, Quaternion rot)
    {
        this.pos = pos;
        this.scale = scale;
        this.rot = rot;
    }
}

public class Spawner : MonoBehaviour
{
    public int instances;
    public Vector3 maxPos;
    public Mesh objMesh;
    public Material objMat;

    private List<List<ObjData>> batches = new List<List<ObjData>>();

    // Start is called before the first frame update
    void Start()
    {
        int batchIndexNum = 0;
        List<ObjData> currBatch = new List<ObjData>();
        for (int i = 0; i < instances; i++)
        {
            AddObj(currBatch, i);
            batchIndexNum++;
            if (batchIndexNum >= 1000)
            {
                batches.Add(currBatch);
                currBatch = BuildNewBatch();
                batchIndexNum = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        RenderBatches();
    }

    private void AddObj(List<ObjData> batch, int i)
    {
        Vector3 position = new Vector3(Random.Range(-maxPos.x, maxPos.x), Random.Range(-maxPos.y, maxPos.y), Random.Range(-maxPos.z, maxPos.z));
        batch.Add(new ObjData(position, new Vector3(2, 2, 2), Quaternion.identity));
    }

    private List<ObjData> BuildNewBatch()
    {
        return new List<ObjData>();
    }

    private void RenderBatches()
    {
        foreach (var batch in batches)
        {
            Graphics.DrawMeshInstanced(objMesh, 0, objMat, batch.Select((a) => a.matrix).ToList());
        }
    }
}