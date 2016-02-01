// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:False,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-5543-OUT,alpha-4059-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32257,y:32607,ptovrint:False,ptlb:CloudColour,ptin:_CloudColour,varname:_CloudColour,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_ComponentMask,id:4059,x:32330,y:32870,varname:node_4059,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-8147-OUT;n:type:ShaderForge.SFN_Multiply,id:8147,x:32215,y:33093,varname:node_8147,prsc:2|A-3886-RGB,B-228-OUT;n:type:ShaderForge.SFN_Tex2d,id:3886,x:32031,y:32713,ptovrint:False,ptlb:MainClouds,ptin:_MainClouds,varname:_MainClouds,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:44207acab53034a45967ff7c563ae831,ntxv:0,isnm:False|UVIN-3817-OUT;n:type:ShaderForge.SFN_TexCoord,id:3943,x:31661,y:32769,varname:node_3943,prsc:2,uv:0;n:type:ShaderForge.SFN_ValueProperty,id:4421,x:31252,y:32530,ptovrint:False,ptlb:CloudSpeed,ptin:_CloudSpeed,varname:_CloudSpeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.2;n:type:ShaderForge.SFN_Multiply,id:228,x:32008,y:33048,varname:node_228,prsc:2|A-9-OUT,B-6933-OUT;n:type:ShaderForge.SFN_Multiply,id:6933,x:31910,y:33252,varname:node_6933,prsc:2|A-6372-OUT,B-9413-OUT;n:type:ShaderForge.SFN_Vector1,id:6372,x:31702,y:33252,varname:node_6372,prsc:2,v1:10;n:type:ShaderForge.SFN_Slider,id:9413,x:31519,y:33340,ptovrint:False,ptlb:Density,ptin:_Density,varname:_Density,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.204582,max:1;n:type:ShaderForge.SFN_Multiply,id:8818,x:31686,y:32976,varname:node_8818,prsc:2|A-4441-OUT,B-4899-OUT;n:type:ShaderForge.SFN_Slider,id:4441,x:31321,y:32973,ptovrint:False,ptlb:MaskDensity,ptin:_MaskDensity,varname:_MaskDensity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2056734,max:1;n:type:ShaderForge.SFN_Vector1,id:4899,x:31399,y:33063,varname:node_4899,prsc:2,v1:10;n:type:ShaderForge.SFN_Multiply,id:9,x:31822,y:33104,varname:node_9,prsc:2|A-8818-OUT,B-8316-RGB;n:type:ShaderForge.SFN_Tex2d,id:8316,x:31543,y:33147,ptovrint:False,ptlb:CloudMask1,ptin:_CloudMask1,varname:_CloudMask1,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:534b6dfa8427b6642bdb45dd81cc428f,ntxv:0,isnm:False|UVIN-5806-OUT;n:type:ShaderForge.SFN_TexCoord,id:8884,x:31116,y:33367,varname:node_8884,prsc:2,uv:0;n:type:ShaderForge.SFN_ValueProperty,id:4009,x:30862,y:33091,ptovrint:False,ptlb:MaskSpeed,ptin:_MaskSpeed,varname:_MaskSpeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-0.01;n:type:ShaderForge.SFN_Blend,id:5543,x:32490,y:32729,varname:node_5543,prsc:2,blmd:1,clmp:True|SRC-7241-RGB,DST-4059-OUT;n:type:ShaderForge.SFN_Append,id:8547,x:31586,y:32556,varname:node_8547,prsc:2|A-2154-OUT,B-7738-OUT;n:type:ShaderForge.SFN_Vector1,id:7738,x:31231,y:32644,varname:node_7738,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:2759,x:30885,y:33166,varname:node_2759,prsc:2,v1:0;n:type:ShaderForge.SFN_Append,id:2548,x:31074,y:33073,varname:node_2548,prsc:2|A-2759-OUT,B-4009-OUT;n:type:ShaderForge.SFN_Multiply,id:4361,x:31216,y:33136,varname:node_4361,prsc:2|A-2548-OUT,B-1779-T;n:type:ShaderForge.SFN_Time,id:1779,x:30977,y:33259,varname:node_1779,prsc:2;n:type:ShaderForge.SFN_Add,id:5806,x:31348,y:33244,varname:node_5806,prsc:2|A-4361-OUT,B-8884-UVOUT;n:type:ShaderForge.SFN_Add,id:3817,x:31836,y:32693,varname:node_3817,prsc:2|A-8547-OUT,B-3943-UVOUT;n:type:ShaderForge.SFN_ValueProperty,id:2154,x:31286,y:32767,ptovrint:False,ptlb:time,ptin:_time,varname:node_2154,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;proporder:7241-3886-4421-9413-4441-8316-4009-2154;pass:END;sub:END;*/

Shader "Shader Forge/NewShader" {
    Properties {
        _CloudColour ("CloudColour", Color) = (1,0.3921569,0.7843137,1)
        _MainClouds ("MainClouds", 2D) = "white" {}
        _CloudSpeed ("CloudSpeed", Float ) = 0.2
        _Density ("Density", Range(0, 1)) = 0.204582
        _MaskDensity ("MaskDensity", Range(0, 1)) = 0.2056734
        _CloudMask1 ("CloudMask1", 2D) = "white" {}
        _MaskSpeed ("MaskSpeed", Float ) = -0.01
        _time ("time", Float ) = 0.1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers metal d3d11_9x xbox360 xboxone ps3 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _CloudColour;
            uniform sampler2D _MainClouds; uniform float4 _MainClouds_ST;
            uniform float _Density;
            uniform float _MaskDensity;
            uniform sampler2D _CloudMask1; uniform float4 _CloudMask1_ST;
            uniform float _MaskSpeed;
            uniform float _time;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float2 node_8547 = float2(_time,0.0);
                float2 node_3817 = (node_8547+i.uv0);
                float4 _MainClouds_var = tex2D(_MainClouds,TRANSFORM_TEX(node_3817, _MainClouds));
                float4 node_1779 = _Time + _TimeEditor;
                float2 node_5806 = ((float2(0.0,_MaskSpeed)*node_1779.g)+i.uv0);
                float4 _CloudMask1_var = tex2D(_CloudMask1,TRANSFORM_TEX(node_5806, _CloudMask1));
                float node_4059 = (_MainClouds_var.rgb*(((_MaskDensity*10.0)*_CloudMask1_var.rgb)*(10.0*_Density))).r;
                float3 emissive = saturate((_CloudColour.rgb*node_4059));
                float3 finalColor = emissive;
                return fixed4(finalColor,node_4059);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
