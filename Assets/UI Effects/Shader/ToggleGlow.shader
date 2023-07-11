Shader "UI/ToggleShader1"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Speed ("Speed", Range(1, 5)) = 5

        _StencilComp ("Stencil Comparison", Float) = 8
		_Stencil ("Stencil ID", Float) = 0
		_StencilOp ("Stencil Operation", Float) = 0
		_StencilWriteMask ("Stencil Write Mask", Float) = 255
		_StencilReadMask ("Stencil Read Mask", Float) = 255

		_ColorMask ("Color Mask", Float) = 15
		_ClipRect ("Clip Rect", Vector) = (-32767, -32767, 32767, 32767)
    }
    SubShader
    {
        Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}
		
		Stencil
		{
			Ref [_Stencil]
			Comp [_StencilComp]
			Pass [_StencilOp] 
			ReadMask [_StencilReadMask]
			WriteMask [_StencilWriteMask]
		}

		Cull Off
		Lighting Off
		ZWrite Off
		ZTest [unity_GUIZTestMode]
		Fog { Mode Off }
		Blend One One

		ColorMask [_ColorMask]

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "UnityUI.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
                float4 worldPosition : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _ClipRect;
            float _Speed;

            v2f vert (appdata v)
            {
                v2f o;
                o.worldPosition = v.vertex;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                
#ifdef UNITY_HALF_TEXEL_OFFSET
                o.vertex.xy += (_ScreenParams.zw - 1.0) * float2(-1, 1);
#endif
                o.color = v.color;
                return o;
            }

fixed4 frag (v2f i) : SV_Target
{
    fixed2 uv = i.uv;
    
    // Define the start and end colors
    fixed3 startColor = fixed3(100.0 / 12.0, 1.0 / 2.0, 242.0 / 15.0);
    fixed3 endColor = fixed3(255.0 / 255.0, 0.0 / 255.0, 152.0 / 255.0);

    // Calculate the lerp factor using a sin() function
    float lerpFactor = (sin(_Time.y * _Speed + uv.x * 3.14159265) + 1.0) / 2.0;
    
    // Interpolate between the start and end colors using the lerp factor
    fixed3 col = lerp(startColor, endColor, lerpFactor);

    fixed4 tex = tex2D(_MainTex, i.uv);
    tex.a *= UnityGet2DClipping(i.worldPosition.xy, _ClipRect);
    tex.rgb *= tex.a;
    col.rgb *= tex.a;
    i.color *= i.color.a;

    fixed texCol = (tex.r * tex.r);
#ifdef UNITY_UI_ALPHACLIP
    clip (tex.a - 0.01);
#endif
    return fixed4(texCol + col.rgb/2, tex.a) * i.color;
}
            ENDCG
        }
    }
}