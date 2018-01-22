Shader "OverlayShader" {
	Properties {
		_MainTex("Texture", 2D) = "white" {}
		_OverlayTex("OverlayTexture", 2D) = "white" {}
	}

	SubShader {
		Cull Off
		ZWrite Off
		ZTest Always

		Pass {
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata {
				float4 vertex: POSITION;
				float2 uv: TEXCOORD0;
			};

			struct v2f {
				float4 vertex: SV_POSITION;
				float2 uv: TEXCOORD0;
				float2 screenPos: TEXCOORD1;
			};

			v2f vert(appdata v) {
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.screenPos = ComputeScreenPos(o.vertex);
				return o;
			}

			sampler2D _MainTex;
			sampler2D _OverlayTex;

			fixed4 frag(v2f i): SV_Target {
				float4 a = tex2D(_MainTex, i.uv);
				float4 b = tex2D(_OverlayTex, i.uv);

				if(0.5 < i.screenPos.x) {
					return a;
				}
				return b;
			}
			ENDCG
		}
	}
}
