Shader "URP/ScrollingTrack"
{
    Properties
    {
        _BaseMap ("Base Map", 2D) = "white" {} // 기본 텍스처
        _NormalMap ("Normal Map", 2D) = "bump" {} // 노멀 맵
        _BaseColor ("Base Color", Color) = (1,1,1,1) // 색상 조절 프로퍼티 추가
        _Speed ("Scroll Speed", Float) = 1.0 // 스크롤 속도
    }
    
    SubShader
    {
        Tags { "RenderPipeline"="UniversalRenderPipeline" "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            Name "UniversalForward"
            Tags { "LightMode"="UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float2 uv : TEXCOORD0;
                float4 positionCS : SV_POSITION;
            };

            TEXTURE2D(_BaseMap); SAMPLER(sampler_BaseMap);
            TEXTURE2D(_NormalMap); SAMPLER(sampler_NormalMap);
            float4 _BaseMap_ST;
            float4 _BaseColor; // 색상 프로퍼티 추가
            float _Speed;

            Varyings vert(Attributes v)
            {
                Varyings o;
                o.positionCS = TransformObjectToHClip(v.positionOS);

                // UV 스크롤 (시간 기반)
                float offset = _Time.y * _Speed;
                o.uv = v.uv + float2(0, offset); // Y축 방향으로 이동

                return o;
            }

            half4 frag(Varyings i) : SV_Target
            {
                half4 baseColor = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, i.uv);
                return baseColor * _BaseColor; // BaseMap에 색상 적용
            }
            ENDHLSL
        }
    }
}