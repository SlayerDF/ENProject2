Shader "Unlit/EmptyPass"
{
    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
        }
        LOD 100

        Pass
        {
            Name "Empty"
            ZWrite On
            ColorMask 0
        }
    }
}