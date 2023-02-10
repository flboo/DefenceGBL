Shader "Custom/SelfAlpha" {
	// Unlit alpha-cutout shader.
	// - no lighting
	// - no lightmap support
	// - no per-material color
	Properties {
		//_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
		_Color ("Color Tint", Color) = (1,1,1,1)
		_MainTex ("SelfIllum Color (RGB) Alpha (A)", 2D) = "white"
	}

	SubShader {
		Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
		LOD 100
		
		Material {
           Emission [_Color]
        }
            
		Pass {
			Lighting On
			Alphatest Greater [_Cutoff]
			SetTexture [_MainTex] {
                  Combine Texture * Primary, Texture * Primary
            }
		}
	}
}
