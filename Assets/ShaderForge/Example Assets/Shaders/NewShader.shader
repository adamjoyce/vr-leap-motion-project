// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:32721,y:32830,varname:node_4013,prsc:2|diff-9957-OUT,normal-7260-OUT,voffset-958-OUT,disp-958-OUT,tess-3519-OUT;n:type:ShaderForge.SFN_Tex2d,id:9510,x:32990,y:32654,ptovrint:False,ptlb:node_9510,ptin:_node_9510,varname:node_9510,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b46c4a1f33d7d77478f004b971cdf961,ntxv:0,isnm:False|UVIN-7475-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:9708,x:32990,y:32454,ptovrint:False,ptlb:node_9708,ptin:_node_9708,varname:node_9708,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:30764f9fea01ec0419cd2550998ddc06,ntxv:0,isnm:False|UVIN-7475-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:9111,x:33181,y:32454,ptovrint:False,ptlb:node_9111,ptin:_node_9111,varname:node_9111,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:aa3e1a96b89e99d4988b0568df026ad8,ntxv:0,isnm:False|UVIN-7475-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:565,x:33181,y:32654,ptovrint:False,ptlb:ccc,ptin:_ccc,varname:node_565,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d34e5b146a3b69a41b5183ecba4a81c5,ntxv:0,isnm:False|UVIN-7475-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:6467,x:33349,y:32454,ptovrint:False,ptlb:node_6467,ptin:_node_6467,varname:node_6467,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:7d860df0f08b738438fbed785cbe5015,ntxv:3,isnm:True|UVIN-7475-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:7642,x:33317,y:32654,ptovrint:False,ptlb:node_7642,ptin:_node_7642,varname:node_7642,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d4df9cd9aa7fb9e49ae1f5ef0c4687a9,ntxv:3,isnm:True|UVIN-7475-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:5416,x:32528,y:32517,varname:node_5416,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:7475,x:32737,y:32517,varname:node_7475,prsc:2,spu:0.001,spv:0|UVIN-5416-UVOUT;n:type:ShaderForge.SFN_NormalVector,id:6686,x:32971,y:32984,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:958,x:33140,y:33187,varname:node_958,prsc:2|A-6256-OUT,B-6686-OUT;n:type:ShaderForge.SFN_Lerp,id:9957,x:32990,y:32846,varname:node_9957,prsc:2|A-4141-OUT,B-7087-OUT,T-2223-OUT;n:type:ShaderForge.SFN_Lerp,id:6256,x:33181,y:32846,varname:node_6256,prsc:2|A-565-RGB,B-9111-RGB,T-2223-OUT;n:type:ShaderForge.SFN_Lerp,id:7260,x:33349,y:32846,varname:node_7260,prsc:2|A-7642-RGB,B-6467-RGB,T-2223-OUT;n:type:ShaderForge.SFN_Slider,id:2223,x:32599,y:32722,ptovrint:False,ptlb:node_2223,ptin:_node_2223,varname:node_2223,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:3519,x:32354,y:32957,ptovrint:False,ptlb:node_3519,ptin:_node_3519,varname:node_3519,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:4.280783,max:32;n:type:ShaderForge.SFN_Color,id:9985,x:32607,y:32145,ptovrint:False,ptlb:node_9985,ptin:_node_9985,varname:node_9985,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:7087,x:32908,y:32212,varname:node_7087,prsc:2|A-9985-RGB,B-9708-RGB;n:type:ShaderForge.SFN_Multiply,id:4141,x:32619,y:32300,varname:node_4141,prsc:2|A-9985-RGB,B-9510-RGB;proporder:6467-7642-2223-3519-9111-565-9510-9708-9610-9985;pass:END;sub:END;*/

Shader "Shader Forge/NewShader" {
    Properties {
        _node_6467 ("node_6467", 2D) = "bump" {}
        _node_7642 ("node_7642", 2D) = "bump" {}
        _node_2223 ("node_2223", Range(0, 1)) = 1
        _node_3519 ("node_3519", Range(0, 32)) = 4.280783
        _node_9111 ("node_9111", 2D) = "white" {}
        _ccc ("ccc", 2D) = "white" {}
        _node_9510 ("node_9510", 2D) = "white" {}
        _node_9708 ("node_9708", 2D) = "white" {}
        _node_9610 ("node_9610", Range(0, 1)) = 0
        _node_9985 ("node_9985", Color) = (1,0,0,1)
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
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Tessellation.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 5.0
            #pragma glsl
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _node_9510; uniform float4 _node_9510_ST;
            uniform sampler2D _node_9708; uniform float4 _node_9708_ST;
            uniform sampler2D _node_9111; uniform float4 _node_9111_ST;
            uniform sampler2D _ccc; uniform float4 _ccc_ST;
            uniform sampler2D _node_6467; uniform float4 _node_6467_ST;
            uniform sampler2D _node_7642; uniform float4 _node_7642_ST;
            uniform float _node_2223;
            uniform float _node_3519;
            uniform float4 _node_9985;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_8168 = _Time + _TimeEditor;
                float2 node_7475 = (o.uv0+node_8168.g*float2(0.001,0));
                float4 _ccc_var = tex2Dlod(_ccc,float4(TRANSFORM_TEX(node_7475, _ccc),0.0,0));
                float4 _node_9111_var = tex2Dlod(_node_9111,float4(TRANSFORM_TEX(node_7475, _node_9111),0.0,0));
                v.vertex.xyz += (lerp(_ccc_var.rgb,_node_9111_var.rgb,_node_2223)*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                void displacement (inout VertexInput v){
                    float4 node_8168 = _Time + _TimeEditor;
                    float2 node_7475 = (v.texcoord0+node_8168.g*float2(0.001,0));
                    float4 _ccc_var = tex2Dlod(_ccc,float4(TRANSFORM_TEX(node_7475, _ccc),0.0,0));
                    float4 _node_9111_var = tex2Dlod(_node_9111,float4(TRANSFORM_TEX(node_7475, _node_9111),0.0,0));
                    v.vertex.xyz += (lerp(_ccc_var.rgb,_node_9111_var.rgb,_node_2223)*v.normal);
                }
                float Tessellation(TessVertex v){
                    return _node_3519;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    displacement(v);
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_8168 = _Time + _TimeEditor;
                float2 node_7475 = (i.uv0+node_8168.g*float2(0.001,0));
                float3 _node_7642_var = UnpackNormal(tex2D(_node_7642,TRANSFORM_TEX(node_7475, _node_7642)));
                float3 _node_6467_var = UnpackNormal(tex2D(_node_6467,TRANSFORM_TEX(node_7475, _node_6467)));
                float3 normalLocal = lerp(_node_7642_var.rgb,_node_6467_var.rgb,_node_2223);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
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
                float4 _node_9510_var = tex2D(_node_9510,TRANSFORM_TEX(node_7475, _node_9510));
                float4 _node_9708_var = tex2D(_node_9708,TRANSFORM_TEX(node_7475, _node_9708));
                float3 diffuseColor = lerp((_node_9985.rgb*_node_9510_var.rgb),(_node_9985.rgb*_node_9708_var.rgb),_node_2223);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
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
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Tessellation.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 5.0
            #pragma glsl
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _node_9510; uniform float4 _node_9510_ST;
            uniform sampler2D _node_9708; uniform float4 _node_9708_ST;
            uniform sampler2D _node_9111; uniform float4 _node_9111_ST;
            uniform sampler2D _ccc; uniform float4 _ccc_ST;
            uniform sampler2D _node_6467; uniform float4 _node_6467_ST;
            uniform sampler2D _node_7642; uniform float4 _node_7642_ST;
            uniform float _node_2223;
            uniform float _node_3519;
            uniform float4 _node_9985;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_9153 = _Time + _TimeEditor;
                float2 node_7475 = (o.uv0+node_9153.g*float2(0.001,0));
                float4 _ccc_var = tex2Dlod(_ccc,float4(TRANSFORM_TEX(node_7475, _ccc),0.0,0));
                float4 _node_9111_var = tex2Dlod(_node_9111,float4(TRANSFORM_TEX(node_7475, _node_9111),0.0,0));
                v.vertex.xyz += (lerp(_ccc_var.rgb,_node_9111_var.rgb,_node_2223)*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                void displacement (inout VertexInput v){
                    float4 node_9153 = _Time + _TimeEditor;
                    float2 node_7475 = (v.texcoord0+node_9153.g*float2(0.001,0));
                    float4 _ccc_var = tex2Dlod(_ccc,float4(TRANSFORM_TEX(node_7475, _ccc),0.0,0));
                    float4 _node_9111_var = tex2Dlod(_node_9111,float4(TRANSFORM_TEX(node_7475, _node_9111),0.0,0));
                    v.vertex.xyz += (lerp(_ccc_var.rgb,_node_9111_var.rgb,_node_2223)*v.normal);
                }
                float Tessellation(TessVertex v){
                    return _node_3519;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    displacement(v);
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_9153 = _Time + _TimeEditor;
                float2 node_7475 = (i.uv0+node_9153.g*float2(0.001,0));
                float3 _node_7642_var = UnpackNormal(tex2D(_node_7642,TRANSFORM_TEX(node_7475, _node_7642)));
                float3 _node_6467_var = UnpackNormal(tex2D(_node_6467,TRANSFORM_TEX(node_7475, _node_6467)));
                float3 normalLocal = lerp(_node_7642_var.rgb,_node_6467_var.rgb,_node_2223);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _node_9510_var = tex2D(_node_9510,TRANSFORM_TEX(node_7475, _node_9510));
                float4 _node_9708_var = tex2D(_node_9708,TRANSFORM_TEX(node_7475, _node_9708));
                float3 diffuseColor = lerp((_node_9985.rgb*_node_9510_var.rgb),(_node_9985.rgb*_node_9708_var.rgb),_node_2223);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
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
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 5.0
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform sampler2D _node_9111; uniform float4 _node_9111_ST;
            uniform sampler2D _ccc; uniform float4 _ccc_ST;
            uniform float _node_2223;
            uniform float _node_3519;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_4247 = _Time + _TimeEditor;
                float2 node_7475 = (o.uv0+node_4247.g*float2(0.001,0));
                float4 _ccc_var = tex2Dlod(_ccc,float4(TRANSFORM_TEX(node_7475, _ccc),0.0,0));
                float4 _node_9111_var = tex2Dlod(_node_9111,float4(TRANSFORM_TEX(node_7475, _node_9111),0.0,0));
                v.vertex.xyz += (lerp(_ccc_var.rgb,_node_9111_var.rgb,_node_2223)*v.normal);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                void displacement (inout VertexInput v){
                    float4 node_4247 = _Time + _TimeEditor;
                    float2 node_7475 = (v.texcoord0+node_4247.g*float2(0.001,0));
                    float4 _ccc_var = tex2Dlod(_ccc,float4(TRANSFORM_TEX(node_7475, _ccc),0.0,0));
                    float4 _node_9111_var = tex2Dlod(_node_9111,float4(TRANSFORM_TEX(node_7475, _node_9111),0.0,0));
                    v.vertex.xyz += (lerp(_ccc_var.rgb,_node_9111_var.rgb,_node_2223)*v.normal);
                }
                float Tessellation(TessVertex v){
                    return _node_3519;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    displacement(v);
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
