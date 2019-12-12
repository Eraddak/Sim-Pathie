Shader "Unlit/Daltonism"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_ColorBlindnessType("Color blindness type", int) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
			int _ColorBlindnessType;
            float4 _MainTex_ST;
			static float3x3 color_matrices[11] = {
				// normal vision - identity matrix
				float3x3(
					1.000f, 0.000f, 0.000f,
					0.000f, 1.000f, 0.000f,
					0.000f, 0.000f, 1.000f),
				// Protanopia - blindness to long wavelengths
				float3x3(
					0.567f, 0.433f, 0.000f,
					0.558f, 0.442f, 0.000f,
					0.000f, 0.242f, 0.758f),
				// Protanomaly
				float3x3(
					0.817f, 0.183f, 0.000f,
					0.333f, 0.667f, 0.000f,
					0.000f, 0.125f, 0.875f),
				// Deuteranopia - blindness to medium wavelengths
				float3x3(
					0.625f, 0.375f, 0.000f,
					0.700f, 0.300f, 0.000f,
					0.000f, 0.300f, 0.700f),
				// Deuteranomaly
				float3x3(
					0.800f, 0.200f, 0.000f,
					0.258f, 0.742f, 0.000f,
					0.000f, 0.142f, 0.858f),
				// Tritanopie - blindness to short wavelengths
				float3x3(
					0.950f, 0.050f, 0.000f,
					0.000f, 0.433f, 0.567f,
					0.000f, 0.475f, 0.525f),
				// Tritanomaly
				float3x3(
					0.967f, 0.033f, 0.000f,
					0.000f, 0.733f, 0.267f,
					0.000f, 0.183f, 0.817f),
				// Green cone monochromacy
				float3x3(
					0.109f, 0.873f, 0.018f,
					0.109f, 0.873f, 0.018f,
					0.109f, 0.873f, 0.018f),
				// Blue cone monochromacy
				float3x3(
					0.018f, 0.109f, 0.873f,
					0.018f, 0.109f, 0.873f,
					0.018f, 0.109f, 0.873f),
				// Red cone monochromacy
				float3x3(
					0.873f, 0.109f, 0.018f,
					0.873f, 0.109f, 0.018f,
					0.873f, 0.109f, 0.018f),
				// Achromatopsy
				float3x3(
					1.000f, 1.000f, 1.000f,
					1.000f, 1.000f, 1.000f,
					1.000f, 1.000f, 1.000f)
			};

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
				float3 x = mul(col.rgb, color_matrices[_ColorBlindnessType]);
				return half4(x, 1.0f);
            }
            ENDCG
        }
    }
}
