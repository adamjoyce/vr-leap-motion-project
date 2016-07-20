Shader "Custom/Tesselation" {
	Properties{
		_Tess("Tessellation", Range(1, 32)) = 4
		_MainTex("Base (RGB)", 2D) = "white" {}
		_DispTex("Disp Texture", 2D) = "gray" {}
		_NormalMap("Normalmap", 2D) = "bump" {}
		_SecondaryTex("Base (RGB)", 2D) = "white" {}
		_SecondaryDisp("Disp Texture", 2D) = "gray" {}
		_SecondaryNormal("Normalmap", 2D) = "bump" {}
		_Displacement("Displacement", Range(0, 1.0)) = 0.3
			_Color("Color", color) = (1, 1, 1, 0)
			_SpecColor("Spec color", color) = (0.5, 0.5, 0.5, 0.5)
			_Blend("Blend", Range(0, 1.0)) = 0.5
	}
	SubShader{
			Tags{ "RenderType" = "Opaque" }
			LOD 300

			CGPROGRAM
#pragma surface surf BlinnPhong addshadow fullforwardshadows vertex:disp tessellate:tessDistance nolightmap
#pragma target 5.0
#include "Tessellation.cginc"
#include "UnityCG.cginc"

			struct appdata {
				float4 vertex : POSITION;
				float4 tangent : TANGENT;
				float3 normal : NORMAL;
				float2 texcoord : TEXCOORD0;
			};

			float _Tess;

			float4 tessDistance(appdata v0, appdata v1, appdata v2) {
				float minDist = 10.0;
				float maxDist = 25.0;
				return UnityDistanceBasedTess(v0.vertex, v1.vertex, v2.vertex, minDist, maxDist, _Tess);
			}

			sampler2D _DispTex;
			sampler2D _SecondaryDisp;
			uniform float4 _DispTex_ST;
			uniform float4 _SecondaryDisp_ST;
			float _Displacement;
			float _Blend;

			void disp(inout appdata v)
			{
				float d1 = tex2Dlod(_DispTex, float4(TRANSFORM_TEX(v.texcoord, _DispTex), 0, 0)).r * _Displacement;
				float d2 = tex2Dlod(_SecondaryDisp, float4(TRANSFORM_TEX(v.texcoord, _SecondaryDisp), 0, 0)).r * _Displacement;
				float value = lerp(d1, d2, _Blend);
				v.vertex.xyz += v.normal * value;
			}

			struct Input {
				float2 uv_MainTex;
				float2 uv_SecondaryTex;
			};

			sampler2D _MainTex;
			sampler2D _NormalMap;
			sampler2D _SecondaryTex;
			sampler2D _SecondaryNormal;
			fixed4 _Color;

			void surf(Input IN, inout SurfaceOutput o) {
				half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
				half4 d = tex2D(_SecondaryTex, IN.uv_SecondaryTex) * _Color;
				half4 albLerp = lerp(c, d, _Blend);
				o.Albedo = albLerp.rgb;
				o.Specular = 0.2;
				o.Gloss = 1.0;
				o.Normal = lerp(UnpackNormal(tex2D(_NormalMap, IN.uv_MainTex)), UnpackNormal(tex2D(_SecondaryNormal, IN.uv_SecondaryTex)), _Blend);
			}
			ENDCG
		}
		FallBack "Diffuse"
}
