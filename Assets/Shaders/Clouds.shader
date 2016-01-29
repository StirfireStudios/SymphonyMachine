// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:2,spmd:1,trmd:1,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:1,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:6,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:14,ufog:False,aust:False,igpj:False,qofs:0,qpre:3,rntp:5,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32924,y:32462,varname:node_3138,prsc:2|diff-5398-RGB,alpha-1447-OUT;n:type:ShaderForge.SFN_Tex2d,id:5398,x:32153,y:32576,ptovrint:False,ptlb:MainClouds,ptin:_MainClouds,varname:node_5398,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:44207acab53034a45967ff7c563ae831,ntxv:0,isnm:False|UVIN-510-OUT;n:type:ShaderForge.SFN_Tex2d,id:4826,x:32159,y:33068,ptovrint:False,ptlb:CloudMask1,ptin:_CloudMask1,varname:node_4826,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:534b6dfa8427b6642bdb45dd81cc428f,ntxv:0,isnm:False|UVIN-6854-OUT;n:type:ShaderForge.SFN_TexCoord,id:6276,x:31681,y:32789,varname:node_6276,prsc:2,uv:0;n:type:ShaderForge.SFN_Time,id:3964,x:31437,y:32680,varname:node_3964,prsc:2;n:type:ShaderForge.SFN_Add,id:510,x:31961,y:32681,varname:node_510,prsc:2|A-7045-OUT,B-6276-UVOUT;n:type:ShaderForge.SFN_Multiply,id:7045,x:31810,y:32559,varname:node_7045,prsc:2|A-6119-OUT,B-3964-T;n:type:ShaderForge.SFN_Vector1,id:2870,x:31463,y:32405,varname:node_2870,prsc:2,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:6489,x:31437,y:32511,ptovrint:False,ptlb:CloudSpeed,ptin:_CloudSpeed,varname:node_6489,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.01;n:type:ShaderForge.SFN_Append,id:6119,x:31607,y:32487,varname:node_6119,prsc:2|A-2870-OUT,B-6489-OUT;n:type:ShaderForge.SFN_ComponentMask,id:1447,x:32498,y:32753,varname:node_1447,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-940-OUT;n:type:ShaderForge.SFN_Slider,id:2224,x:32229,y:33337,ptovrint:False,ptlb:Density,ptin:_Density,varname:node_2224,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.04249195,max:1;n:type:ShaderForge.SFN_Multiply,id:8064,x:32637,y:32999,varname:node_8064,prsc:2|A-7261-OUT,B-8440-OUT;n:type:ShaderForge.SFN_Multiply,id:940,x:32322,y:32702,varname:node_940,prsc:2|A-5398-RGB,B-8064-OUT;n:type:ShaderForge.SFN_Time,id:5185,x:31460,y:33106,varname:node_5185,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:5180,x:31460,y:32926,ptovrint:False,ptlb:MaskSpeed,ptin:_MaskSpeed,varname:node_5180,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-0.01;n:type:ShaderForge.SFN_Vector1,id:990,x:31460,y:33017,varname:node_990,prsc:2,v1:0;n:type:ShaderForge.SFN_Append,id:5287,x:31625,y:32948,varname:node_5287,prsc:2|A-5180-OUT,B-990-OUT;n:type:ShaderForge.SFN_Multiply,id:3686,x:31828,y:32948,varname:node_3686,prsc:2|A-5287-OUT,B-5185-T;n:type:ShaderForge.SFN_Add,id:6854,x:31911,y:33141,varname:node_6854,prsc:2|A-3686-OUT,B-7367-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:7367,x:31697,y:33174,varname:node_7367,prsc:2,uv:0;n:type:ShaderForge.SFN_Slider,id:8754,x:31923,y:32856,ptovrint:False,ptlb:MaskDensity,ptin:_MaskDensity,varname:node_8754,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.08523219,max:1;n:type:ShaderForge.SFN_Multiply,id:8440,x:32394,y:32963,varname:node_8440,prsc:2|A-989-OUT,B-4826-RGB;n:type:ShaderForge.SFN_Multiply,id:989,x:32221,y:32918,varname:node_989,prsc:2|A-8754-OUT,B-1617-OUT;n:type:ShaderForge.SFN_Vector1,id:1617,x:32039,y:32962,varname:node_1617,prsc:2,v1:10;n:type:ShaderForge.SFN_Vector1,id:6483,x:32337,y:33126,varname:node_6483,prsc:2,v1:10;n:type:ShaderForge.SFN_Multiply,id:7261,x:32528,y:33164,varname:node_7261,prsc:2|A-6483-OUT,B-2224-OUT;proporder:5398-6489-4826-2224-5180-8754;pass:END;sub:END;*/

Shader "Shader Forge/Clouds" {
    Properties {
        _MainClouds ("MainClouds", 2D) = "white" {}
        _CloudSpeed ("CloudSpeed", Float ) = 0.01
        _CloudMask1 ("CloudMask1", 2D) = "white" {}
        _Density ("Density", Range(0, 1)) = 0.04249195
        _MaskSpeed ("MaskSpeed", Float ) = -0.01
        _MaskDensity ("MaskDensity", Range(0, 1)) = 0.08523219
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="Transparent"
            "RenderType"="Overlay"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcColor
            
            ColorMask RGB
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _MainClouds; uniform float4 _MainClouds_ST;
            uniform sampler2D _CloudMask1; uniform float4 _CloudMask1_ST;
            uniform float _CloudSpeed;
            uniform float _Density;
            uniform float _MaskSpeed;
            uniform float _MaskDensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 node_3964 = _Time + _TimeEditor;
                float2 node_510 = ((float2(0.0,_CloudSpeed)*node_3964.g)+i.uv0);
                float4 _MainClouds_var = tex2D(_MainClouds,TRANSFORM_TEX(node_510, _MainClouds));
                float3 diffuseColor = _MainClouds_var.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float4 node_5185 = _Time + _TimeEditor;
                float2 node_6854 = ((float2(_MaskSpeed,0.0)*node_5185.g)+i.uv0);
                float4 _CloudMask1_var = tex2D(_CloudMask1,TRANSFORM_TEX(node_6854, _CloudMask1));
                float3 finalColor = diffuse * (_MainClouds_var.rgb*((10.0*_Density)*((_MaskDensity*10.0)*_CloudMask1_var.rgb))).r;
                return fixed4(finalColor,(_MainClouds_var.rgb*((10.0*_Density)*((_MaskDensity*10.0)*_CloudMask1_var.rgb))).r);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
