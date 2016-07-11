Shader "Custom/CustomShader" {
	Properties {
		_Color("Main Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_SecondaryTex ("Albedo 2(RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_SpecColor ("Specular", Color) = (0.2,0.2,0.2,1)
		_BumpMap("Normal Map", 2D) = "bump" {}
		_SecondaryBumpMap("Normal Map 2", 2D) = "bump" {}
		_EmissionColor("Color", Color) = (0,0,0,1)
		_EmissionMap("Emission", 2D) = "white" {}
		_Blend("Blend", Range(0,1)) = 0.5
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 300
		Pass{
			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			//#pragma surface surf Standard fullforwardshadows
#pragma vertex vert
#pragma fragment frag

			// Use shader model 3.0 target, to get nicer looking lighting
#pragma target 3.0

			sampler2D _MainTex;
			sampler2D _SecondaryTex;
			sampler2D _BumpMap;
			sampler2D _SecondaryBumpMap;
			fixed4 _Color;
			float _Blend;
			float4 _SpecColor;
			float _Glossiness;
			uniform float4 _LightColor0;

			struct Input
			{
				float2 uv_MainTex;
				float2 uv_SecondaryTex;
				float2 uv_BumpMap;
				float2 uv_SecondaryBumpMap;
			};

			struct vertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct vertexOutput
			{
				float4 pos : SV_POSITION;
				float4 posWorld : TEXCOORD0;
				float3 normalDir : TEXCOORD1;
			};

			vertexOutput vert(vertexInput v)
			{
				vertexOutput o;
				o.posWorld = mul(_Object2World, v.vertex);
				o.normalDir = normalize(mul(float4(v.normal, 0.0), _World2Object).xyz);
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				return o;
			}

			float4 frag(vertexOutput i) : COLOR
			{
				float3 normalDirection = i.normalDir;
				float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
				float3 lightDirection;
				float attenuation = 1.0;
				lightDirection = normalize(_WorldSpaceLightPos0.xyz);
				float3 diffuseReflection = attenuation * _LightColor0.xyz * max(0.0, dot(normalDirection, lightDirection));
				float3 specularReflection = attenuation * _LightColor0.xyz * _SpecColor.rgb * max(0.0, dot(normalDirection, lightDirection)) * pow(max(0.0, dot(reflect(-lightDirection, normalDirection), viewDirection)), _Glossiness);
				float3 lightFinal = diffuseReflection + specularReflection + UNITY_LIGHTMODEL_AMBIENT;
				return float4(lightFinal * _Color.rgb, 1.0);
			}

				//void surf (Input IN, inout SurfaceOutputStandard o) {
				//	// Albedo comes from a texture tinted by color
				//	fixed4 tex1 = tex2D (_MainTex, IN.uv_MainTex) * _Color;
				//	fixed4 tex2 = tex2D(_SecondaryTex, IN.uv_SecondaryTex) * _Color;
				//	o.Albedo = lerp(tex1, tex2, _Blend);
				//	o.Normal = lerp(UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap)), UnpackNormal(tex2D(_SecondaryBumpMap, IN.uv_SecondaryBumpMap)), _Blend);
				//}
				ENDCG 
		}
	}
	FallBack "Diffuse"
}
