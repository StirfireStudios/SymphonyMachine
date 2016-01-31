// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33294,y:32804,varname:node_4013,prsc:2|diff-5641-RGB,spec-1575-OUT,gloss-5558-OUT,voffset-3099-OUT;n:type:ShaderForge.SFN_Sin,id:4562,x:32206,y:33187,varname:node_4562,prsc:2|IN-6238-OUT;n:type:ShaderForge.SFN_Time,id:3341,x:31759,y:33224,varname:node_3341,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5967,x:31993,y:33166,varname:node_5967,prsc:2|A-7014-OUT,B-3341-T;n:type:ShaderForge.SFN_ValueProperty,id:7014,x:31702,y:33145,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:node_7014,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:10;n:type:ShaderForge.SFN_FragmentPosition,id:1882,x:31772,y:32910,varname:node_1882,prsc:2;n:type:ShaderForge.SFN_Add,id:6238,x:32022,y:32962,varname:node_6238,prsc:2|A-1882-X,B-5967-OUT;n:type:ShaderForge.SFN_RemapRange,id:8677,x:32339,y:32850,varname:node_8677,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-4562-OUT;n:type:ShaderForge.SFN_Multiply,id:3449,x:32436,y:33276,varname:node_3449,prsc:2|A-4562-OUT,B-6026-OUT;n:type:ShaderForge.SFN_ComponentMask,id:318,x:32638,y:33191,varname:node_318,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-3449-OUT;n:type:ShaderForge.SFN_Multiply,id:2141,x:32813,y:33132,varname:node_2141,prsc:2|A-855-G,B-318-OUT;n:type:ShaderForge.SFN_VertexColor,id:855,x:32638,y:32993,varname:node_855,prsc:2;n:type:ShaderForge.SFN_Vector3,id:8946,x:32777,y:33450,varname:node_8946,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Multiply,id:3099,x:33016,y:33207,varname:node_3099,prsc:2|A-2141-OUT,B-8946-OUT;n:type:ShaderForge.SFN_Tex2d,id:5641,x:32943,y:32568,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_5641,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:1575,x:32865,y:32842,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:node_1575,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:5558,x:32865,y:32934,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_5558,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_ValueProperty,id:6026,x:32246,y:33392,ptovrint:False,ptlb:Scale,ptin:_Scale,varname:node_6026,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ArcSin,id:5220,x:32310,y:33574,varname:node_5220,prsc:2;proporder:7014-5641-1575-5558-6026;pass:END;sub:END;*/

Shader "GGJ2016/Leaves" {
    Properties {
        _Speed ("Speed", Float ) = 10
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Specular ("Specular", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0
        _Scale ("Scale", Float ) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float _Speed;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _Specular;
            uniform float _Gloss;
            uniform float _Scale;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_3341 = _Time + _TimeEditor;
                float node_4562 = sin((mul(_Object2World, v.vertex).r+(_Speed*node_3341.g)));
                v.vertex.xyz += ((o.vertexColor.g*(node_4562*_Scale).r)*float3(0,0,1));
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_Specular,_Specular,_Specular);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuseColor = _Diffuse_var.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float _Speed;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _Specular;
            uniform float _Gloss;
            uniform float _Scale;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_3341 = _Time + _TimeEditor;
                float node_4562 = sin((mul(_Object2World, v.vertex).r+(_Speed*node_3341.g)));
                v.vertex.xyz += ((o.vertexColor.g*(node_4562*_Scale).r)*float3(0,0,1));
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_Specular,_Specular,_Specular);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuseColor = _Diffuse_var.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Speed;
            uniform float _Scale;
            struct VertexInput {
                float4 vertex : POSITION;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float4 posWorld : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.vertexColor = v.vertexColor;
                float4 node_3341 = _Time + _TimeEditor;
                float node_4562 = sin((mul(_Object2World, v.vertex).r+(_Speed*node_3341.g)));
                v.vertex.xyz += ((o.vertexColor.g*(node_4562*_Scale).r)*float3(0,0,1));
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
