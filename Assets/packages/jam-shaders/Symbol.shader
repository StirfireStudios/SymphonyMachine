Shader "Jam/Symbol" {
  Properties {
    _MainTex ("Albedo (RGB)", 2D) = "white" {}
    _Emission ("Emission", Range(0, 1)) = 0
    _BaseColor ("Base Color", Color) = (0, 0, 0, 0)
    _GlowColor ("Glow Color", Color) = (1, 1, 1, 1)
    _GlowAmount ("Glow Amount", Range(0, 1)) = 0
    _Smoothness ("Smoothness", Range(0, 1)) = 0
    _Metallic ("Metallic", Range(0, 1)) = 0
  }
  SubShader {
    Tags {
      "RenderType"="Transparent"
      "Queue"="Transparent"
    }
    ZWrite On
    CGPROGRAM

    // Physically based Standard lighting model, and enable shadows on all light types
    #pragma surface surf Standard

    sampler2D _MainTex;
    float _Emission;
    float _GlowAmount;
    float _Smoothness;
    float _Metallic;
    float4 _GlowColor;
    float4 _BaseColor;

    struct Input {
      float2 uv_MainTex;
    };

    void surf (Input IN, inout SurfaceOutputStandard o) {
      half4 rgba = tex2D (_MainTex, IN.uv_MainTex);
      if (rgba.a == 0) {
        discard;
      }
      else {
        o.Alpha = 0;
        o.Albedo = lerp(_BaseColor, _GlowColor, _GlowAmount);
        o.Emission = float3(_Emission, _Emission, _Emission);
        o.Metallic = _Metallic;
        o.Smoothness = _Smoothness;
      }
    }
    ENDCG
  }
  FallBack "Diffuse"
}
