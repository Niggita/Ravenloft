Shader "Hidden/RedEffect" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_bwBlend ("Black & White blend", Range (0, 1)) = 0
	}
	SubShader {
 		Pass {
 			CGPROGRAM
 			#pragma vertex vert_img
 			#pragma fragment frag
 
			 #include "UnityCG.cginc"
 
			 uniform sampler2D _MainTex;
			 uniform float _bwBlend;
 
 			float4 frag(v2f_img i) : COLOR {
 				float4 c = tex2D(_MainTex, i.uv);
 
				float3 red = float3(1.0, 0.0, 0.0); 
				 
				float4 result = c;
				result.rgb = lerp(c.rgb, red, _bwBlend);
				return result;
				
 			}
 			ENDCG
 		}
	}
}
