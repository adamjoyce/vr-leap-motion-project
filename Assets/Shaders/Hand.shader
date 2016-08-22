Shader "Custom/Hand" {
	Properties{
		_Color("ColorTint", Color) = (1, 1, 1, 1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_BumpMap("Normal Map", 2D) = "bump" {}
		[HDR]_RimColor("Rim Color", Color) = (1, 1, 1, 1)
		_RimPower("Rim Power", Range(1.0, 6.0)) = 3.0
	}
	SubShader {
			Tags{ "RenderType" = "Transparent" }
			LOD 200

			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
#pragma surface surf Lambert

			// Use shader model 3.0 target, to get nicer looking lighting
#pragma target 3.0
			float4 _Color;
			sampler2D _MainTex;
			sampler2D _BumpMap;
			float4 _RimColor;
			float _RimPower;


			struct Input {
				float4 color : Color;
				float2 uv_MainTex;
				float2 uv_BumpMap;
				float3 viewDir;
			};

			void surf (Input IN, inout SurfaceOutput o) {
				// Albedo comes from a texture tinted by color
				IN.color = _Color;
				o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb * IN.color;
				o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
				half rim = 1 - saturate(dot(normalize(IN.viewDir), o.Normal));
				o.Emission = _RimColor.rgb * pow(rim, _RimPower);
				o.Alpha = IN.color.a;
			}
			ENDCG
	}
	FallBack "Diffuse"
}
