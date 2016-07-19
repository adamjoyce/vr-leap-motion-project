Shader "Custom/CustomShader" {
	Properties{
		_Color("Main Color", Color) = (1, 1, 1, 1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_SecondaryTex("Albedo 2(RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0, 1)) = 0.5
		_SpecColor("Specular", Color) = (0.2, 0.2, 0.2, 1)
		_BumpMap("Normal Map", 2D) = "bump" {}
		_SecondaryBumpMap("Normal Map 2", 2D) = "bump" {}
		_EmissionColor("Color", Color) = (0, 0, 0, 1)
		_EmissionMap("Emission", 2D) = "white" {}
		_Blend("Blend", Range(0, 1)) = 0.5
		_SpecMap("Specular Map 1", 2D) = "white" {}
		_SecondarySpecMap("Specular Map 2", 2D) = "white" {}
	}
	SubShader{
			Tags{ "RenderType" = "Opaque" }
			LOD 300

			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			#pragma surface surf StandardSpecular
			#include "UnityCG.cginc"
			#include "Lighting.cginc"

			// Use shader model 3.0 target, to get nicer looking lighting
			#pragma target 3.0

			sampler2D _MainTex;
			sampler2D _SecondaryTex;
			sampler2D _BumpMap;
			sampler2D _SecondaryBumpMap;
			sampler2D _SpecMap;
			sampler2D _SecondarySpecMap;
			fixed4 _Color;
			float _Blend;
			float _Glossiness;

			struct Input
			{
				float2 uv_MainTex;
				float2 uv_SecondaryTex;
				float2 uv_BumpMap;
				float2 uv_SecondaryBumpMap;
				float2 uv_SpecMap;
				float2 uv_SecondarySpecMap;
			};

			void surf(Input IN, inout SurfaceOutputStandardSpecular o) {
				// Albedo comes from a texture tinted by color
				fixed4 tex1 = tex2D(_MainTex, IN.uv_MainTex) * _Color;
				fixed4 tex2 = tex2D(_SecondaryTex, IN.uv_SecondaryTex) * _Color;
				o.Albedo = lerp(tex1, tex2, _Blend) * _Color;
				o.Normal = lerp(UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap)), UnpackNormal(tex2D(_SecondaryBumpMap, IN.uv_SecondaryBumpMap)), _Blend);
				o.Specular = lerp(tex2D(_SpecMap, IN.uv_SpecMap), tex2D(_SecondarySpecMap, IN.uv_SecondarySpecMap), _Blend);
				o.Smoothness = _Glossiness;
			}
			ENDCG
		}
		FallBack "Diffuse"
}
