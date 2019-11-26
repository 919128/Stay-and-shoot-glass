Shader "Mobile/DiffuseColorEmission"
{
    Properties
    {
        _Color("Color",COLOR)=(0.5,0.5,0.5,1.0)
        _EmissionColor("Emission color",COLOR)=(0.5,0.5,0.5,0.5)
        _MainTex ("Base (RGB)", 2D) = "white" {}
    }
 
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 150
        CGPROGRAM
        #pragma surface surf Lambert noforwardadd
 
        sampler2D _MainTex;
        fixed4 _Color;
        fixed4 _EmissionColor;
 
        struct Input
        {
            float2 uv_MainTex;
        };
 
        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Alpha = c.a;
		    o.Emission = _EmissionColor.rgb;
        }
        ENDCG
    }
    Fallback "Mobile/VertexLit"
}