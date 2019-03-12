﻿Shader "DM/Ripple Shader" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Texture", 2D) = "white" {}
        _Scale ("Scale", Range(0.5,500.0)) = 3.0
        _Speed ("Speed", Range(-50,50.0)) = 1.0
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200
        Cull Off
        CGPROGRAM
        #pragma surface surf Lambert
		#pragma vertex vert
        #include "UnityCG.cginc"
        
        half4 _Color;
        half _Scale;
        half _Speed;
        sampler2D _MainTex;
        
        struct Input {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o) {
            half2 uv = (IN.uv_MainTex - 0.5) * _Scale;
            half r = sqrt (uv.x*uv.x + uv.y*uv.y);
            half z = cos (r+_Time[1]*_Speed) / r;
            o.Albedo = _Color.rgb * tex2D (_MainTex, IN.uv_MainTex+z).rgb;
            o.Alpha = _Color.a;
            o.Normal = (z, z, z);
        }

		void vert (inout appdata_full v, out Input o) {
        UNITY_INITIALIZE_OUTPUT(Input, o);

        half offsetvert = ((v.vertex.x * v.vertex.x) + (v.vertex.z * v.vertex.z));
        half value = _Scale * sin(_Time.w * _Speed + offsetvert * _Frequency);

        v.vertex.y += value;
        o.customValue = value;
		}
        ENDCG
    } 
    FallBack "Diffuse"
}