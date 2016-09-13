Shader "VRProject/CustomShader" {
	Properties{
		_Color("Main Color", Color) = (1, 1, 1, 1)
		_MainTex("Texture 1", 2D) = "white" {}
		_SecondaryTex("Texture 2", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0, 1)) = 0.5
		_SpecColor("Specular", Color) = (0.2, 0.2, 0.2, 1)
		_NormalTex("Normal Map 1", 2D) = "bump" {}
		_SecondaryNormal("Normal Map 2", 2D) = "bump" {}
        _SpecularMap("Specular Map", 2D) = "grey" {}
        _SecondarySpec("Specular Map 2", 2D) = "grey" {}
		_Emission("Emissive Map", 2D) = "black" {}
		_EmissionSecond("_Second Emissive Map", 2D) = "black" {}
		[HDR]_EmissionColor("Emission Colour", Color) = (1,1,1,1)
		_Blend("Blend", Range(0, 1)) = 0.5
	}
	SubShader{
			Tags{ "RenderType" = "Opaque" }
			LOD 300

			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			#pragma surface surf StandardSpecular
			#include "UnityCG.cginc"

			// Use shader model 3.0 target, to get nicer looking lighting
			#pragma target 4.0

			sampler2D _MainTex;
			sampler2D _SecondaryTex;
			sampler2D _NormalTex;
			sampler2D _SecondaryNormal;
            sampler2D _SpecularMap;
            sampler2D _SecondarySpec;
			sampler2D _Emission;
			sampler2D _EmissionSecond;
			float4 _EmissionColor;
			fixed4 _Color;
			float _Blend;
			float _Glossiness;

			struct Input
			{
				float2 uv_MainTex;
				float2 uv_SecondaryTex;
				float2 uv_NormalTex;
				float2 uv_SecondaryNormal;
                float2 uv_SpecularMap;
                float2 uv_SecondarySpec;
				float2 uv_Emission;
				float2 uv_EmissionSecond;
			};

			void surf(Input IN, inout SurfaceOutputStandardSpecular o) {
				// Albedo comes from a texture tinted by color
				fixed4 tex1 = tex2D(_MainTex, IN.uv_MainTex) * _Color;
				fixed4 tex2 = tex2D(_SecondaryTex, IN.uv_SecondaryTex) * _Color;
				o.Albedo = lerp(tex1, tex2, _Blend) * _Color;
				o.Normal = lerp(UnpackNormal(tex2D(_NormalTex, IN.uv_NormalTex)), UnpackNormal(tex2D(_SecondaryNormal, IN.uv_SecondaryNormal)), _Blend);
				
				o.Emission = lerp(tex2D(_Emission, IN.uv_Emission) * _EmissionColor, tex2D(_EmissionSecond,IN.uv_EmissionSecond) * _EmissionColor, _Blend);
				o.Specular = lerp(tex2D(_SpecularMap, IN.uv_SpecularMap), tex2D(_SecondarySpec, IN.uv_SecondarySpec), _Blend);
				o.Smoothness = _Glossiness;
				
			}
			ENDCG
		}
		FallBack "Diffuse"
}
