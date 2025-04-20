using System;
using UnityEngine;

[System.Serializable]
public struct HexCoordinates
{

    [SerializeField]
    private int q, r;

    public int Q
    {
        get
        {
            return q;
        }
    }

    public int R
    {
        get
        {
            return r;
        }
    }
    public int S
    {
        get
        {
            return -Q - R;
        }
    }

    public HexCoordinates(int q, int r)
    {
        this.q = q;
        this.r = r;
    }

    public static HexCoordinates FromOffsetCoordinates(int q, int r)
    {
        return new HexCoordinates(q - r / 2, r);
    }


    public override string ToString()
    {
        return $"(Q {Q},S {S},R {R})";
    }

    public string ToStringOnSeparateLines()
    {
        return $"{Q}\n{S}\n{R}";
    }

    public static HexCoordinates FromPosition(Vector3 position)
    {
        float x = position.x / (HexMetrics.innerRadius * 2f);
        float y = -x;

        float offset = position.z / (HexMetrics.outerRadius * 3f);
        x -= offset;
        y -= offset;

        int iX = Mathf.RoundToInt(x);
        int iY = Mathf.RoundToInt(y);
        int iZ = Mathf.RoundToInt(-x - y);

        if (iX + iY + iZ != 0)
        {
            float dX = Mathf.Abs(x - iX);
            float dY = Mathf.Abs(y - iY);
            float dZ = Mathf.Abs(-x - y - iZ);

            if (dX > dY && dX > dZ)
            {
                iX = -iY - iZ;
            }
            else if (dZ > dY)
            {
                iZ = -iX - iY;
            }
        }

        return new HexCoordinates(iX, iZ);
    }
}