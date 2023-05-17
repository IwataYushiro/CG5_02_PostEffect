Shader "Unlit/42_3_Sepia"
{
	Properties
	{
		_MainTex("MainTex", 2D) = ""{}
	}
		SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
			fixed4 col = tex2D(_MainTex, i.uv);
			fixed sepia = 0.1f;
			fixed grayScale = col.r * 0.299 + col.g * 0.587 + col.b * 0.114;
			//セピア
			//fixed4 gray = fixed4(grayScale + sepia, grayScale, grayScale - sepia, 1);
			//コールド
			fixed4 gray = fixed4(grayScale - sepia, grayScale, grayScale + sepia, 1);
			return gray;
			}
			ENDCG
		}
	}
}
