Shader "Custom/2DOutline"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _OutlineWidth ("Outline Width", Range(0, 10)) = 1

        // Обязательные параметры для поддержки UI Масок и Stencil
        _StencilComp ("Stencil Comparison", Float) = 8
        _Stencil ("Stencil ID", Float) = 0
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        _ColorMask ("Color Mask", Float) = 15
        [Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip ("Use Alpha Clip", Float) = 0
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

        // Настройки Stencil для UI Canvas
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
        Blend SrcAlpha OneMinusSrcAlpha // Стандартное смешивание для UI
        ColorMask [_ColorMask]

        Pass
        {
        CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 3.0 // КРИТИЧЕСКИ ВАЖНО: Разрешает множественные выборки текстур
            #include "UnityCG.cginc"
            
            struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                float2 texcoord  : TEXCOORD0;
            };
            
            fixed4 _Color;
            fixed4 _OutlineColor;
            float _OutlineWidth;
            sampler2D _MainTex;
            float4 _MainTex_TexelSize;

            v2f vert(appdata_t IN)
            {
                v2f OUT;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.texcoord = IN.texcoord;
                OUT.color = IN.color * _Color;
                return OUT;
            }

            fixed4 frag(v2f IN) : SV_Target
            {
                fixed4 c = tex2D(_MainTex, IN.texcoord) * IN.color;
                
                if (_OutlineWidth > 0)
                {
                    float2 texel = _MainTex_TexelSize.xy * _OutlineWidth;
                    
                    // Ищем максимальную прозрачность среди соседей
                    float maxAlpha = 0;
                    
                    // 1. Проверка по кресту (вверх, вниз, влево, вправо)
                    maxAlpha = max(maxAlpha, tex2D(_MainTex, IN.texcoord + float2(0, texel.y)).a);
                    maxAlpha = max(maxAlpha, tex2D(_MainTex, IN.texcoord - float2(0, texel.y)).a);
                    maxAlpha = max(maxAlpha, tex2D(_MainTex, IN.texcoord + float2(texel.x, 0)).a);
                    maxAlpha = max(maxAlpha, tex2D(_MainTex, IN.texcoord - float2(texel.x, 0)).a);
                    
                    // 2. Проверка по диагоналям (умножаем на 0.707, чтобы радиус был ровным)
                    float2 diag = texel * 0.707106;
                    maxAlpha = max(maxAlpha, tex2D(_MainTex, IN.texcoord + float2(diag.x, diag.y)).a);
                    maxAlpha = max(maxAlpha, tex2D(_MainTex, IN.texcoord + float2(diag.x, -diag.y)).a);
                    maxAlpha = max(maxAlpha, tex2D(_MainTex, IN.texcoord - float2(diag.x, diag.y)).a);
                    maxAlpha = max(maxAlpha, tex2D(_MainTex, IN.texcoord - float2(diag.x, -diag.y)).a);

                    // Плавно находим разницу между альфой края и альфой самого спрайта
                    float outline = saturate(maxAlpha - c.a);
                    
                    if (outline > 0)
                    {
                        // Мягко смешиваем оригинальный пиксель с цветом обводки
                        fixed4 outlineColor = _OutlineColor * IN.color.a;
                        return lerp(c, outlineColor, outline);
                    }
                }

                return c;
            }
        ENDCG
        }
    }
}