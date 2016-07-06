Shader "Custom/CustomShader" {
	Properties {
		_Color("Main Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_SecondaryTex ("Albedo 2(RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_SpecColor ("Specular", Color) = (0.2,0.2,0.2,1)
		_SpecGlossMap("Specular", 2D) = "white" {}
		_BumpMap("Normal Map", 2D) = "bump" {}
		_SecondaryBumpMap("Normal Map 2", 2D) = "bump" {}
		_EmissionColor("Color", Color) = (0,0,0,1)
		_EmissionMap("Emission", 2D) = "white" {}
		_Blend("Blend", Range(0,1)) = 0.5
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 300
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _SecondaryTex;
		sampler2D _BumpMap;
		sampler2D _SecondaryBumpMap;
		fixed4 _Color;
		float _Blend;

		struct Input {
			float2 uv_MainTex;
			float2 uv_SecondaryTex;
			float2 uv_BumpMap;
			float2 uv_SecondaryBumpMap;
		};		

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 tex1 = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			fixed4 tex2 = tex2D(_SecondaryTex, IN.uv_SecondaryTex) * _Color;
			o.Albedo = lerp(tex1, tex2, _Blend);
			float normal1 = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
			float normal2 = UnpackNormal(tex2D(_SecondaryBumpMap, IN.uv_SecondaryBumpMap));
			o.Normal = normalize(lerp(normal1, normal2, _Blend));
		}
		ENDCG
	}
	FallBack "Diffuse"
}
