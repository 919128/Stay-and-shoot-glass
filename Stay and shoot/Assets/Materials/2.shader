Shader "Custom/2"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _FogColor("Fog Color", Color) = (0.3, 0.4, 0.7, 1.0)
        _FogStart("Fog Start", float) = 0
        _FogFadeHeight ("Fog Fade Height", float) = 0
    }
    
    SubShader
    {
        Tags{ "RenderType" = "Opaque" }
    
        CGPROGRAM
    
        #pragma surface surf Lambert finalcolor:mycolor vertex:myvert
        
        struct Input
        {
            half fog;
        };
        
        fixed4 _Color;
        fixed4 _FogColor;
        half _FogStart;
        float _FogFadeHeight;
        
        void myvert(inout appdata_full v, out Input data)
        {
            float4 pos = mul(unity_ObjectToWorld, v.vertex);
            data.fog = saturate(((pos.y) - _FogStart) / _FogFadeHeight);
        }
        
        void mycolor(Input IN, SurfaceOutput o, inout fixed4 color)
        {
            fixed3 fogColor = _FogColor.rgb;
            fixed3 tintColor = _Color.rgb;
            
            color.rgb = lerp(fogColor, color.rgb, IN.fog);
        }
        
        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = _Color.rgb;
        }
    
        ENDCG
    }

    Fallback "Diffuse"
}
