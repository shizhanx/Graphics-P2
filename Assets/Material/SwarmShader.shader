Shader "Custom/BreathSwarm"{
	Properties{
		_MainTexture("Texture", 2D) = "white" {}
		_MainColor("MainColor",Color) = (1,1,1,1)
	}
		SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 100

			Pass{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				sampler2D _MainTexture;
				float4 _MainTexture_ST;
				fixed4 _MainColor;

				struct appdata{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f{
					float4 vertex : SV_POSITION;
					float2 uv : TEXCOORD0;
				};
				
				v2f vert(appdata v){
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = TRANSFORM_TEX(v.uv, _MainTexture);
					return o;
				}

				fixed4 frag(v2f i) : SV_Target{
					fixed4 breath_color = _MainColor * ((cos(_Time.y * 3.5) + 3) / 7.0);
					fixed4 p = tex2D(_MainTexture, i.uv)*breath_color;
					return p;
				}
				ENDCG
			}
		}
}