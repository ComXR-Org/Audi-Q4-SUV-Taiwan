/*
	You can share your feedback at:	arpitshah555@live.com
*/

Shader "CodeCraft/Transparent"
{
	Properties
	{
		_Color("Main Color", Color) = (1,1,1,0.5)
		_Smoothness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_Occlusion("Occlusion", 2D) = "white" {}
		_OcclusionPower("Occlusion Power", Range(0 , 1)) = 1
		[Toggle(FLAKES)] _EnableFlakes("Enable Flakes", float) = 0
		_Flakes("Flakes", 2D) = "white" {}
		_FlakesTint("Flakes Color", Color) = (1,1,1,1)
		_FlakesIntensity("Flakes Intensity", Range(0,0.5)) = 0.2
		[Toggle(CUBE)] _EnableCube("Enable Reflections", float) = 0
		_Cube("Reflection Cubemap", CUBE) = "" {}
		_CubeTint("Reflection Color", Color) = (1,1,1,1)
		_CubeIntensity("Reflection Amount", Range(0,2.0)) = 0.2
		_Fresnel("Fresnel Amount", Range(0,4.0)) = 0.5
		[Toggle(RIM)] _EnableRim("Enable Rim", Int) = 0
		_RimColor("Rim Color", Color) = (1,1,1,1)
		_RimAmount("Rim Amount", Range(0,8)) = 0.5
		_RimPower("Rim Power", Range(0,3)) = 1
	}

	SubShader
	{
		Tags { "Queue" = "Transparent" "RenderType" = "Transparent"}
		LOD 200

		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows alpha
		#pragma shader_feature FLAKES
		#pragma shader_feature CUBE
		#pragma shader_feature RIM
		#pragma target 3.0


		struct Input
		{
			float2 uv_MainTex;
			float2 uv_Flakes;
			float3 worldRefl;
			float3 viewDir;
		};

		fixed4 _Color;
		half _Smoothness;
		half _Metallic;
		uniform sampler2D _Occlusion;
		uniform half _OcclusionPower;
		sampler2D _Flakes;
		float4 _FlakesTint;
		float _FlakesIntensity;
		samplerCUBE _Cube;
		float4 _CubeTint;
		float _CubeIntensity;
		uniform float4x4 _CubeRot;
		float4 _RimColor;
		float _RimPower;
		float _RimAmount;
		float _Fresnel;

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			half sat = saturate(dot(normalize(IN.viewDir), o.Normal));
			half rim = 1.0 - sat;
			half fres = pow(rim, _Fresnel);
			float occl = lerp(1, tex2D(_Occlusion, IN.uv_MainTex).g, _OcclusionPower);
			fixed4 alb = _Color.rgba;
			#ifdef FLAKES
			fixed4 f = tex2D(_Flakes, IN.uv_Flakes) * _FlakesTint * _FlakesIntensity;
			alb += f.rgba;
			#endif
			#ifdef RIM
			float rimAmt = 10 - _RimAmount;
			rim = pow(rim, rimAmt);
			alb += (_RimColor.rgba * (rim * _RimPower));
			#endif
			o.Albedo = alb;
			o.Metallic = _Metallic;
			o.Smoothness = _Smoothness;
			o.Occlusion = occl;
			o.Alpha = _Color.a;
			#ifdef CUBE
			o.Emission = (texCUBE(_Cube, mul(_CubeRot, WorldReflectionVector(IN, o.Normal)).rgb) * _CubeIntensity * _CubeTint * fres);
			#endif
		}
		ENDCG
	}
	CustomEditor "CarPaintColor"
	FallBack "Reflective/Bumped Diffuse"
}