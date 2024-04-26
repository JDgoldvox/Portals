Shader "Custom/SimpleHLSLShader"
{
    Properties
    {
        _Color("Color", Color) = (1, 1, 1, 1) // Color property with default white color
        _MainTex("Texture", 2D) = "white" {} // Texture property with default white texture
    }
    SubShader
    {
        Tags { "Queue" = "Geometry" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            struct appdata
            {
                float4 vertex : POSITION; // Input vertex position
                float2 uv : TEXCOORD0; // Input texture coordinates
            };

            struct v2f
            {
                float4 pos : SV_POSITION; // Output position
                float2 uv : TEXCOORD0; // Output texture coordinates
            };

            // Properties
            uniform float4 _Color; // Color uniform
            uniform sampler2D _MainTex; // Texture uniform

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 color = tex2D(_MainTex, i.uv) * _Color; // Sample the texture and multiply by color
                return color;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}