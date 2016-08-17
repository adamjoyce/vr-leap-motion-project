Shader "VR/Invisible" {
	SubShader{
			Pass{
				CGPROGRAM
				// Physically based Standard lighting model, and enable shadows on all light types
				#pragma fragment frag
				#pragma vertex vert

				struct v2f {
					fixed4 position : SV_POSITION;
				};

				v2f vert()
				{
					v2f o;
					o.position = fixed4(0, 0, 0, 0);
					return o;
				}

				fixed4 frag() : COLOR 
				{
					return fixed4(0, 0, 0, 0);
				}
				ENDCG
		}
	}
}
