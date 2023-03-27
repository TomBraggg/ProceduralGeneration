using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MeshSettings : UpdatableData {

    public float meshScale = 2f;

    public bool useFlatShading;

    public const int numSupportedLODs = 5;
    public const int numSupportedChunkSizes = 10;
    public const int numSupportedFlatshadedChunkSizes = 4;
    public static readonly int[] supportedChunkSizes = { 24, 48, 72, 96, 120, 144, 168, 192, 216, 240 };

    [Range(0, numSupportedChunkSizes - 1)]
    public int chunkSizeIndex;
    [Range(0, numSupportedFlatshadedChunkSizes - 1)]
    public int flatshadedChunkSizeIndex;


    //number of vertices per line rendered at the highest LOD (0). Includes extra vertices that are excluided from final mesh but used for normal matching between chunks.
    public int numVertsPerLine {
        get {
            return supportedChunkSizes[(useFlatShading) ? flatshadedChunkSizeIndex : chunkSizeIndex] + 5;
        }
    }

    public float meshWorldSize {
        get {
            return (numVertsPerLine - 3) * meshScale;
        }
    }

}
