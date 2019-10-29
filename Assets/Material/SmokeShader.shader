Shader "Custom/Smoke Ground" {
	Properties{
		_MainTextrue("Base (RGB)", 2D) = "white" {}
	    _MainColor("MainColor", color) = (1,1,1,1)
	    _XSpeed("XSpeed", Range(0, 40)) = 2
	    _YSpeed("YSpeed", Range(0, 40)) = 2
	}
		SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 200

			CGPROGRAM
			#pragma surface surf Lambert

			sampler2D _MainTextrue;
		    fixed4 _MainColor;
			float _XSpeed;
			float _YSpeed;
			
			struct Input {
				float2 uv_MainTextrue;
			};

			void surf(Input i, inout SurfaceOutput o)
			{
				fixed2 uvOffset = i.uv_MainTextrue;
				fixed xOffset = _XSpeed * _Time;
				fixed yOffset = _YSpeed * _Time;

				uvOffset += fixed2(xOffset,yOffset);

				half4 p = tex2D(_MainTextrue, uvOffset);
				o.Albedo = p.rgb*_MainColor;
				o.Alpha = p.a;
			}
			ENDCG
	}
		FallBack "Diffuse"
}
