#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <cstring>
#include <string.h>
#include <stdio.h>
#include <cmath>
#include <limits>
#include <assert.h>
#include <stdint.h>

#include "class-internals.h"
#include "codegen/il2cpp-codegen.h"
#include "object-internals.h"

// UnityEngine.MeshCollider
struct MeshCollider_t2718867283;
// UnityEngine.MeshFilter
struct MeshFilter_t3026937449;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// System.Collections.Generic.Dictionary`2<System.String,UnityEngine.XR.iOS.ARPlaneAnchorGameObject>
struct Dictionary_2_t4220005149;
// System.Void
struct Void_t1841601450;
// System.Char[]
struct CharU5BU5D_t1328083999;
// System.String
struct String_t;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// System.DelegateData
struct DelegateData_t1572802995;
// UnityEngine.Vector3[]
struct Vector3U5BU5D_t1172311765;
// System.IAsyncResult
struct IAsyncResult_t1999651008;
// System.AsyncCallback
struct AsyncCallback_t163412349;
// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARFrameUpdate
struct ARFrameUpdate_t496507918;
// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARAnchorAdded
struct ARAnchorAdded_t2646854145;
// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARAnchorUpdated
struct ARAnchorUpdated_t3886071158;
// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARAnchorRemoved
struct ARAnchorRemoved_t142665927;
// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARUserAnchorAdded
struct ARUserAnchorAdded_t4216008690;
// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARUserAnchorUpdated
struct ARUserAnchorUpdated_t1104644293;
// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARUserAnchorRemoved
struct ARUserAnchorRemoved_t1656212632;
// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARSessionFailed
struct ARSessionFailed_t872580813;
// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARSessionCallback
struct ARSessionCallback_t3370800699;
// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARSessionTrackingChanged
struct ARSessionTrackingChanged_t1333006279;
// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARFrameUpdate
struct internal_ARFrameUpdate_t3296518558;
// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARSessionTrackingChanged
struct internal_ARSessionTrackingChanged_t1558153491;
// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARAnchorAdded
struct internal_ARAnchorAdded_t1622117597;
// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARAnchorUpdated
struct internal_ARAnchorUpdated_t3705772742;
// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARAnchorRemoved
struct internal_ARAnchorRemoved_t3189755211;
// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARUserAnchorAdded
struct internal_ARUserAnchorAdded_t3999066834;
// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARUserAnchorUpdated
struct internal_ARUserAnchorUpdated_t1661963345;
// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARUserAnchorRemoved
struct internal_ARUserAnchorRemoved_t4166385952;
// UnityEngine.Camera
struct Camera_t189460977;
// UnityEngine.XR.iOS.UnityARSessionNativeInterface
struct UnityARSessionNativeInterface_t1130867170;
// UnityEngine.Material
struct Material_t193706927;
// UnityEngine.XR.iOS.UnityARAnchorManager
struct UnityARAnchorManager_t1086564192;
// UnityEngine.Transform
struct Transform_t3275118058;
// UnityEngine.XR.iOS.UnityARSessionRunOption[]
struct UnityARSessionRunOptionU5BU5D_t3114965901;
// UnityEngine.XR.iOS.UnityARAlignment[]
struct UnityARAlignmentU5BU5D_t218994990;
// UnityEngine.XR.iOS.UnityARPlaneDetection[]
struct UnityARPlaneDetectionU5BU5D_t191549612;
// UnityEngine.Rendering.CommandBuffer
struct CommandBuffer_t1204166949;
// UnityEngine.Texture2D
struct Texture2D_t3542995729;
// System.Collections.Generic.List`1<UnityEngine.GameObject>
struct List_1_t1125654279;
// UnityEngine.Light
struct Light_t494725636;

struct Vector3_t2243707580 ;



#ifndef RUNTIMEOBJECT_H
#define RUNTIMEOBJECT_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Object

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // RUNTIMEOBJECT_H
#ifndef UNITYARUTILITY_T3608388148_H
#define UNITYARUTILITY_T3608388148_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARUtility
struct  UnityARUtility_t3608388148  : public RuntimeObject
{
public:
	// UnityEngine.MeshCollider UnityEngine.XR.iOS.UnityARUtility::meshCollider
	MeshCollider_t2718867283 * ___meshCollider_0;
	// UnityEngine.MeshFilter UnityEngine.XR.iOS.UnityARUtility::meshFilter
	MeshFilter_t3026937449 * ___meshFilter_1;

public:
	inline static int32_t get_offset_of_meshCollider_0() { return static_cast<int32_t>(offsetof(UnityARUtility_t3608388148, ___meshCollider_0)); }
	inline MeshCollider_t2718867283 * get_meshCollider_0() const { return ___meshCollider_0; }
	inline MeshCollider_t2718867283 ** get_address_of_meshCollider_0() { return &___meshCollider_0; }
	inline void set_meshCollider_0(MeshCollider_t2718867283 * value)
	{
		___meshCollider_0 = value;
		Il2CppCodeGenWriteBarrier((&___meshCollider_0), value);
	}

	inline static int32_t get_offset_of_meshFilter_1() { return static_cast<int32_t>(offsetof(UnityARUtility_t3608388148, ___meshFilter_1)); }
	inline MeshFilter_t3026937449 * get_meshFilter_1() const { return ___meshFilter_1; }
	inline MeshFilter_t3026937449 ** get_address_of_meshFilter_1() { return &___meshFilter_1; }
	inline void set_meshFilter_1(MeshFilter_t3026937449 * value)
	{
		___meshFilter_1 = value;
		Il2CppCodeGenWriteBarrier((&___meshFilter_1), value);
	}
};

struct UnityARUtility_t3608388148_StaticFields
{
public:
	// UnityEngine.GameObject UnityEngine.XR.iOS.UnityARUtility::planePrefab
	GameObject_t1756533147 * ___planePrefab_2;

public:
	inline static int32_t get_offset_of_planePrefab_2() { return static_cast<int32_t>(offsetof(UnityARUtility_t3608388148_StaticFields, ___planePrefab_2)); }
	inline GameObject_t1756533147 * get_planePrefab_2() const { return ___planePrefab_2; }
	inline GameObject_t1756533147 ** get_address_of_planePrefab_2() { return &___planePrefab_2; }
	inline void set_planePrefab_2(GameObject_t1756533147 * value)
	{
		___planePrefab_2 = value;
		Il2CppCodeGenWriteBarrier((&___planePrefab_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYARUTILITY_T3608388148_H
#ifndef VALUETYPE_T3507792607_H
#define VALUETYPE_T3507792607_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ValueType
struct  ValueType_t3507792607  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t3507792607_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t3507792607_marshaled_com
{
};
#endif // VALUETYPE_T3507792607_H
#ifndef UNITYARMATRIXOPS_T4039665643_H
#define UNITYARMATRIXOPS_T4039665643_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARMatrixOps
struct  UnityARMatrixOps_t4039665643  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYARMATRIXOPS_T4039665643_H
#ifndef UNITYARANCHORMANAGER_T1086564192_H
#define UNITYARANCHORMANAGER_T1086564192_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARAnchorManager
struct  UnityARAnchorManager_t1086564192  : public RuntimeObject
{
public:
	// System.Collections.Generic.Dictionary`2<System.String,UnityEngine.XR.iOS.ARPlaneAnchorGameObject> UnityEngine.XR.iOS.UnityARAnchorManager::planeAnchorMap
	Dictionary_2_t4220005149 * ___planeAnchorMap_0;

public:
	inline static int32_t get_offset_of_planeAnchorMap_0() { return static_cast<int32_t>(offsetof(UnityARAnchorManager_t1086564192, ___planeAnchorMap_0)); }
	inline Dictionary_2_t4220005149 * get_planeAnchorMap_0() const { return ___planeAnchorMap_0; }
	inline Dictionary_2_t4220005149 ** get_address_of_planeAnchorMap_0() { return &___planeAnchorMap_0; }
	inline void set_planeAnchorMap_0(Dictionary_2_t4220005149 * value)
	{
		___planeAnchorMap_0 = value;
		Il2CppCodeGenWriteBarrier((&___planeAnchorMap_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYARANCHORMANAGER_T1086564192_H
#ifndef INTPTR_T_H
#define INTPTR_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.IntPtr
struct  IntPtr_t 
{
public:
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(IntPtr_t, ___m_value_0)); }
	inline void* get_m_value_0() const { return ___m_value_0; }
	inline void** get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(void* value)
	{
		___m_value_0 = value;
	}
};

struct IntPtr_t_StaticFields
{
public:
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;

public:
	inline static int32_t get_offset_of_Zero_1() { return static_cast<int32_t>(offsetof(IntPtr_t_StaticFields, ___Zero_1)); }
	inline intptr_t get_Zero_1() const { return ___Zero_1; }
	inline intptr_t* get_address_of_Zero_1() { return &___Zero_1; }
	inline void set_Zero_1(intptr_t value)
	{
		___Zero_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INTPTR_T_H
#ifndef VECTOR4_T2243707581_H
#define VECTOR4_T2243707581_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Vector4
struct  Vector4_t2243707581 
{
public:
	// System.Single UnityEngine.Vector4::x
	float ___x_1;
	// System.Single UnityEngine.Vector4::y
	float ___y_2;
	// System.Single UnityEngine.Vector4::z
	float ___z_3;
	// System.Single UnityEngine.Vector4::w
	float ___w_4;

public:
	inline static int32_t get_offset_of_x_1() { return static_cast<int32_t>(offsetof(Vector4_t2243707581, ___x_1)); }
	inline float get_x_1() const { return ___x_1; }
	inline float* get_address_of_x_1() { return &___x_1; }
	inline void set_x_1(float value)
	{
		___x_1 = value;
	}

	inline static int32_t get_offset_of_y_2() { return static_cast<int32_t>(offsetof(Vector4_t2243707581, ___y_2)); }
	inline float get_y_2() const { return ___y_2; }
	inline float* get_address_of_y_2() { return &___y_2; }
	inline void set_y_2(float value)
	{
		___y_2 = value;
	}

	inline static int32_t get_offset_of_z_3() { return static_cast<int32_t>(offsetof(Vector4_t2243707581, ___z_3)); }
	inline float get_z_3() const { return ___z_3; }
	inline float* get_address_of_z_3() { return &___z_3; }
	inline void set_z_3(float value)
	{
		___z_3 = value;
	}

	inline static int32_t get_offset_of_w_4() { return static_cast<int32_t>(offsetof(Vector4_t2243707581, ___w_4)); }
	inline float get_w_4() const { return ___w_4; }
	inline float* get_address_of_w_4() { return &___w_4; }
	inline void set_w_4(float value)
	{
		___w_4 = value;
	}
};

struct Vector4_t2243707581_StaticFields
{
public:
	// UnityEngine.Vector4 UnityEngine.Vector4::zeroVector
	Vector4_t2243707581  ___zeroVector_5;
	// UnityEngine.Vector4 UnityEngine.Vector4::oneVector
	Vector4_t2243707581  ___oneVector_6;
	// UnityEngine.Vector4 UnityEngine.Vector4::positiveInfinityVector
	Vector4_t2243707581  ___positiveInfinityVector_7;
	// UnityEngine.Vector4 UnityEngine.Vector4::negativeInfinityVector
	Vector4_t2243707581  ___negativeInfinityVector_8;

public:
	inline static int32_t get_offset_of_zeroVector_5() { return static_cast<int32_t>(offsetof(Vector4_t2243707581_StaticFields, ___zeroVector_5)); }
	inline Vector4_t2243707581  get_zeroVector_5() const { return ___zeroVector_5; }
	inline Vector4_t2243707581 * get_address_of_zeroVector_5() { return &___zeroVector_5; }
	inline void set_zeroVector_5(Vector4_t2243707581  value)
	{
		___zeroVector_5 = value;
	}

	inline static int32_t get_offset_of_oneVector_6() { return static_cast<int32_t>(offsetof(Vector4_t2243707581_StaticFields, ___oneVector_6)); }
	inline Vector4_t2243707581  get_oneVector_6() const { return ___oneVector_6; }
	inline Vector4_t2243707581 * get_address_of_oneVector_6() { return &___oneVector_6; }
	inline void set_oneVector_6(Vector4_t2243707581  value)
	{
		___oneVector_6 = value;
	}

	inline static int32_t get_offset_of_positiveInfinityVector_7() { return static_cast<int32_t>(offsetof(Vector4_t2243707581_StaticFields, ___positiveInfinityVector_7)); }
	inline Vector4_t2243707581  get_positiveInfinityVector_7() const { return ___positiveInfinityVector_7; }
	inline Vector4_t2243707581 * get_address_of_positiveInfinityVector_7() { return &___positiveInfinityVector_7; }
	inline void set_positiveInfinityVector_7(Vector4_t2243707581  value)
	{
		___positiveInfinityVector_7 = value;
	}

	inline static int32_t get_offset_of_negativeInfinityVector_8() { return static_cast<int32_t>(offsetof(Vector4_t2243707581_StaticFields, ___negativeInfinityVector_8)); }
	inline Vector4_t2243707581  get_negativeInfinityVector_8() const { return ___negativeInfinityVector_8; }
	inline Vector4_t2243707581 * get_address_of_negativeInfinityVector_8() { return &___negativeInfinityVector_8; }
	inline void set_negativeInfinityVector_8(Vector4_t2243707581  value)
	{
		___negativeInfinityVector_8 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // VECTOR4_T2243707581_H
#ifndef U24ARRAYTYPEU3D24_T762068664_H
#define U24ARRAYTYPEU3D24_T762068664_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <PrivateImplementationDetails>/$ArrayType=24
#pragma pack(push, tp, 1)
struct  U24ArrayTypeU3D24_t762068664 
{
public:
	union
	{
		struct
		{
		};
		uint8_t U24ArrayTypeU3D24_t762068664__padding[24];
	};

public:
};
#pragma pack(pop, tp)

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // U24ARRAYTYPEU3D24_T762068664_H
#ifndef ARSIZE_T3911821096_H
#define ARSIZE_T3911821096_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.ARSize
struct  ARSize_t3911821096 
{
public:
	// System.Double UnityEngine.XR.iOS.ARSize::width
	double ___width_0;
	// System.Double UnityEngine.XR.iOS.ARSize::height
	double ___height_1;

public:
	inline static int32_t get_offset_of_width_0() { return static_cast<int32_t>(offsetof(ARSize_t3911821096, ___width_0)); }
	inline double get_width_0() const { return ___width_0; }
	inline double* get_address_of_width_0() { return &___width_0; }
	inline void set_width_0(double value)
	{
		___width_0 = value;
	}

	inline static int32_t get_offset_of_height_1() { return static_cast<int32_t>(offsetof(ARSize_t3911821096, ___height_1)); }
	inline double get_height_1() const { return ___height_1; }
	inline double* get_address_of_height_1() { return &___height_1; }
	inline void set_height_1(double value)
	{
		___height_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARSIZE_T3911821096_H
#ifndef ARPOINT_T3436811567_H
#define ARPOINT_T3436811567_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.ARPoint
struct  ARPoint_t3436811567 
{
public:
	// System.Double UnityEngine.XR.iOS.ARPoint::x
	double ___x_0;
	// System.Double UnityEngine.XR.iOS.ARPoint::y
	double ___y_1;

public:
	inline static int32_t get_offset_of_x_0() { return static_cast<int32_t>(offsetof(ARPoint_t3436811567, ___x_0)); }
	inline double get_x_0() const { return ___x_0; }
	inline double* get_address_of_x_0() { return &___x_0; }
	inline void set_x_0(double value)
	{
		___x_0 = value;
	}

	inline static int32_t get_offset_of_y_1() { return static_cast<int32_t>(offsetof(ARPoint_t3436811567, ___y_1)); }
	inline double get_y_1() const { return ___y_1; }
	inline double* get_address_of_y_1() { return &___y_1; }
	inline void set_y_1(double value)
	{
		___y_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARPOINT_T3436811567_H
#ifndef ARLIGHTESTIMATE_T3477821059_H
#define ARLIGHTESTIMATE_T3477821059_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.ARLightEstimate
struct  ARLightEstimate_t3477821059 
{
public:
	// System.Double UnityEngine.XR.iOS.ARLightEstimate::ambientIntensity
	double ___ambientIntensity_0;

public:
	inline static int32_t get_offset_of_ambientIntensity_0() { return static_cast<int32_t>(offsetof(ARLightEstimate_t3477821059, ___ambientIntensity_0)); }
	inline double get_ambientIntensity_0() const { return ___ambientIntensity_0; }
	inline double* get_address_of_ambientIntensity_0() { return &___ambientIntensity_0; }
	inline void set_ambientIntensity_0(double value)
	{
		___ambientIntensity_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARLIGHTESTIMATE_T3477821059_H
#ifndef QUATERNION_T4030073918_H
#define QUATERNION_T4030073918_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Quaternion
struct  Quaternion_t4030073918 
{
public:
	// System.Single UnityEngine.Quaternion::x
	float ___x_0;
	// System.Single UnityEngine.Quaternion::y
	float ___y_1;
	// System.Single UnityEngine.Quaternion::z
	float ___z_2;
	// System.Single UnityEngine.Quaternion::w
	float ___w_3;

public:
	inline static int32_t get_offset_of_x_0() { return static_cast<int32_t>(offsetof(Quaternion_t4030073918, ___x_0)); }
	inline float get_x_0() const { return ___x_0; }
	inline float* get_address_of_x_0() { return &___x_0; }
	inline void set_x_0(float value)
	{
		___x_0 = value;
	}

	inline static int32_t get_offset_of_y_1() { return static_cast<int32_t>(offsetof(Quaternion_t4030073918, ___y_1)); }
	inline float get_y_1() const { return ___y_1; }
	inline float* get_address_of_y_1() { return &___y_1; }
	inline void set_y_1(float value)
	{
		___y_1 = value;
	}

	inline static int32_t get_offset_of_z_2() { return static_cast<int32_t>(offsetof(Quaternion_t4030073918, ___z_2)); }
	inline float get_z_2() const { return ___z_2; }
	inline float* get_address_of_z_2() { return &___z_2; }
	inline void set_z_2(float value)
	{
		___z_2 = value;
	}

	inline static int32_t get_offset_of_w_3() { return static_cast<int32_t>(offsetof(Quaternion_t4030073918, ___w_3)); }
	inline float get_w_3() const { return ___w_3; }
	inline float* get_address_of_w_3() { return &___w_3; }
	inline void set_w_3(float value)
	{
		___w_3 = value;
	}
};

struct Quaternion_t4030073918_StaticFields
{
public:
	// UnityEngine.Quaternion UnityEngine.Quaternion::identityQuaternion
	Quaternion_t4030073918  ___identityQuaternion_4;

public:
	inline static int32_t get_offset_of_identityQuaternion_4() { return static_cast<int32_t>(offsetof(Quaternion_t4030073918_StaticFields, ___identityQuaternion_4)); }
	inline Quaternion_t4030073918  get_identityQuaternion_4() const { return ___identityQuaternion_4; }
	inline Quaternion_t4030073918 * get_address_of_identityQuaternion_4() { return &___identityQuaternion_4; }
	inline void set_identityQuaternion_4(Quaternion_t4030073918  value)
	{
		___identityQuaternion_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // QUATERNION_T4030073918_H
#ifndef ENUM_T2459695545_H
#define ENUM_T2459695545_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Enum
struct  Enum_t2459695545  : public ValueType_t3507792607
{
public:

public:
};

struct Enum_t2459695545_StaticFields
{
public:
	// System.Char[] System.Enum::split_char
	CharU5BU5D_t1328083999* ___split_char_0;

public:
	inline static int32_t get_offset_of_split_char_0() { return static_cast<int32_t>(offsetof(Enum_t2459695545_StaticFields, ___split_char_0)); }
	inline CharU5BU5D_t1328083999* get_split_char_0() const { return ___split_char_0; }
	inline CharU5BU5D_t1328083999** get_address_of_split_char_0() { return &___split_char_0; }
	inline void set_split_char_0(CharU5BU5D_t1328083999* value)
	{
		___split_char_0 = value;
		Il2CppCodeGenWriteBarrier((&___split_char_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Enum
struct Enum_t2459695545_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.Enum
struct Enum_t2459695545_marshaled_com
{
};
#endif // ENUM_T2459695545_H
#ifndef VECTOR3_T2243707580_H
#define VECTOR3_T2243707580_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Vector3
struct  Vector3_t2243707580 
{
public:
	// System.Single UnityEngine.Vector3::x
	float ___x_1;
	// System.Single UnityEngine.Vector3::y
	float ___y_2;
	// System.Single UnityEngine.Vector3::z
	float ___z_3;

public:
	inline static int32_t get_offset_of_x_1() { return static_cast<int32_t>(offsetof(Vector3_t2243707580, ___x_1)); }
	inline float get_x_1() const { return ___x_1; }
	inline float* get_address_of_x_1() { return &___x_1; }
	inline void set_x_1(float value)
	{
		___x_1 = value;
	}

	inline static int32_t get_offset_of_y_2() { return static_cast<int32_t>(offsetof(Vector3_t2243707580, ___y_2)); }
	inline float get_y_2() const { return ___y_2; }
	inline float* get_address_of_y_2() { return &___y_2; }
	inline void set_y_2(float value)
	{
		___y_2 = value;
	}

	inline static int32_t get_offset_of_z_3() { return static_cast<int32_t>(offsetof(Vector3_t2243707580, ___z_3)); }
	inline float get_z_3() const { return ___z_3; }
	inline float* get_address_of_z_3() { return &___z_3; }
	inline void set_z_3(float value)
	{
		___z_3 = value;
	}
};

struct Vector3_t2243707580_StaticFields
{
public:
	// UnityEngine.Vector3 UnityEngine.Vector3::zeroVector
	Vector3_t2243707580  ___zeroVector_4;
	// UnityEngine.Vector3 UnityEngine.Vector3::oneVector
	Vector3_t2243707580  ___oneVector_5;
	// UnityEngine.Vector3 UnityEngine.Vector3::upVector
	Vector3_t2243707580  ___upVector_6;
	// UnityEngine.Vector3 UnityEngine.Vector3::downVector
	Vector3_t2243707580  ___downVector_7;
	// UnityEngine.Vector3 UnityEngine.Vector3::leftVector
	Vector3_t2243707580  ___leftVector_8;
	// UnityEngine.Vector3 UnityEngine.Vector3::rightVector
	Vector3_t2243707580  ___rightVector_9;
	// UnityEngine.Vector3 UnityEngine.Vector3::forwardVector
	Vector3_t2243707580  ___forwardVector_10;
	// UnityEngine.Vector3 UnityEngine.Vector3::backVector
	Vector3_t2243707580  ___backVector_11;
	// UnityEngine.Vector3 UnityEngine.Vector3::positiveInfinityVector
	Vector3_t2243707580  ___positiveInfinityVector_12;
	// UnityEngine.Vector3 UnityEngine.Vector3::negativeInfinityVector
	Vector3_t2243707580  ___negativeInfinityVector_13;

public:
	inline static int32_t get_offset_of_zeroVector_4() { return static_cast<int32_t>(offsetof(Vector3_t2243707580_StaticFields, ___zeroVector_4)); }
	inline Vector3_t2243707580  get_zeroVector_4() const { return ___zeroVector_4; }
	inline Vector3_t2243707580 * get_address_of_zeroVector_4() { return &___zeroVector_4; }
	inline void set_zeroVector_4(Vector3_t2243707580  value)
	{
		___zeroVector_4 = value;
	}

	inline static int32_t get_offset_of_oneVector_5() { return static_cast<int32_t>(offsetof(Vector3_t2243707580_StaticFields, ___oneVector_5)); }
	inline Vector3_t2243707580  get_oneVector_5() const { return ___oneVector_5; }
	inline Vector3_t2243707580 * get_address_of_oneVector_5() { return &___oneVector_5; }
	inline void set_oneVector_5(Vector3_t2243707580  value)
	{
		___oneVector_5 = value;
	}

	inline static int32_t get_offset_of_upVector_6() { return static_cast<int32_t>(offsetof(Vector3_t2243707580_StaticFields, ___upVector_6)); }
	inline Vector3_t2243707580  get_upVector_6() const { return ___upVector_6; }
	inline Vector3_t2243707580 * get_address_of_upVector_6() { return &___upVector_6; }
	inline void set_upVector_6(Vector3_t2243707580  value)
	{
		___upVector_6 = value;
	}

	inline static int32_t get_offset_of_downVector_7() { return static_cast<int32_t>(offsetof(Vector3_t2243707580_StaticFields, ___downVector_7)); }
	inline Vector3_t2243707580  get_downVector_7() const { return ___downVector_7; }
	inline Vector3_t2243707580 * get_address_of_downVector_7() { return &___downVector_7; }
	inline void set_downVector_7(Vector3_t2243707580  value)
	{
		___downVector_7 = value;
	}

	inline static int32_t get_offset_of_leftVector_8() { return static_cast<int32_t>(offsetof(Vector3_t2243707580_StaticFields, ___leftVector_8)); }
	inline Vector3_t2243707580  get_leftVector_8() const { return ___leftVector_8; }
	inline Vector3_t2243707580 * get_address_of_leftVector_8() { return &___leftVector_8; }
	inline void set_leftVector_8(Vector3_t2243707580  value)
	{
		___leftVector_8 = value;
	}

	inline static int32_t get_offset_of_rightVector_9() { return static_cast<int32_t>(offsetof(Vector3_t2243707580_StaticFields, ___rightVector_9)); }
	inline Vector3_t2243707580  get_rightVector_9() const { return ___rightVector_9; }
	inline Vector3_t2243707580 * get_address_of_rightVector_9() { return &___rightVector_9; }
	inline void set_rightVector_9(Vector3_t2243707580  value)
	{
		___rightVector_9 = value;
	}

	inline static int32_t get_offset_of_forwardVector_10() { return static_cast<int32_t>(offsetof(Vector3_t2243707580_StaticFields, ___forwardVector_10)); }
	inline Vector3_t2243707580  get_forwardVector_10() const { return ___forwardVector_10; }
	inline Vector3_t2243707580 * get_address_of_forwardVector_10() { return &___forwardVector_10; }
	inline void set_forwardVector_10(Vector3_t2243707580  value)
	{
		___forwardVector_10 = value;
	}

	inline static int32_t get_offset_of_backVector_11() { return static_cast<int32_t>(offsetof(Vector3_t2243707580_StaticFields, ___backVector_11)); }
	inline Vector3_t2243707580  get_backVector_11() const { return ___backVector_11; }
	inline Vector3_t2243707580 * get_address_of_backVector_11() { return &___backVector_11; }
	inline void set_backVector_11(Vector3_t2243707580  value)
	{
		___backVector_11 = value;
	}

	inline static int32_t get_offset_of_positiveInfinityVector_12() { return static_cast<int32_t>(offsetof(Vector3_t2243707580_StaticFields, ___positiveInfinityVector_12)); }
	inline Vector3_t2243707580  get_positiveInfinityVector_12() const { return ___positiveInfinityVector_12; }
	inline Vector3_t2243707580 * get_address_of_positiveInfinityVector_12() { return &___positiveInfinityVector_12; }
	inline void set_positiveInfinityVector_12(Vector3_t2243707580  value)
	{
		___positiveInfinityVector_12 = value;
	}

	inline static int32_t get_offset_of_negativeInfinityVector_13() { return static_cast<int32_t>(offsetof(Vector3_t2243707580_StaticFields, ___negativeInfinityVector_13)); }
	inline Vector3_t2243707580  get_negativeInfinityVector_13() const { return ___negativeInfinityVector_13; }
	inline Vector3_t2243707580 * get_address_of_negativeInfinityVector_13() { return &___negativeInfinityVector_13; }
	inline void set_negativeInfinityVector_13(Vector3_t2243707580  value)
	{
		___negativeInfinityVector_13 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // VECTOR3_T2243707580_H
#ifndef VOID_T1841601450_H
#define VOID_T1841601450_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Void
struct  Void_t1841601450 
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // VOID_T1841601450_H
#ifndef MATRIX4X4_T2933234003_H
#define MATRIX4X4_T2933234003_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Matrix4x4
struct  Matrix4x4_t2933234003 
{
public:
	// System.Single UnityEngine.Matrix4x4::m00
	float ___m00_0;
	// System.Single UnityEngine.Matrix4x4::m10
	float ___m10_1;
	// System.Single UnityEngine.Matrix4x4::m20
	float ___m20_2;
	// System.Single UnityEngine.Matrix4x4::m30
	float ___m30_3;
	// System.Single UnityEngine.Matrix4x4::m01
	float ___m01_4;
	// System.Single UnityEngine.Matrix4x4::m11
	float ___m11_5;
	// System.Single UnityEngine.Matrix4x4::m21
	float ___m21_6;
	// System.Single UnityEngine.Matrix4x4::m31
	float ___m31_7;
	// System.Single UnityEngine.Matrix4x4::m02
	float ___m02_8;
	// System.Single UnityEngine.Matrix4x4::m12
	float ___m12_9;
	// System.Single UnityEngine.Matrix4x4::m22
	float ___m22_10;
	// System.Single UnityEngine.Matrix4x4::m32
	float ___m32_11;
	// System.Single UnityEngine.Matrix4x4::m03
	float ___m03_12;
	// System.Single UnityEngine.Matrix4x4::m13
	float ___m13_13;
	// System.Single UnityEngine.Matrix4x4::m23
	float ___m23_14;
	// System.Single UnityEngine.Matrix4x4::m33
	float ___m33_15;

public:
	inline static int32_t get_offset_of_m00_0() { return static_cast<int32_t>(offsetof(Matrix4x4_t2933234003, ___m00_0)); }
	inline float get_m00_0() const { return ___m00_0; }
	inline float* get_address_of_m00_0() { return &___m00_0; }
	inline void set_m00_0(float value)
	{
		___m00_0 = value;
	}

	inline static int32_t get_offset_of_m10_1() { return static_cast<int32_t>(offsetof(Matrix4x4_t2933234003, ___m10_1)); }
	inline float get_m10_1() const { return ___m10_1; }
	inline float* get_address_of_m10_1() { return &___m10_1; }
	inline void set_m10_1(float value)
	{
		___m10_1 = value;
	}

	inline static int32_t get_offset_of_m20_2() { return static_cast<int32_t>(offsetof(Matrix4x4_t2933234003, ___m20_2)); }
	inline float get_m20_2() const { return ___m20_2; }
	inline float* get_address_of_m20_2() { return &___m20_2; }
	inline void set_m20_2(float value)
	{
		___m20_2 = value;
	}

	inline static int32_t get_offset_of_m30_3() { return static_cast<int32_t>(offsetof(Matrix4x4_t2933234003, ___m30_3)); }
	inline float get_m30_3() const { return ___m30_3; }
	inline float* get_address_of_m30_3() { return &___m30_3; }
	inline void set_m30_3(float value)
	{
		___m30_3 = value;
	}

	inline static int32_t get_offset_of_m01_4() { return static_cast<int32_t>(offsetof(Matrix4x4_t2933234003, ___m01_4)); }
	inline float get_m01_4() const { return ___m01_4; }
	inline float* get_address_of_m01_4() { return &___m01_4; }
	inline void set_m01_4(float value)
	{
		___m01_4 = value;
	}

	inline static int32_t get_offset_of_m11_5() { return static_cast<int32_t>(offsetof(Matrix4x4_t2933234003, ___m11_5)); }
	inline float get_m11_5() const { return ___m11_5; }
	inline float* get_address_of_m11_5() { return &___m11_5; }
	inline void set_m11_5(float value)
	{
		___m11_5 = value;
	}

	inline static int32_t get_offset_of_m21_6() { return static_cast<int32_t>(offsetof(Matrix4x4_t2933234003, ___m21_6)); }
	inline float get_m21_6() const { return ___m21_6; }
	inline float* get_address_of_m21_6() { return &___m21_6; }
	inline void set_m21_6(float value)
	{
		___m21_6 = value;
	}

	inline static int32_t get_offset_of_m31_7() { return static_cast<int32_t>(offsetof(Matrix4x4_t2933234003, ___m31_7)); }
	inline float get_m31_7() const { return ___m31_7; }
	inline float* get_address_of_m31_7() { return &___m31_7; }
	inline void set_m31_7(float value)
	{
		___m31_7 = value;
	}

	inline static int32_t get_offset_of_m02_8() { return static_cast<int32_t>(offsetof(Matrix4x4_t2933234003, ___m02_8)); }
	inline float get_m02_8() const { return ___m02_8; }
	inline float* get_address_of_m02_8() { return &___m02_8; }
	inline void set_m02_8(float value)
	{
		___m02_8 = value;
	}

	inline static int32_t get_offset_of_m12_9() { return static_cast<int32_t>(offsetof(Matrix4x4_t2933234003, ___m12_9)); }
	inline float get_m12_9() const { return ___m12_9; }
	inline float* get_address_of_m12_9() { return &___m12_9; }
	inline void set_m12_9(float value)
	{
		___m12_9 = value;
	}

	inline static int32_t get_offset_of_m22_10() { return static_cast<int32_t>(offsetof(Matrix4x4_t2933234003, ___m22_10)); }
	inline float get_m22_10() const { return ___m22_10; }
	inline float* get_address_of_m22_10() { return &___m22_10; }
	inline void set_m22_10(float value)
	{
		___m22_10 = value;
	}

	inline static int32_t get_offset_of_m32_11() { return static_cast<int32_t>(offsetof(Matrix4x4_t2933234003, ___m32_11)); }
	inline float get_m32_11() const { return ___m32_11; }
	inline float* get_address_of_m32_11() { return &___m32_11; }
	inline void set_m32_11(float value)
	{
		___m32_11 = value;
	}

	inline static int32_t get_offset_of_m03_12() { return static_cast<int32_t>(offsetof(Matrix4x4_t2933234003, ___m03_12)); }
	inline float get_m03_12() const { return ___m03_12; }
	inline float* get_address_of_m03_12() { return &___m03_12; }
	inline void set_m03_12(float value)
	{
		___m03_12 = value;
	}

	inline static int32_t get_offset_of_m13_13() { return static_cast<int32_t>(offsetof(Matrix4x4_t2933234003, ___m13_13)); }
	inline float get_m13_13() const { return ___m13_13; }
	inline float* get_address_of_m13_13() { return &___m13_13; }
	inline void set_m13_13(float value)
	{
		___m13_13 = value;
	}

	inline static int32_t get_offset_of_m23_14() { return static_cast<int32_t>(offsetof(Matrix4x4_t2933234003, ___m23_14)); }
	inline float get_m23_14() const { return ___m23_14; }
	inline float* get_address_of_m23_14() { return &___m23_14; }
	inline void set_m23_14(float value)
	{
		___m23_14 = value;
	}

	inline static int32_t get_offset_of_m33_15() { return static_cast<int32_t>(offsetof(Matrix4x4_t2933234003, ___m33_15)); }
	inline float get_m33_15() const { return ___m33_15; }
	inline float* get_address_of_m33_15() { return &___m33_15; }
	inline void set_m33_15(float value)
	{
		___m33_15 = value;
	}
};

struct Matrix4x4_t2933234003_StaticFields
{
public:
	// UnityEngine.Matrix4x4 UnityEngine.Matrix4x4::zeroMatrix
	Matrix4x4_t2933234003  ___zeroMatrix_16;
	// UnityEngine.Matrix4x4 UnityEngine.Matrix4x4::identityMatrix
	Matrix4x4_t2933234003  ___identityMatrix_17;

public:
	inline static int32_t get_offset_of_zeroMatrix_16() { return static_cast<int32_t>(offsetof(Matrix4x4_t2933234003_StaticFields, ___zeroMatrix_16)); }
	inline Matrix4x4_t2933234003  get_zeroMatrix_16() const { return ___zeroMatrix_16; }
	inline Matrix4x4_t2933234003 * get_address_of_zeroMatrix_16() { return &___zeroMatrix_16; }
	inline void set_zeroMatrix_16(Matrix4x4_t2933234003  value)
	{
		___zeroMatrix_16 = value;
	}

	inline static int32_t get_offset_of_identityMatrix_17() { return static_cast<int32_t>(offsetof(Matrix4x4_t2933234003_StaticFields, ___identityMatrix_17)); }
	inline Matrix4x4_t2933234003  get_identityMatrix_17() const { return ___identityMatrix_17; }
	inline Matrix4x4_t2933234003 * get_address_of_identityMatrix_17() { return &___identityMatrix_17; }
	inline void set_identityMatrix_17(Matrix4x4_t2933234003  value)
	{
		___identityMatrix_17 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MATRIX4X4_T2933234003_H
#ifndef UNITYARLIGHTESTIMATE_T311267890_H
#define UNITYARLIGHTESTIMATE_T311267890_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARLightEstimate
struct  UnityARLightEstimate_t311267890 
{
public:
	// System.Single UnityEngine.XR.iOS.UnityARLightEstimate::ambientIntensity
	float ___ambientIntensity_0;
	// System.Single UnityEngine.XR.iOS.UnityARLightEstimate::ambientColorTemperature
	float ___ambientColorTemperature_1;

public:
	inline static int32_t get_offset_of_ambientIntensity_0() { return static_cast<int32_t>(offsetof(UnityARLightEstimate_t311267890, ___ambientIntensity_0)); }
	inline float get_ambientIntensity_0() const { return ___ambientIntensity_0; }
	inline float* get_address_of_ambientIntensity_0() { return &___ambientIntensity_0; }
	inline void set_ambientIntensity_0(float value)
	{
		___ambientIntensity_0 = value;
	}

	inline static int32_t get_offset_of_ambientColorTemperature_1() { return static_cast<int32_t>(offsetof(UnityARLightEstimate_t311267890, ___ambientColorTemperature_1)); }
	inline float get_ambientColorTemperature_1() const { return ___ambientColorTemperature_1; }
	inline float* get_address_of_ambientColorTemperature_1() { return &___ambientColorTemperature_1; }
	inline void set_ambientColorTemperature_1(float value)
	{
		___ambientColorTemperature_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYARLIGHTESTIMATE_T311267890_H
#ifndef ARUSERANCHOR_T4064312267_H
#define ARUSERANCHOR_T4064312267_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.ARUserAnchor
struct  ARUserAnchor_t4064312267 
{
public:
	// System.String UnityEngine.XR.iOS.ARUserAnchor::identifier
	String_t* ___identifier_0;
	// UnityEngine.Matrix4x4 UnityEngine.XR.iOS.ARUserAnchor::transform
	Matrix4x4_t2933234003  ___transform_1;

public:
	inline static int32_t get_offset_of_identifier_0() { return static_cast<int32_t>(offsetof(ARUserAnchor_t4064312267, ___identifier_0)); }
	inline String_t* get_identifier_0() const { return ___identifier_0; }
	inline String_t** get_address_of_identifier_0() { return &___identifier_0; }
	inline void set_identifier_0(String_t* value)
	{
		___identifier_0 = value;
		Il2CppCodeGenWriteBarrier((&___identifier_0), value);
	}

	inline static int32_t get_offset_of_transform_1() { return static_cast<int32_t>(offsetof(ARUserAnchor_t4064312267, ___transform_1)); }
	inline Matrix4x4_t2933234003  get_transform_1() const { return ___transform_1; }
	inline Matrix4x4_t2933234003 * get_address_of_transform_1() { return &___transform_1; }
	inline void set_transform_1(Matrix4x4_t2933234003  value)
	{
		___transform_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.XR.iOS.ARUserAnchor
struct ARUserAnchor_t4064312267_marshaled_pinvoke
{
	char* ___identifier_0;
	Matrix4x4_t2933234003  ___transform_1;
};
// Native definition for COM marshalling of UnityEngine.XR.iOS.ARUserAnchor
struct ARUserAnchor_t4064312267_marshaled_com
{
	Il2CppChar* ___identifier_0;
	Matrix4x4_t2933234003  ___transform_1;
};
#endif // ARUSERANCHOR_T4064312267_H
#ifndef UNITYVIDEOPARAMS_T2644681676_H
#define UNITYVIDEOPARAMS_T2644681676_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityVideoParams
struct  UnityVideoParams_t2644681676 
{
public:
	// System.Int32 UnityEngine.XR.iOS.UnityVideoParams::yWidth
	int32_t ___yWidth_0;
	// System.Int32 UnityEngine.XR.iOS.UnityVideoParams::yHeight
	int32_t ___yHeight_1;
	// System.Int32 UnityEngine.XR.iOS.UnityVideoParams::screenOrientation
	int32_t ___screenOrientation_2;
	// System.Single UnityEngine.XR.iOS.UnityVideoParams::texCoordScale
	float ___texCoordScale_3;
	// System.IntPtr UnityEngine.XR.iOS.UnityVideoParams::cvPixelBufferPtr
	intptr_t ___cvPixelBufferPtr_4;

public:
	inline static int32_t get_offset_of_yWidth_0() { return static_cast<int32_t>(offsetof(UnityVideoParams_t2644681676, ___yWidth_0)); }
	inline int32_t get_yWidth_0() const { return ___yWidth_0; }
	inline int32_t* get_address_of_yWidth_0() { return &___yWidth_0; }
	inline void set_yWidth_0(int32_t value)
	{
		___yWidth_0 = value;
	}

	inline static int32_t get_offset_of_yHeight_1() { return static_cast<int32_t>(offsetof(UnityVideoParams_t2644681676, ___yHeight_1)); }
	inline int32_t get_yHeight_1() const { return ___yHeight_1; }
	inline int32_t* get_address_of_yHeight_1() { return &___yHeight_1; }
	inline void set_yHeight_1(int32_t value)
	{
		___yHeight_1 = value;
	}

	inline static int32_t get_offset_of_screenOrientation_2() { return static_cast<int32_t>(offsetof(UnityVideoParams_t2644681676, ___screenOrientation_2)); }
	inline int32_t get_screenOrientation_2() const { return ___screenOrientation_2; }
	inline int32_t* get_address_of_screenOrientation_2() { return &___screenOrientation_2; }
	inline void set_screenOrientation_2(int32_t value)
	{
		___screenOrientation_2 = value;
	}

	inline static int32_t get_offset_of_texCoordScale_3() { return static_cast<int32_t>(offsetof(UnityVideoParams_t2644681676, ___texCoordScale_3)); }
	inline float get_texCoordScale_3() const { return ___texCoordScale_3; }
	inline float* get_address_of_texCoordScale_3() { return &___texCoordScale_3; }
	inline void set_texCoordScale_3(float value)
	{
		___texCoordScale_3 = value;
	}

	inline static int32_t get_offset_of_cvPixelBufferPtr_4() { return static_cast<int32_t>(offsetof(UnityVideoParams_t2644681676, ___cvPixelBufferPtr_4)); }
	inline intptr_t get_cvPixelBufferPtr_4() const { return ___cvPixelBufferPtr_4; }
	inline intptr_t* get_address_of_cvPixelBufferPtr_4() { return &___cvPixelBufferPtr_4; }
	inline void set_cvPixelBufferPtr_4(intptr_t value)
	{
		___cvPixelBufferPtr_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYVIDEOPARAMS_T2644681676_H
#ifndef UNITYARMATRIX4X4_T100931615_H
#define UNITYARMATRIX4X4_T100931615_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARMatrix4x4
struct  UnityARMatrix4x4_t100931615 
{
public:
	// UnityEngine.Vector4 UnityEngine.XR.iOS.UnityARMatrix4x4::column0
	Vector4_t2243707581  ___column0_0;
	// UnityEngine.Vector4 UnityEngine.XR.iOS.UnityARMatrix4x4::column1
	Vector4_t2243707581  ___column1_1;
	// UnityEngine.Vector4 UnityEngine.XR.iOS.UnityARMatrix4x4::column2
	Vector4_t2243707581  ___column2_2;
	// UnityEngine.Vector4 UnityEngine.XR.iOS.UnityARMatrix4x4::column3
	Vector4_t2243707581  ___column3_3;

public:
	inline static int32_t get_offset_of_column0_0() { return static_cast<int32_t>(offsetof(UnityARMatrix4x4_t100931615, ___column0_0)); }
	inline Vector4_t2243707581  get_column0_0() const { return ___column0_0; }
	inline Vector4_t2243707581 * get_address_of_column0_0() { return &___column0_0; }
	inline void set_column0_0(Vector4_t2243707581  value)
	{
		___column0_0 = value;
	}

	inline static int32_t get_offset_of_column1_1() { return static_cast<int32_t>(offsetof(UnityARMatrix4x4_t100931615, ___column1_1)); }
	inline Vector4_t2243707581  get_column1_1() const { return ___column1_1; }
	inline Vector4_t2243707581 * get_address_of_column1_1() { return &___column1_1; }
	inline void set_column1_1(Vector4_t2243707581  value)
	{
		___column1_1 = value;
	}

	inline static int32_t get_offset_of_column2_2() { return static_cast<int32_t>(offsetof(UnityARMatrix4x4_t100931615, ___column2_2)); }
	inline Vector4_t2243707581  get_column2_2() const { return ___column2_2; }
	inline Vector4_t2243707581 * get_address_of_column2_2() { return &___column2_2; }
	inline void set_column2_2(Vector4_t2243707581  value)
	{
		___column2_2 = value;
	}

	inline static int32_t get_offset_of_column3_3() { return static_cast<int32_t>(offsetof(UnityARMatrix4x4_t100931615, ___column3_3)); }
	inline Vector4_t2243707581  get_column3_3() const { return ___column3_3; }
	inline Vector4_t2243707581 * get_address_of_column3_3() { return &___column3_3; }
	inline void set_column3_3(Vector4_t2243707581  value)
	{
		___column3_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYARMATRIX4X4_T100931615_H
#ifndef DELEGATE_T3022476291_H
#define DELEGATE_T3022476291_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Delegate
struct  Delegate_t3022476291  : public RuntimeObject
{
public:
	// System.IntPtr System.Delegate::method_ptr
	Il2CppMethodPointer ___method_ptr_0;
	// System.IntPtr System.Delegate::invoke_impl
	intptr_t ___invoke_impl_1;
	// System.Object System.Delegate::m_target
	RuntimeObject * ___m_target_2;
	// System.IntPtr System.Delegate::method
	intptr_t ___method_3;
	// System.IntPtr System.Delegate::delegate_trampoline
	intptr_t ___delegate_trampoline_4;
	// System.IntPtr System.Delegate::method_code
	intptr_t ___method_code_5;
	// System.Reflection.MethodInfo System.Delegate::method_info
	MethodInfo_t * ___method_info_6;
	// System.Reflection.MethodInfo System.Delegate::original_method_info
	MethodInfo_t * ___original_method_info_7;
	// System.DelegateData System.Delegate::data
	DelegateData_t1572802995 * ___data_8;

public:
	inline static int32_t get_offset_of_method_ptr_0() { return static_cast<int32_t>(offsetof(Delegate_t3022476291, ___method_ptr_0)); }
	inline Il2CppMethodPointer get_method_ptr_0() const { return ___method_ptr_0; }
	inline Il2CppMethodPointer* get_address_of_method_ptr_0() { return &___method_ptr_0; }
	inline void set_method_ptr_0(Il2CppMethodPointer value)
	{
		___method_ptr_0 = value;
	}

	inline static int32_t get_offset_of_invoke_impl_1() { return static_cast<int32_t>(offsetof(Delegate_t3022476291, ___invoke_impl_1)); }
	inline intptr_t get_invoke_impl_1() const { return ___invoke_impl_1; }
	inline intptr_t* get_address_of_invoke_impl_1() { return &___invoke_impl_1; }
	inline void set_invoke_impl_1(intptr_t value)
	{
		___invoke_impl_1 = value;
	}

	inline static int32_t get_offset_of_m_target_2() { return static_cast<int32_t>(offsetof(Delegate_t3022476291, ___m_target_2)); }
	inline RuntimeObject * get_m_target_2() const { return ___m_target_2; }
	inline RuntimeObject ** get_address_of_m_target_2() { return &___m_target_2; }
	inline void set_m_target_2(RuntimeObject * value)
	{
		___m_target_2 = value;
		Il2CppCodeGenWriteBarrier((&___m_target_2), value);
	}

	inline static int32_t get_offset_of_method_3() { return static_cast<int32_t>(offsetof(Delegate_t3022476291, ___method_3)); }
	inline intptr_t get_method_3() const { return ___method_3; }
	inline intptr_t* get_address_of_method_3() { return &___method_3; }
	inline void set_method_3(intptr_t value)
	{
		___method_3 = value;
	}

	inline static int32_t get_offset_of_delegate_trampoline_4() { return static_cast<int32_t>(offsetof(Delegate_t3022476291, ___delegate_trampoline_4)); }
	inline intptr_t get_delegate_trampoline_4() const { return ___delegate_trampoline_4; }
	inline intptr_t* get_address_of_delegate_trampoline_4() { return &___delegate_trampoline_4; }
	inline void set_delegate_trampoline_4(intptr_t value)
	{
		___delegate_trampoline_4 = value;
	}

	inline static int32_t get_offset_of_method_code_5() { return static_cast<int32_t>(offsetof(Delegate_t3022476291, ___method_code_5)); }
	inline intptr_t get_method_code_5() const { return ___method_code_5; }
	inline intptr_t* get_address_of_method_code_5() { return &___method_code_5; }
	inline void set_method_code_5(intptr_t value)
	{
		___method_code_5 = value;
	}

	inline static int32_t get_offset_of_method_info_6() { return static_cast<int32_t>(offsetof(Delegate_t3022476291, ___method_info_6)); }
	inline MethodInfo_t * get_method_info_6() const { return ___method_info_6; }
	inline MethodInfo_t ** get_address_of_method_info_6() { return &___method_info_6; }
	inline void set_method_info_6(MethodInfo_t * value)
	{
		___method_info_6 = value;
		Il2CppCodeGenWriteBarrier((&___method_info_6), value);
	}

	inline static int32_t get_offset_of_original_method_info_7() { return static_cast<int32_t>(offsetof(Delegate_t3022476291, ___original_method_info_7)); }
	inline MethodInfo_t * get_original_method_info_7() const { return ___original_method_info_7; }
	inline MethodInfo_t ** get_address_of_original_method_info_7() { return &___original_method_info_7; }
	inline void set_original_method_info_7(MethodInfo_t * value)
	{
		___original_method_info_7 = value;
		Il2CppCodeGenWriteBarrier((&___original_method_info_7), value);
	}

	inline static int32_t get_offset_of_data_8() { return static_cast<int32_t>(offsetof(Delegate_t3022476291, ___data_8)); }
	inline DelegateData_t1572802995 * get_data_8() const { return ___data_8; }
	inline DelegateData_t1572802995 ** get_address_of_data_8() { return &___data_8; }
	inline void set_data_8(DelegateData_t1572802995 * value)
	{
		___data_8 = value;
		Il2CppCodeGenWriteBarrier((&___data_8), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // DELEGATE_T3022476291_H
#ifndef UNITYARPLANEDETECTION_T612575857_H
#define UNITYARPLANEDETECTION_T612575857_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARPlaneDetection
struct  UnityARPlaneDetection_t612575857 
{
public:
	// System.Int32 UnityEngine.XR.iOS.UnityARPlaneDetection::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(UnityARPlaneDetection_t612575857, ___value___1)); }
	inline int32_t get_value___1() const { return ___value___1; }
	inline int32_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int32_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYARPLANEDETECTION_T612575857_H
#ifndef U3CPRIVATEIMPLEMENTATIONDETAILSU3E_T1486305142_H
#define U3CPRIVATEIMPLEMENTATIONDETAILSU3E_T1486305142_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <PrivateImplementationDetails>
struct  U3CPrivateImplementationDetailsU3E_t1486305142  : public RuntimeObject
{
public:

public:
};

struct U3CPrivateImplementationDetailsU3E_t1486305142_StaticFields
{
public:
	// <PrivateImplementationDetails>/$ArrayType=24 <PrivateImplementationDetails>::$field-8E7629AD5AF686202B8CB7C014505C432FFE31E6
	U24ArrayTypeU3D24_t762068664  ___U24fieldU2D8E7629AD5AF686202B8CB7C014505C432FFE31E6_0;

public:
	inline static int32_t get_offset_of_U24fieldU2D8E7629AD5AF686202B8CB7C014505C432FFE31E6_0() { return static_cast<int32_t>(offsetof(U3CPrivateImplementationDetailsU3E_t1486305142_StaticFields, ___U24fieldU2D8E7629AD5AF686202B8CB7C014505C432FFE31E6_0)); }
	inline U24ArrayTypeU3D24_t762068664  get_U24fieldU2D8E7629AD5AF686202B8CB7C014505C432FFE31E6_0() const { return ___U24fieldU2D8E7629AD5AF686202B8CB7C014505C432FFE31E6_0; }
	inline U24ArrayTypeU3D24_t762068664 * get_address_of_U24fieldU2D8E7629AD5AF686202B8CB7C014505C432FFE31E6_0() { return &___U24fieldU2D8E7629AD5AF686202B8CB7C014505C432FFE31E6_0; }
	inline void set_U24fieldU2D8E7629AD5AF686202B8CB7C014505C432FFE31E6_0(U24ArrayTypeU3D24_t762068664  value)
	{
		___U24fieldU2D8E7629AD5AF686202B8CB7C014505C432FFE31E6_0 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // U3CPRIVATEIMPLEMENTATIONDETAILSU3E_T1486305142_H
#ifndef UNITYARSESSIONRUNOPTION_T3123075684_H
#define UNITYARSESSIONRUNOPTION_T3123075684_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARSessionRunOption
struct  UnityARSessionRunOption_t3123075684 
{
public:
	// System.Int32 UnityEngine.XR.iOS.UnityARSessionRunOption::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(UnityARSessionRunOption_t3123075684, ___value___1)); }
	inline int32_t get_value___1() const { return ___value___1; }
	inline int32_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int32_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYARSESSIONRUNOPTION_T3123075684_H
#ifndef OBJECT_T1021602117_H
#define OBJECT_T1021602117_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Object
struct  Object_t1021602117  : public RuntimeObject
{
public:
	// System.IntPtr UnityEngine.Object::m_CachedPtr
	intptr_t ___m_CachedPtr_0;

public:
	inline static int32_t get_offset_of_m_CachedPtr_0() { return static_cast<int32_t>(offsetof(Object_t1021602117, ___m_CachedPtr_0)); }
	inline intptr_t get_m_CachedPtr_0() const { return ___m_CachedPtr_0; }
	inline intptr_t* get_address_of_m_CachedPtr_0() { return &___m_CachedPtr_0; }
	inline void set_m_CachedPtr_0(intptr_t value)
	{
		___m_CachedPtr_0 = value;
	}
};

struct Object_t1021602117_StaticFields
{
public:
	// System.Int32 UnityEngine.Object::OffsetOfInstanceIDInCPlusPlusObject
	int32_t ___OffsetOfInstanceIDInCPlusPlusObject_1;

public:
	inline static int32_t get_offset_of_OffsetOfInstanceIDInCPlusPlusObject_1() { return static_cast<int32_t>(offsetof(Object_t1021602117_StaticFields, ___OffsetOfInstanceIDInCPlusPlusObject_1)); }
	inline int32_t get_OffsetOfInstanceIDInCPlusPlusObject_1() const { return ___OffsetOfInstanceIDInCPlusPlusObject_1; }
	inline int32_t* get_address_of_OffsetOfInstanceIDInCPlusPlusObject_1() { return &___OffsetOfInstanceIDInCPlusPlusObject_1; }
	inline void set_OffsetOfInstanceIDInCPlusPlusObject_1(int32_t value)
	{
		___OffsetOfInstanceIDInCPlusPlusObject_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.Object
struct Object_t1021602117_marshaled_pinvoke
{
	intptr_t ___m_CachedPtr_0;
};
// Native definition for COM marshalling of UnityEngine.Object
struct Object_t1021602117_marshaled_com
{
	intptr_t ___m_CachedPtr_0;
};
#endif // OBJECT_T1021602117_H
#ifndef UNITYARALIGNMENT_T2379988631_H
#define UNITYARALIGNMENT_T2379988631_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARAlignment
struct  UnityARAlignment_t2379988631 
{
public:
	// System.Int32 UnityEngine.XR.iOS.UnityARAlignment::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(UnityARAlignment_t2379988631, ___value___1)); }
	inline int32_t get_value___1() const { return ___value___1; }
	inline int32_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int32_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYARALIGNMENT_T2379988631_H
#ifndef ARTRACKINGSTATEREASON_T4227173799_H
#define ARTRACKINGSTATEREASON_T4227173799_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.ARTrackingStateReason
struct  ARTrackingStateReason_t4227173799 
{
public:
	// System.Int32 UnityEngine.XR.iOS.ARTrackingStateReason::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(ARTrackingStateReason_t4227173799, ___value___1)); }
	inline int32_t get_value___1() const { return ___value___1; }
	inline int32_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int32_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARTRACKINGSTATEREASON_T4227173799_H
#ifndef ARHITTESTRESULTTYPE_T3616749745_H
#define ARHITTESTRESULTTYPE_T3616749745_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.ARHitTestResultType
struct  ARHitTestResultType_t3616749745 
{
public:
	// System.Int64 UnityEngine.XR.iOS.ARHitTestResultType::value__
	int64_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(ARHitTestResultType_t3616749745, ___value___1)); }
	inline int64_t get_value___1() const { return ___value___1; }
	inline int64_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int64_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARHITTESTRESULTTYPE_T3616749745_H
#ifndef ARANCHOR_T1161832412_H
#define ARANCHOR_T1161832412_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.ARAnchor
struct  ARAnchor_t1161832412 
{
public:
	// System.String UnityEngine.XR.iOS.ARAnchor::identifier
	String_t* ___identifier_0;
	// UnityEngine.Matrix4x4 UnityEngine.XR.iOS.ARAnchor::transform
	Matrix4x4_t2933234003  ___transform_1;

public:
	inline static int32_t get_offset_of_identifier_0() { return static_cast<int32_t>(offsetof(ARAnchor_t1161832412, ___identifier_0)); }
	inline String_t* get_identifier_0() const { return ___identifier_0; }
	inline String_t** get_address_of_identifier_0() { return &___identifier_0; }
	inline void set_identifier_0(String_t* value)
	{
		___identifier_0 = value;
		Il2CppCodeGenWriteBarrier((&___identifier_0), value);
	}

	inline static int32_t get_offset_of_transform_1() { return static_cast<int32_t>(offsetof(ARAnchor_t1161832412, ___transform_1)); }
	inline Matrix4x4_t2933234003  get_transform_1() const { return ___transform_1; }
	inline Matrix4x4_t2933234003 * get_address_of_transform_1() { return &___transform_1; }
	inline void set_transform_1(Matrix4x4_t2933234003  value)
	{
		___transform_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.XR.iOS.ARAnchor
struct ARAnchor_t1161832412_marshaled_pinvoke
{
	char* ___identifier_0;
	Matrix4x4_t2933234003  ___transform_1;
};
// Native definition for COM marshalling of UnityEngine.XR.iOS.ARAnchor
struct ARAnchor_t1161832412_marshaled_com
{
	Il2CppChar* ___identifier_0;
	Matrix4x4_t2933234003  ___transform_1;
};
#endif // ARANCHOR_T1161832412_H
#ifndef ARERRORCODE_T2887756272_H
#define ARERRORCODE_T2887756272_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.ARErrorCode
struct  ARErrorCode_t2887756272 
{
public:
	// System.Int64 UnityEngine.XR.iOS.ARErrorCode::value__
	int64_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(ARErrorCode_t2887756272, ___value___1)); }
	inline int64_t get_value___1() const { return ___value___1; }
	inline int64_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int64_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARERRORCODE_T2887756272_H
#ifndef ARPLANEANCHORALIGNMENT_T2379298071_H
#define ARPLANEANCHORALIGNMENT_T2379298071_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.ARPlaneAnchorAlignment
struct  ARPlaneAnchorAlignment_t2379298071 
{
public:
	// System.Int64 UnityEngine.XR.iOS.ARPlaneAnchorAlignment::value__
	int64_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(ARPlaneAnchorAlignment_t2379298071, ___value___1)); }
	inline int64_t get_value___1() const { return ___value___1; }
	inline int64_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int64_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARPLANEANCHORALIGNMENT_T2379298071_H
#ifndef ARTRACKINGSTATE_T2048880995_H
#define ARTRACKINGSTATE_T2048880995_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.ARTrackingState
struct  ARTrackingState_t2048880995 
{
public:
	// System.Int32 UnityEngine.XR.iOS.ARTrackingState::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(ARTrackingState_t2048880995, ___value___1)); }
	inline int32_t get_value___1() const { return ___value___1; }
	inline int32_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int32_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARTRACKINGSTATE_T2048880995_H
#ifndef ARTRACKINGQUALITY_T55960597_H
#define ARTRACKINGQUALITY_T55960597_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.ARTrackingQuality
struct  ARTrackingQuality_t55960597 
{
public:
	// System.Int64 UnityEngine.XR.iOS.ARTrackingQuality::value__
	int64_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(ARTrackingQuality_t55960597, ___value___1)); }
	inline int64_t get_value___1() const { return ___value___1; }
	inline int64_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int64_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARTRACKINGQUALITY_T55960597_H
#ifndef ARTEXTUREHANDLES_T3764914833_H
#define ARTEXTUREHANDLES_T3764914833_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.ARTextureHandles
struct  ARTextureHandles_t3764914833 
{
public:
	// System.IntPtr UnityEngine.XR.iOS.ARTextureHandles::textureY
	intptr_t ___textureY_0;
	// System.IntPtr UnityEngine.XR.iOS.ARTextureHandles::textureCbCr
	intptr_t ___textureCbCr_1;

public:
	inline static int32_t get_offset_of_textureY_0() { return static_cast<int32_t>(offsetof(ARTextureHandles_t3764914833, ___textureY_0)); }
	inline intptr_t get_textureY_0() const { return ___textureY_0; }
	inline intptr_t* get_address_of_textureY_0() { return &___textureY_0; }
	inline void set_textureY_0(intptr_t value)
	{
		___textureY_0 = value;
	}

	inline static int32_t get_offset_of_textureCbCr_1() { return static_cast<int32_t>(offsetof(ARTextureHandles_t3764914833, ___textureCbCr_1)); }
	inline intptr_t get_textureCbCr_1() const { return ___textureCbCr_1; }
	inline intptr_t* get_address_of_textureCbCr_1() { return &___textureCbCr_1; }
	inline void set_textureCbCr_1(intptr_t value)
	{
		___textureCbCr_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARTEXTUREHANDLES_T3764914833_H
#ifndef ARRECT_T3555590363_H
#define ARRECT_T3555590363_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.ARRect
struct  ARRect_t3555590363 
{
public:
	// UnityEngine.XR.iOS.ARPoint UnityEngine.XR.iOS.ARRect::origin
	ARPoint_t3436811567  ___origin_0;
	// UnityEngine.XR.iOS.ARSize UnityEngine.XR.iOS.ARRect::size
	ARSize_t3911821096  ___size_1;

public:
	inline static int32_t get_offset_of_origin_0() { return static_cast<int32_t>(offsetof(ARRect_t3555590363, ___origin_0)); }
	inline ARPoint_t3436811567  get_origin_0() const { return ___origin_0; }
	inline ARPoint_t3436811567 * get_address_of_origin_0() { return &___origin_0; }
	inline void set_origin_0(ARPoint_t3436811567  value)
	{
		___origin_0 = value;
	}

	inline static int32_t get_offset_of_size_1() { return static_cast<int32_t>(offsetof(ARRect_t3555590363, ___size_1)); }
	inline ARSize_t3911821096  get_size_1() const { return ___size_1; }
	inline ARSize_t3911821096 * get_address_of_size_1() { return &___size_1; }
	inline void set_size_1(ARSize_t3911821096  value)
	{
		___size_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARRECT_T3555590363_H
#ifndef ARCAMERA_T4158705974_H
#define ARCAMERA_T4158705974_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.ARCamera
struct  ARCamera_t4158705974 
{
public:
	// UnityEngine.Matrix4x4 UnityEngine.XR.iOS.ARCamera::worldTransform
	Matrix4x4_t2933234003  ___worldTransform_0;
	// UnityEngine.Vector3 UnityEngine.XR.iOS.ARCamera::eulerAngles
	Vector3_t2243707580  ___eulerAngles_1;
	// UnityEngine.XR.iOS.ARTrackingQuality UnityEngine.XR.iOS.ARCamera::trackingQuality
	int64_t ___trackingQuality_2;
	// UnityEngine.Vector3 UnityEngine.XR.iOS.ARCamera::intrinsics_row1
	Vector3_t2243707580  ___intrinsics_row1_3;
	// UnityEngine.Vector3 UnityEngine.XR.iOS.ARCamera::intrinsics_row2
	Vector3_t2243707580  ___intrinsics_row2_4;
	// UnityEngine.Vector3 UnityEngine.XR.iOS.ARCamera::intrinsics_row3
	Vector3_t2243707580  ___intrinsics_row3_5;
	// UnityEngine.XR.iOS.ARSize UnityEngine.XR.iOS.ARCamera::imageResolution
	ARSize_t3911821096  ___imageResolution_6;

public:
	inline static int32_t get_offset_of_worldTransform_0() { return static_cast<int32_t>(offsetof(ARCamera_t4158705974, ___worldTransform_0)); }
	inline Matrix4x4_t2933234003  get_worldTransform_0() const { return ___worldTransform_0; }
	inline Matrix4x4_t2933234003 * get_address_of_worldTransform_0() { return &___worldTransform_0; }
	inline void set_worldTransform_0(Matrix4x4_t2933234003  value)
	{
		___worldTransform_0 = value;
	}

	inline static int32_t get_offset_of_eulerAngles_1() { return static_cast<int32_t>(offsetof(ARCamera_t4158705974, ___eulerAngles_1)); }
	inline Vector3_t2243707580  get_eulerAngles_1() const { return ___eulerAngles_1; }
	inline Vector3_t2243707580 * get_address_of_eulerAngles_1() { return &___eulerAngles_1; }
	inline void set_eulerAngles_1(Vector3_t2243707580  value)
	{
		___eulerAngles_1 = value;
	}

	inline static int32_t get_offset_of_trackingQuality_2() { return static_cast<int32_t>(offsetof(ARCamera_t4158705974, ___trackingQuality_2)); }
	inline int64_t get_trackingQuality_2() const { return ___trackingQuality_2; }
	inline int64_t* get_address_of_trackingQuality_2() { return &___trackingQuality_2; }
	inline void set_trackingQuality_2(int64_t value)
	{
		___trackingQuality_2 = value;
	}

	inline static int32_t get_offset_of_intrinsics_row1_3() { return static_cast<int32_t>(offsetof(ARCamera_t4158705974, ___intrinsics_row1_3)); }
	inline Vector3_t2243707580  get_intrinsics_row1_3() const { return ___intrinsics_row1_3; }
	inline Vector3_t2243707580 * get_address_of_intrinsics_row1_3() { return &___intrinsics_row1_3; }
	inline void set_intrinsics_row1_3(Vector3_t2243707580  value)
	{
		___intrinsics_row1_3 = value;
	}

	inline static int32_t get_offset_of_intrinsics_row2_4() { return static_cast<int32_t>(offsetof(ARCamera_t4158705974, ___intrinsics_row2_4)); }
	inline Vector3_t2243707580  get_intrinsics_row2_4() const { return ___intrinsics_row2_4; }
	inline Vector3_t2243707580 * get_address_of_intrinsics_row2_4() { return &___intrinsics_row2_4; }
	inline void set_intrinsics_row2_4(Vector3_t2243707580  value)
	{
		___intrinsics_row2_4 = value;
	}

	inline static int32_t get_offset_of_intrinsics_row3_5() { return static_cast<int32_t>(offsetof(ARCamera_t4158705974, ___intrinsics_row3_5)); }
	inline Vector3_t2243707580  get_intrinsics_row3_5() const { return ___intrinsics_row3_5; }
	inline Vector3_t2243707580 * get_address_of_intrinsics_row3_5() { return &___intrinsics_row3_5; }
	inline void set_intrinsics_row3_5(Vector3_t2243707580  value)
	{
		___intrinsics_row3_5 = value;
	}

	inline static int32_t get_offset_of_imageResolution_6() { return static_cast<int32_t>(offsetof(ARCamera_t4158705974, ___imageResolution_6)); }
	inline ARSize_t3911821096  get_imageResolution_6() const { return ___imageResolution_6; }
	inline ARSize_t3911821096 * get_address_of_imageResolution_6() { return &___imageResolution_6; }
	inline void set_imageResolution_6(ARSize_t3911821096  value)
	{
		___imageResolution_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARCAMERA_T4158705974_H
#ifndef MULTICASTDELEGATE_T3201952435_H
#define MULTICASTDELEGATE_T3201952435_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.MulticastDelegate
struct  MulticastDelegate_t3201952435  : public Delegate_t3022476291
{
public:
	// System.MulticastDelegate System.MulticastDelegate::prev
	MulticastDelegate_t3201952435 * ___prev_9;
	// System.MulticastDelegate System.MulticastDelegate::kpm_next
	MulticastDelegate_t3201952435 * ___kpm_next_10;

public:
	inline static int32_t get_offset_of_prev_9() { return static_cast<int32_t>(offsetof(MulticastDelegate_t3201952435, ___prev_9)); }
	inline MulticastDelegate_t3201952435 * get_prev_9() const { return ___prev_9; }
	inline MulticastDelegate_t3201952435 ** get_address_of_prev_9() { return &___prev_9; }
	inline void set_prev_9(MulticastDelegate_t3201952435 * value)
	{
		___prev_9 = value;
		Il2CppCodeGenWriteBarrier((&___prev_9), value);
	}

	inline static int32_t get_offset_of_kpm_next_10() { return static_cast<int32_t>(offsetof(MulticastDelegate_t3201952435, ___kpm_next_10)); }
	inline MulticastDelegate_t3201952435 * get_kpm_next_10() const { return ___kpm_next_10; }
	inline MulticastDelegate_t3201952435 ** get_address_of_kpm_next_10() { return &___kpm_next_10; }
	inline void set_kpm_next_10(MulticastDelegate_t3201952435 * value)
	{
		___kpm_next_10 = value;
		Il2CppCodeGenWriteBarrier((&___kpm_next_10), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MULTICASTDELEGATE_T3201952435_H
#ifndef COMPONENT_T3819376471_H
#define COMPONENT_T3819376471_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Component
struct  Component_t3819376471  : public Object_t1021602117
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // COMPONENT_T3819376471_H
#ifndef ARHITTESTRESULT_T3275513025_H
#define ARHITTESTRESULT_T3275513025_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.ARHitTestResult
struct  ARHitTestResult_t3275513025 
{
public:
	// UnityEngine.XR.iOS.ARHitTestResultType UnityEngine.XR.iOS.ARHitTestResult::type
	int64_t ___type_0;
	// System.Double UnityEngine.XR.iOS.ARHitTestResult::distance
	double ___distance_1;
	// UnityEngine.Matrix4x4 UnityEngine.XR.iOS.ARHitTestResult::localTransform
	Matrix4x4_t2933234003  ___localTransform_2;
	// UnityEngine.Matrix4x4 UnityEngine.XR.iOS.ARHitTestResult::worldTransform
	Matrix4x4_t2933234003  ___worldTransform_3;
	// System.String UnityEngine.XR.iOS.ARHitTestResult::anchorIdentifier
	String_t* ___anchorIdentifier_4;
	// System.Boolean UnityEngine.XR.iOS.ARHitTestResult::isValid
	bool ___isValid_5;

public:
	inline static int32_t get_offset_of_type_0() { return static_cast<int32_t>(offsetof(ARHitTestResult_t3275513025, ___type_0)); }
	inline int64_t get_type_0() const { return ___type_0; }
	inline int64_t* get_address_of_type_0() { return &___type_0; }
	inline void set_type_0(int64_t value)
	{
		___type_0 = value;
	}

	inline static int32_t get_offset_of_distance_1() { return static_cast<int32_t>(offsetof(ARHitTestResult_t3275513025, ___distance_1)); }
	inline double get_distance_1() const { return ___distance_1; }
	inline double* get_address_of_distance_1() { return &___distance_1; }
	inline void set_distance_1(double value)
	{
		___distance_1 = value;
	}

	inline static int32_t get_offset_of_localTransform_2() { return static_cast<int32_t>(offsetof(ARHitTestResult_t3275513025, ___localTransform_2)); }
	inline Matrix4x4_t2933234003  get_localTransform_2() const { return ___localTransform_2; }
	inline Matrix4x4_t2933234003 * get_address_of_localTransform_2() { return &___localTransform_2; }
	inline void set_localTransform_2(Matrix4x4_t2933234003  value)
	{
		___localTransform_2 = value;
	}

	inline static int32_t get_offset_of_worldTransform_3() { return static_cast<int32_t>(offsetof(ARHitTestResult_t3275513025, ___worldTransform_3)); }
	inline Matrix4x4_t2933234003  get_worldTransform_3() const { return ___worldTransform_3; }
	inline Matrix4x4_t2933234003 * get_address_of_worldTransform_3() { return &___worldTransform_3; }
	inline void set_worldTransform_3(Matrix4x4_t2933234003  value)
	{
		___worldTransform_3 = value;
	}

	inline static int32_t get_offset_of_anchorIdentifier_4() { return static_cast<int32_t>(offsetof(ARHitTestResult_t3275513025, ___anchorIdentifier_4)); }
	inline String_t* get_anchorIdentifier_4() const { return ___anchorIdentifier_4; }
	inline String_t** get_address_of_anchorIdentifier_4() { return &___anchorIdentifier_4; }
	inline void set_anchorIdentifier_4(String_t* value)
	{
		___anchorIdentifier_4 = value;
		Il2CppCodeGenWriteBarrier((&___anchorIdentifier_4), value);
	}

	inline static int32_t get_offset_of_isValid_5() { return static_cast<int32_t>(offsetof(ARHitTestResult_t3275513025, ___isValid_5)); }
	inline bool get_isValid_5() const { return ___isValid_5; }
	inline bool* get_address_of_isValid_5() { return &___isValid_5; }
	inline void set_isValid_5(bool value)
	{
		___isValid_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.XR.iOS.ARHitTestResult
struct ARHitTestResult_t3275513025_marshaled_pinvoke
{
	int64_t ___type_0;
	double ___distance_1;
	Matrix4x4_t2933234003  ___localTransform_2;
	Matrix4x4_t2933234003  ___worldTransform_3;
	char* ___anchorIdentifier_4;
	int32_t ___isValid_5;
};
// Native definition for COM marshalling of UnityEngine.XR.iOS.ARHitTestResult
struct ARHitTestResult_t3275513025_marshaled_com
{
	int64_t ___type_0;
	double ___distance_1;
	Matrix4x4_t2933234003  ___localTransform_2;
	Matrix4x4_t2933234003  ___worldTransform_3;
	Il2CppChar* ___anchorIdentifier_4;
	int32_t ___isValid_5;
};
#endif // ARHITTESTRESULT_T3275513025_H
#ifndef ARKITWORLDTRACKINGSESSIONCONFIGURATION_T1371796706_H
#define ARKITWORLDTRACKINGSESSIONCONFIGURATION_T1371796706_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.ARKitWorldTrackingSessionConfiguration
struct  ARKitWorldTrackingSessionConfiguration_t1371796706 
{
public:
	// UnityEngine.XR.iOS.UnityARAlignment UnityEngine.XR.iOS.ARKitWorldTrackingSessionConfiguration::alignment
	int32_t ___alignment_0;
	// UnityEngine.XR.iOS.UnityARPlaneDetection UnityEngine.XR.iOS.ARKitWorldTrackingSessionConfiguration::planeDetection
	int32_t ___planeDetection_1;
	// System.Boolean UnityEngine.XR.iOS.ARKitWorldTrackingSessionConfiguration::getPointCloudData
	bool ___getPointCloudData_2;
	// System.Boolean UnityEngine.XR.iOS.ARKitWorldTrackingSessionConfiguration::enableLightEstimation
	bool ___enableLightEstimation_3;

public:
	inline static int32_t get_offset_of_alignment_0() { return static_cast<int32_t>(offsetof(ARKitWorldTrackingSessionConfiguration_t1371796706, ___alignment_0)); }
	inline int32_t get_alignment_0() const { return ___alignment_0; }
	inline int32_t* get_address_of_alignment_0() { return &___alignment_0; }
	inline void set_alignment_0(int32_t value)
	{
		___alignment_0 = value;
	}

	inline static int32_t get_offset_of_planeDetection_1() { return static_cast<int32_t>(offsetof(ARKitWorldTrackingSessionConfiguration_t1371796706, ___planeDetection_1)); }
	inline int32_t get_planeDetection_1() const { return ___planeDetection_1; }
	inline int32_t* get_address_of_planeDetection_1() { return &___planeDetection_1; }
	inline void set_planeDetection_1(int32_t value)
	{
		___planeDetection_1 = value;
	}

	inline static int32_t get_offset_of_getPointCloudData_2() { return static_cast<int32_t>(offsetof(ARKitWorldTrackingSessionConfiguration_t1371796706, ___getPointCloudData_2)); }
	inline bool get_getPointCloudData_2() const { return ___getPointCloudData_2; }
	inline bool* get_address_of_getPointCloudData_2() { return &___getPointCloudData_2; }
	inline void set_getPointCloudData_2(bool value)
	{
		___getPointCloudData_2 = value;
	}

	inline static int32_t get_offset_of_enableLightEstimation_3() { return static_cast<int32_t>(offsetof(ARKitWorldTrackingSessionConfiguration_t1371796706, ___enableLightEstimation_3)); }
	inline bool get_enableLightEstimation_3() const { return ___enableLightEstimation_3; }
	inline bool* get_address_of_enableLightEstimation_3() { return &___enableLightEstimation_3; }
	inline void set_enableLightEstimation_3(bool value)
	{
		___enableLightEstimation_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.XR.iOS.ARKitWorldTrackingSessionConfiguration
struct ARKitWorldTrackingSessionConfiguration_t1371796706_marshaled_pinvoke
{
	int32_t ___alignment_0;
	int32_t ___planeDetection_1;
	int32_t ___getPointCloudData_2;
	int32_t ___enableLightEstimation_3;
};
// Native definition for COM marshalling of UnityEngine.XR.iOS.ARKitWorldTrackingSessionConfiguration
struct ARKitWorldTrackingSessionConfiguration_t1371796706_marshaled_com
{
	int32_t ___alignment_0;
	int32_t ___planeDetection_1;
	int32_t ___getPointCloudData_2;
	int32_t ___enableLightEstimation_3;
};
#endif // ARKITWORLDTRACKINGSESSIONCONFIGURATION_T1371796706_H
#ifndef INTERNAL_UNITYARCAMERA_T2580192745_H
#define INTERNAL_UNITYARCAMERA_T2580192745_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.internal_UnityARCamera
struct  internal_UnityARCamera_t2580192745 
{
public:
	// UnityEngine.XR.iOS.UnityARMatrix4x4 UnityEngine.XR.iOS.internal_UnityARCamera::worldTransform
	UnityARMatrix4x4_t100931615  ___worldTransform_0;
	// UnityEngine.XR.iOS.UnityARMatrix4x4 UnityEngine.XR.iOS.internal_UnityARCamera::projectionMatrix
	UnityARMatrix4x4_t100931615  ___projectionMatrix_1;
	// UnityEngine.XR.iOS.ARTrackingState UnityEngine.XR.iOS.internal_UnityARCamera::trackingState
	int32_t ___trackingState_2;
	// UnityEngine.XR.iOS.ARTrackingStateReason UnityEngine.XR.iOS.internal_UnityARCamera::trackingReason
	int32_t ___trackingReason_3;
	// UnityEngine.XR.iOS.UnityVideoParams UnityEngine.XR.iOS.internal_UnityARCamera::videoParams
	UnityVideoParams_t2644681676  ___videoParams_4;
	// UnityEngine.XR.iOS.UnityARLightEstimate UnityEngine.XR.iOS.internal_UnityARCamera::lightEstimation
	UnityARLightEstimate_t311267890  ___lightEstimation_5;
	// UnityEngine.XR.iOS.UnityARMatrix4x4 UnityEngine.XR.iOS.internal_UnityARCamera::displayTransform
	UnityARMatrix4x4_t100931615  ___displayTransform_6;
	// System.UInt32 UnityEngine.XR.iOS.internal_UnityARCamera::getPointCloudData
	uint32_t ___getPointCloudData_7;

public:
	inline static int32_t get_offset_of_worldTransform_0() { return static_cast<int32_t>(offsetof(internal_UnityARCamera_t2580192745, ___worldTransform_0)); }
	inline UnityARMatrix4x4_t100931615  get_worldTransform_0() const { return ___worldTransform_0; }
	inline UnityARMatrix4x4_t100931615 * get_address_of_worldTransform_0() { return &___worldTransform_0; }
	inline void set_worldTransform_0(UnityARMatrix4x4_t100931615  value)
	{
		___worldTransform_0 = value;
	}

	inline static int32_t get_offset_of_projectionMatrix_1() { return static_cast<int32_t>(offsetof(internal_UnityARCamera_t2580192745, ___projectionMatrix_1)); }
	inline UnityARMatrix4x4_t100931615  get_projectionMatrix_1() const { return ___projectionMatrix_1; }
	inline UnityARMatrix4x4_t100931615 * get_address_of_projectionMatrix_1() { return &___projectionMatrix_1; }
	inline void set_projectionMatrix_1(UnityARMatrix4x4_t100931615  value)
	{
		___projectionMatrix_1 = value;
	}

	inline static int32_t get_offset_of_trackingState_2() { return static_cast<int32_t>(offsetof(internal_UnityARCamera_t2580192745, ___trackingState_2)); }
	inline int32_t get_trackingState_2() const { return ___trackingState_2; }
	inline int32_t* get_address_of_trackingState_2() { return &___trackingState_2; }
	inline void set_trackingState_2(int32_t value)
	{
		___trackingState_2 = value;
	}

	inline static int32_t get_offset_of_trackingReason_3() { return static_cast<int32_t>(offsetof(internal_UnityARCamera_t2580192745, ___trackingReason_3)); }
	inline int32_t get_trackingReason_3() const { return ___trackingReason_3; }
	inline int32_t* get_address_of_trackingReason_3() { return &___trackingReason_3; }
	inline void set_trackingReason_3(int32_t value)
	{
		___trackingReason_3 = value;
	}

	inline static int32_t get_offset_of_videoParams_4() { return static_cast<int32_t>(offsetof(internal_UnityARCamera_t2580192745, ___videoParams_4)); }
	inline UnityVideoParams_t2644681676  get_videoParams_4() const { return ___videoParams_4; }
	inline UnityVideoParams_t2644681676 * get_address_of_videoParams_4() { return &___videoParams_4; }
	inline void set_videoParams_4(UnityVideoParams_t2644681676  value)
	{
		___videoParams_4 = value;
	}

	inline static int32_t get_offset_of_lightEstimation_5() { return static_cast<int32_t>(offsetof(internal_UnityARCamera_t2580192745, ___lightEstimation_5)); }
	inline UnityARLightEstimate_t311267890  get_lightEstimation_5() const { return ___lightEstimation_5; }
	inline UnityARLightEstimate_t311267890 * get_address_of_lightEstimation_5() { return &___lightEstimation_5; }
	inline void set_lightEstimation_5(UnityARLightEstimate_t311267890  value)
	{
		___lightEstimation_5 = value;
	}

	inline static int32_t get_offset_of_displayTransform_6() { return static_cast<int32_t>(offsetof(internal_UnityARCamera_t2580192745, ___displayTransform_6)); }
	inline UnityARMatrix4x4_t100931615  get_displayTransform_6() const { return ___displayTransform_6; }
	inline UnityARMatrix4x4_t100931615 * get_address_of_displayTransform_6() { return &___displayTransform_6; }
	inline void set_displayTransform_6(UnityARMatrix4x4_t100931615  value)
	{
		___displayTransform_6 = value;
	}

	inline static int32_t get_offset_of_getPointCloudData_7() { return static_cast<int32_t>(offsetof(internal_UnityARCamera_t2580192745, ___getPointCloudData_7)); }
	inline uint32_t get_getPointCloudData_7() const { return ___getPointCloudData_7; }
	inline uint32_t* get_address_of_getPointCloudData_7() { return &___getPointCloudData_7; }
	inline void set_getPointCloudData_7(uint32_t value)
	{
		___getPointCloudData_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INTERNAL_UNITYARCAMERA_T2580192745_H
#ifndef UNITYARCAMERA_T4198559457_H
#define UNITYARCAMERA_T4198559457_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARCamera
struct  UnityARCamera_t4198559457 
{
public:
	// UnityEngine.XR.iOS.UnityARMatrix4x4 UnityEngine.XR.iOS.UnityARCamera::worldTransform
	UnityARMatrix4x4_t100931615  ___worldTransform_0;
	// UnityEngine.XR.iOS.UnityARMatrix4x4 UnityEngine.XR.iOS.UnityARCamera::projectionMatrix
	UnityARMatrix4x4_t100931615  ___projectionMatrix_1;
	// UnityEngine.XR.iOS.ARTrackingState UnityEngine.XR.iOS.UnityARCamera::trackingState
	int32_t ___trackingState_2;
	// UnityEngine.XR.iOS.ARTrackingStateReason UnityEngine.XR.iOS.UnityARCamera::trackingReason
	int32_t ___trackingReason_3;
	// UnityEngine.XR.iOS.UnityVideoParams UnityEngine.XR.iOS.UnityARCamera::videoParams
	UnityVideoParams_t2644681676  ___videoParams_4;
	// UnityEngine.XR.iOS.UnityARLightEstimate UnityEngine.XR.iOS.UnityARCamera::lightEstimation
	UnityARLightEstimate_t311267890  ___lightEstimation_5;
	// UnityEngine.XR.iOS.UnityARMatrix4x4 UnityEngine.XR.iOS.UnityARCamera::displayTransform
	UnityARMatrix4x4_t100931615  ___displayTransform_6;
	// UnityEngine.Vector3[] UnityEngine.XR.iOS.UnityARCamera::pointCloudData
	Vector3U5BU5D_t1172311765* ___pointCloudData_7;

public:
	inline static int32_t get_offset_of_worldTransform_0() { return static_cast<int32_t>(offsetof(UnityARCamera_t4198559457, ___worldTransform_0)); }
	inline UnityARMatrix4x4_t100931615  get_worldTransform_0() const { return ___worldTransform_0; }
	inline UnityARMatrix4x4_t100931615 * get_address_of_worldTransform_0() { return &___worldTransform_0; }
	inline void set_worldTransform_0(UnityARMatrix4x4_t100931615  value)
	{
		___worldTransform_0 = value;
	}

	inline static int32_t get_offset_of_projectionMatrix_1() { return static_cast<int32_t>(offsetof(UnityARCamera_t4198559457, ___projectionMatrix_1)); }
	inline UnityARMatrix4x4_t100931615  get_projectionMatrix_1() const { return ___projectionMatrix_1; }
	inline UnityARMatrix4x4_t100931615 * get_address_of_projectionMatrix_1() { return &___projectionMatrix_1; }
	inline void set_projectionMatrix_1(UnityARMatrix4x4_t100931615  value)
	{
		___projectionMatrix_1 = value;
	}

	inline static int32_t get_offset_of_trackingState_2() { return static_cast<int32_t>(offsetof(UnityARCamera_t4198559457, ___trackingState_2)); }
	inline int32_t get_trackingState_2() const { return ___trackingState_2; }
	inline int32_t* get_address_of_trackingState_2() { return &___trackingState_2; }
	inline void set_trackingState_2(int32_t value)
	{
		___trackingState_2 = value;
	}

	inline static int32_t get_offset_of_trackingReason_3() { return static_cast<int32_t>(offsetof(UnityARCamera_t4198559457, ___trackingReason_3)); }
	inline int32_t get_trackingReason_3() const { return ___trackingReason_3; }
	inline int32_t* get_address_of_trackingReason_3() { return &___trackingReason_3; }
	inline void set_trackingReason_3(int32_t value)
	{
		___trackingReason_3 = value;
	}

	inline static int32_t get_offset_of_videoParams_4() { return static_cast<int32_t>(offsetof(UnityARCamera_t4198559457, ___videoParams_4)); }
	inline UnityVideoParams_t2644681676  get_videoParams_4() const { return ___videoParams_4; }
	inline UnityVideoParams_t2644681676 * get_address_of_videoParams_4() { return &___videoParams_4; }
	inline void set_videoParams_4(UnityVideoParams_t2644681676  value)
	{
		___videoParams_4 = value;
	}

	inline static int32_t get_offset_of_lightEstimation_5() { return static_cast<int32_t>(offsetof(UnityARCamera_t4198559457, ___lightEstimation_5)); }
	inline UnityARLightEstimate_t311267890  get_lightEstimation_5() const { return ___lightEstimation_5; }
	inline UnityARLightEstimate_t311267890 * get_address_of_lightEstimation_5() { return &___lightEstimation_5; }
	inline void set_lightEstimation_5(UnityARLightEstimate_t311267890  value)
	{
		___lightEstimation_5 = value;
	}

	inline static int32_t get_offset_of_displayTransform_6() { return static_cast<int32_t>(offsetof(UnityARCamera_t4198559457, ___displayTransform_6)); }
	inline UnityARMatrix4x4_t100931615  get_displayTransform_6() const { return ___displayTransform_6; }
	inline UnityARMatrix4x4_t100931615 * get_address_of_displayTransform_6() { return &___displayTransform_6; }
	inline void set_displayTransform_6(UnityARMatrix4x4_t100931615  value)
	{
		___displayTransform_6 = value;
	}

	inline static int32_t get_offset_of_pointCloudData_7() { return static_cast<int32_t>(offsetof(UnityARCamera_t4198559457, ___pointCloudData_7)); }
	inline Vector3U5BU5D_t1172311765* get_pointCloudData_7() const { return ___pointCloudData_7; }
	inline Vector3U5BU5D_t1172311765** get_address_of_pointCloudData_7() { return &___pointCloudData_7; }
	inline void set_pointCloudData_7(Vector3U5BU5D_t1172311765* value)
	{
		___pointCloudData_7 = value;
		Il2CppCodeGenWriteBarrier((&___pointCloudData_7), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.XR.iOS.UnityARCamera
struct UnityARCamera_t4198559457_marshaled_pinvoke
{
	UnityARMatrix4x4_t100931615  ___worldTransform_0;
	UnityARMatrix4x4_t100931615  ___projectionMatrix_1;
	int32_t ___trackingState_2;
	int32_t ___trackingReason_3;
	UnityVideoParams_t2644681676  ___videoParams_4;
	UnityARLightEstimate_t311267890  ___lightEstimation_5;
	UnityARMatrix4x4_t100931615  ___displayTransform_6;
	Vector3_t2243707580 * ___pointCloudData_7;
};
// Native definition for COM marshalling of UnityEngine.XR.iOS.UnityARCamera
struct UnityARCamera_t4198559457_marshaled_com
{
	UnityARMatrix4x4_t100931615  ___worldTransform_0;
	UnityARMatrix4x4_t100931615  ___projectionMatrix_1;
	int32_t ___trackingState_2;
	int32_t ___trackingReason_3;
	UnityVideoParams_t2644681676  ___videoParams_4;
	UnityARLightEstimate_t311267890  ___lightEstimation_5;
	UnityARMatrix4x4_t100931615  ___displayTransform_6;
	Vector3_t2243707580 * ___pointCloudData_7;
};
#endif // UNITYARCAMERA_T4198559457_H
#ifndef UNITYARANCHORDATA_T2901866349_H
#define UNITYARANCHORDATA_T2901866349_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARAnchorData
struct  UnityARAnchorData_t2901866349 
{
public:
	// System.IntPtr UnityEngine.XR.iOS.UnityARAnchorData::ptrIdentifier
	intptr_t ___ptrIdentifier_0;
	// UnityEngine.XR.iOS.UnityARMatrix4x4 UnityEngine.XR.iOS.UnityARAnchorData::transform
	UnityARMatrix4x4_t100931615  ___transform_1;
	// UnityEngine.XR.iOS.ARPlaneAnchorAlignment UnityEngine.XR.iOS.UnityARAnchorData::alignment
	int64_t ___alignment_2;
	// UnityEngine.Vector4 UnityEngine.XR.iOS.UnityARAnchorData::center
	Vector4_t2243707581  ___center_3;
	// UnityEngine.Vector4 UnityEngine.XR.iOS.UnityARAnchorData::extent
	Vector4_t2243707581  ___extent_4;

public:
	inline static int32_t get_offset_of_ptrIdentifier_0() { return static_cast<int32_t>(offsetof(UnityARAnchorData_t2901866349, ___ptrIdentifier_0)); }
	inline intptr_t get_ptrIdentifier_0() const { return ___ptrIdentifier_0; }
	inline intptr_t* get_address_of_ptrIdentifier_0() { return &___ptrIdentifier_0; }
	inline void set_ptrIdentifier_0(intptr_t value)
	{
		___ptrIdentifier_0 = value;
	}

	inline static int32_t get_offset_of_transform_1() { return static_cast<int32_t>(offsetof(UnityARAnchorData_t2901866349, ___transform_1)); }
	inline UnityARMatrix4x4_t100931615  get_transform_1() const { return ___transform_1; }
	inline UnityARMatrix4x4_t100931615 * get_address_of_transform_1() { return &___transform_1; }
	inline void set_transform_1(UnityARMatrix4x4_t100931615  value)
	{
		___transform_1 = value;
	}

	inline static int32_t get_offset_of_alignment_2() { return static_cast<int32_t>(offsetof(UnityARAnchorData_t2901866349, ___alignment_2)); }
	inline int64_t get_alignment_2() const { return ___alignment_2; }
	inline int64_t* get_address_of_alignment_2() { return &___alignment_2; }
	inline void set_alignment_2(int64_t value)
	{
		___alignment_2 = value;
	}

	inline static int32_t get_offset_of_center_3() { return static_cast<int32_t>(offsetof(UnityARAnchorData_t2901866349, ___center_3)); }
	inline Vector4_t2243707581  get_center_3() const { return ___center_3; }
	inline Vector4_t2243707581 * get_address_of_center_3() { return &___center_3; }
	inline void set_center_3(Vector4_t2243707581  value)
	{
		___center_3 = value;
	}

	inline static int32_t get_offset_of_extent_4() { return static_cast<int32_t>(offsetof(UnityARAnchorData_t2901866349, ___extent_4)); }
	inline Vector4_t2243707581  get_extent_4() const { return ___extent_4; }
	inline Vector4_t2243707581 * get_address_of_extent_4() { return &___extent_4; }
	inline void set_extent_4(Vector4_t2243707581  value)
	{
		___extent_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYARANCHORDATA_T2901866349_H
#ifndef UNITYARUSERANCHORDATA_T2645079618_H
#define UNITYARUSERANCHORDATA_T2645079618_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARUserAnchorData
struct  UnityARUserAnchorData_t2645079618 
{
public:
	// System.IntPtr UnityEngine.XR.iOS.UnityARUserAnchorData::ptrIdentifier
	intptr_t ___ptrIdentifier_0;
	// UnityEngine.XR.iOS.UnityARMatrix4x4 UnityEngine.XR.iOS.UnityARUserAnchorData::transform
	UnityARMatrix4x4_t100931615  ___transform_1;

public:
	inline static int32_t get_offset_of_ptrIdentifier_0() { return static_cast<int32_t>(offsetof(UnityARUserAnchorData_t2645079618, ___ptrIdentifier_0)); }
	inline intptr_t get_ptrIdentifier_0() const { return ___ptrIdentifier_0; }
	inline intptr_t* get_address_of_ptrIdentifier_0() { return &___ptrIdentifier_0; }
	inline void set_ptrIdentifier_0(intptr_t value)
	{
		___ptrIdentifier_0 = value;
	}

	inline static int32_t get_offset_of_transform_1() { return static_cast<int32_t>(offsetof(UnityARUserAnchorData_t2645079618, ___transform_1)); }
	inline UnityARMatrix4x4_t100931615  get_transform_1() const { return ___transform_1; }
	inline UnityARMatrix4x4_t100931615 * get_address_of_transform_1() { return &___transform_1; }
	inline void set_transform_1(UnityARMatrix4x4_t100931615  value)
	{
		___transform_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYARUSERANCHORDATA_T2645079618_H
#ifndef ARKITSESSIONCONFIGURATION_T318899795_H
#define ARKITSESSIONCONFIGURATION_T318899795_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.ARKitSessionConfiguration
struct  ARKitSessionConfiguration_t318899795 
{
public:
	// UnityEngine.XR.iOS.UnityARAlignment UnityEngine.XR.iOS.ARKitSessionConfiguration::alignment
	int32_t ___alignment_0;
	// System.Boolean UnityEngine.XR.iOS.ARKitSessionConfiguration::getPointCloudData
	bool ___getPointCloudData_1;
	// System.Boolean UnityEngine.XR.iOS.ARKitSessionConfiguration::enableLightEstimation
	bool ___enableLightEstimation_2;

public:
	inline static int32_t get_offset_of_alignment_0() { return static_cast<int32_t>(offsetof(ARKitSessionConfiguration_t318899795, ___alignment_0)); }
	inline int32_t get_alignment_0() const { return ___alignment_0; }
	inline int32_t* get_address_of_alignment_0() { return &___alignment_0; }
	inline void set_alignment_0(int32_t value)
	{
		___alignment_0 = value;
	}

	inline static int32_t get_offset_of_getPointCloudData_1() { return static_cast<int32_t>(offsetof(ARKitSessionConfiguration_t318899795, ___getPointCloudData_1)); }
	inline bool get_getPointCloudData_1() const { return ___getPointCloudData_1; }
	inline bool* get_address_of_getPointCloudData_1() { return &___getPointCloudData_1; }
	inline void set_getPointCloudData_1(bool value)
	{
		___getPointCloudData_1 = value;
	}

	inline static int32_t get_offset_of_enableLightEstimation_2() { return static_cast<int32_t>(offsetof(ARKitSessionConfiguration_t318899795, ___enableLightEstimation_2)); }
	inline bool get_enableLightEstimation_2() const { return ___enableLightEstimation_2; }
	inline bool* get_address_of_enableLightEstimation_2() { return &___enableLightEstimation_2; }
	inline void set_enableLightEstimation_2(bool value)
	{
		___enableLightEstimation_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.XR.iOS.ARKitSessionConfiguration
struct ARKitSessionConfiguration_t318899795_marshaled_pinvoke
{
	int32_t ___alignment_0;
	int32_t ___getPointCloudData_1;
	int32_t ___enableLightEstimation_2;
};
// Native definition for COM marshalling of UnityEngine.XR.iOS.ARKitSessionConfiguration
struct ARKitSessionConfiguration_t318899795_marshaled_com
{
	int32_t ___alignment_0;
	int32_t ___getPointCloudData_1;
	int32_t ___enableLightEstimation_2;
};
#endif // ARKITSESSIONCONFIGURATION_T318899795_H
#ifndef ARPLANEANCHOR_T1439520888_H
#define ARPLANEANCHOR_T1439520888_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.ARPlaneAnchor
struct  ARPlaneAnchor_t1439520888 
{
public:
	// System.String UnityEngine.XR.iOS.ARPlaneAnchor::identifier
	String_t* ___identifier_0;
	// UnityEngine.Matrix4x4 UnityEngine.XR.iOS.ARPlaneAnchor::transform
	Matrix4x4_t2933234003  ___transform_1;
	// UnityEngine.XR.iOS.ARPlaneAnchorAlignment UnityEngine.XR.iOS.ARPlaneAnchor::alignment
	int64_t ___alignment_2;
	// UnityEngine.Vector3 UnityEngine.XR.iOS.ARPlaneAnchor::center
	Vector3_t2243707580  ___center_3;
	// UnityEngine.Vector3 UnityEngine.XR.iOS.ARPlaneAnchor::extent
	Vector3_t2243707580  ___extent_4;

public:
	inline static int32_t get_offset_of_identifier_0() { return static_cast<int32_t>(offsetof(ARPlaneAnchor_t1439520888, ___identifier_0)); }
	inline String_t* get_identifier_0() const { return ___identifier_0; }
	inline String_t** get_address_of_identifier_0() { return &___identifier_0; }
	inline void set_identifier_0(String_t* value)
	{
		___identifier_0 = value;
		Il2CppCodeGenWriteBarrier((&___identifier_0), value);
	}

	inline static int32_t get_offset_of_transform_1() { return static_cast<int32_t>(offsetof(ARPlaneAnchor_t1439520888, ___transform_1)); }
	inline Matrix4x4_t2933234003  get_transform_1() const { return ___transform_1; }
	inline Matrix4x4_t2933234003 * get_address_of_transform_1() { return &___transform_1; }
	inline void set_transform_1(Matrix4x4_t2933234003  value)
	{
		___transform_1 = value;
	}

	inline static int32_t get_offset_of_alignment_2() { return static_cast<int32_t>(offsetof(ARPlaneAnchor_t1439520888, ___alignment_2)); }
	inline int64_t get_alignment_2() const { return ___alignment_2; }
	inline int64_t* get_address_of_alignment_2() { return &___alignment_2; }
	inline void set_alignment_2(int64_t value)
	{
		___alignment_2 = value;
	}

	inline static int32_t get_offset_of_center_3() { return static_cast<int32_t>(offsetof(ARPlaneAnchor_t1439520888, ___center_3)); }
	inline Vector3_t2243707580  get_center_3() const { return ___center_3; }
	inline Vector3_t2243707580 * get_address_of_center_3() { return &___center_3; }
	inline void set_center_3(Vector3_t2243707580  value)
	{
		___center_3 = value;
	}

	inline static int32_t get_offset_of_extent_4() { return static_cast<int32_t>(offsetof(ARPlaneAnchor_t1439520888, ___extent_4)); }
	inline Vector3_t2243707580  get_extent_4() const { return ___extent_4; }
	inline Vector3_t2243707580 * get_address_of_extent_4() { return &___extent_4; }
	inline void set_extent_4(Vector3_t2243707580  value)
	{
		___extent_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.XR.iOS.ARPlaneAnchor
struct ARPlaneAnchor_t1439520888_marshaled_pinvoke
{
	char* ___identifier_0;
	Matrix4x4_t2933234003  ___transform_1;
	int64_t ___alignment_2;
	Vector3_t2243707580  ___center_3;
	Vector3_t2243707580  ___extent_4;
};
// Native definition for COM marshalling of UnityEngine.XR.iOS.ARPlaneAnchor
struct ARPlaneAnchor_t1439520888_marshaled_com
{
	Il2CppChar* ___identifier_0;
	Matrix4x4_t2933234003  ___transform_1;
	int64_t ___alignment_2;
	Vector3_t2243707580  ___center_3;
	Vector3_t2243707580  ___extent_4;
};
#endif // ARPLANEANCHOR_T1439520888_H
#ifndef UNITYARHITTESTRESULT_T4129824344_H
#define UNITYARHITTESTRESULT_T4129824344_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARHitTestResult
struct  UnityARHitTestResult_t4129824344 
{
public:
	// UnityEngine.XR.iOS.ARHitTestResultType UnityEngine.XR.iOS.UnityARHitTestResult::type
	int64_t ___type_0;
	// System.Double UnityEngine.XR.iOS.UnityARHitTestResult::distance
	double ___distance_1;
	// UnityEngine.Matrix4x4 UnityEngine.XR.iOS.UnityARHitTestResult::localTransform
	Matrix4x4_t2933234003  ___localTransform_2;
	// UnityEngine.Matrix4x4 UnityEngine.XR.iOS.UnityARHitTestResult::worldTransform
	Matrix4x4_t2933234003  ___worldTransform_3;
	// System.IntPtr UnityEngine.XR.iOS.UnityARHitTestResult::anchor
	intptr_t ___anchor_4;
	// System.Boolean UnityEngine.XR.iOS.UnityARHitTestResult::isValid
	bool ___isValid_5;

public:
	inline static int32_t get_offset_of_type_0() { return static_cast<int32_t>(offsetof(UnityARHitTestResult_t4129824344, ___type_0)); }
	inline int64_t get_type_0() const { return ___type_0; }
	inline int64_t* get_address_of_type_0() { return &___type_0; }
	inline void set_type_0(int64_t value)
	{
		___type_0 = value;
	}

	inline static int32_t get_offset_of_distance_1() { return static_cast<int32_t>(offsetof(UnityARHitTestResult_t4129824344, ___distance_1)); }
	inline double get_distance_1() const { return ___distance_1; }
	inline double* get_address_of_distance_1() { return &___distance_1; }
	inline void set_distance_1(double value)
	{
		___distance_1 = value;
	}

	inline static int32_t get_offset_of_localTransform_2() { return static_cast<int32_t>(offsetof(UnityARHitTestResult_t4129824344, ___localTransform_2)); }
	inline Matrix4x4_t2933234003  get_localTransform_2() const { return ___localTransform_2; }
	inline Matrix4x4_t2933234003 * get_address_of_localTransform_2() { return &___localTransform_2; }
	inline void set_localTransform_2(Matrix4x4_t2933234003  value)
	{
		___localTransform_2 = value;
	}

	inline static int32_t get_offset_of_worldTransform_3() { return static_cast<int32_t>(offsetof(UnityARHitTestResult_t4129824344, ___worldTransform_3)); }
	inline Matrix4x4_t2933234003  get_worldTransform_3() const { return ___worldTransform_3; }
	inline Matrix4x4_t2933234003 * get_address_of_worldTransform_3() { return &___worldTransform_3; }
	inline void set_worldTransform_3(Matrix4x4_t2933234003  value)
	{
		___worldTransform_3 = value;
	}

	inline static int32_t get_offset_of_anchor_4() { return static_cast<int32_t>(offsetof(UnityARHitTestResult_t4129824344, ___anchor_4)); }
	inline intptr_t get_anchor_4() const { return ___anchor_4; }
	inline intptr_t* get_address_of_anchor_4() { return &___anchor_4; }
	inline void set_anchor_4(intptr_t value)
	{
		___anchor_4 = value;
	}

	inline static int32_t get_offset_of_isValid_5() { return static_cast<int32_t>(offsetof(UnityARHitTestResult_t4129824344, ___isValid_5)); }
	inline bool get_isValid_5() const { return ___isValid_5; }
	inline bool* get_address_of_isValid_5() { return &___isValid_5; }
	inline void set_isValid_5(bool value)
	{
		___isValid_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.XR.iOS.UnityARHitTestResult
struct UnityARHitTestResult_t4129824344_marshaled_pinvoke
{
	int64_t ___type_0;
	double ___distance_1;
	Matrix4x4_t2933234003  ___localTransform_2;
	Matrix4x4_t2933234003  ___worldTransform_3;
	intptr_t ___anchor_4;
	int32_t ___isValid_5;
};
// Native definition for COM marshalling of UnityEngine.XR.iOS.UnityARHitTestResult
struct UnityARHitTestResult_t4129824344_marshaled_com
{
	int64_t ___type_0;
	double ___distance_1;
	Matrix4x4_t2933234003  ___localTransform_2;
	Matrix4x4_t2933234003  ___worldTransform_3;
	intptr_t ___anchor_4;
	int32_t ___isValid_5;
};
#endif // UNITYARHITTESTRESULT_T4129824344_H
#ifndef INTERNAL_ARANCHORREMOVED_T3189755211_H
#define INTERNAL_ARANCHORREMOVED_T3189755211_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARAnchorRemoved
struct  internal_ARAnchorRemoved_t3189755211  : public MulticastDelegate_t3201952435
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INTERNAL_ARANCHORREMOVED_T3189755211_H
#ifndef INTERNAL_ARUSERANCHORADDED_T3999066834_H
#define INTERNAL_ARUSERANCHORADDED_T3999066834_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARUserAnchorAdded
struct  internal_ARUserAnchorAdded_t3999066834  : public MulticastDelegate_t3201952435
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INTERNAL_ARUSERANCHORADDED_T3999066834_H
#ifndef INTERNAL_ARUSERANCHORUPDATED_T1661963345_H
#define INTERNAL_ARUSERANCHORUPDATED_T1661963345_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARUserAnchorUpdated
struct  internal_ARUserAnchorUpdated_t1661963345  : public MulticastDelegate_t3201952435
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INTERNAL_ARUSERANCHORUPDATED_T1661963345_H
#ifndef INTERNAL_ARUSERANCHORREMOVED_T4166385952_H
#define INTERNAL_ARUSERANCHORREMOVED_T4166385952_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARUserAnchorRemoved
struct  internal_ARUserAnchorRemoved_t4166385952  : public MulticastDelegate_t3201952435
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INTERNAL_ARUSERANCHORREMOVED_T4166385952_H
#ifndef INTERNAL_ARSESSIONTRACKINGCHANGED_T1558153491_H
#define INTERNAL_ARSESSIONTRACKINGCHANGED_T1558153491_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARSessionTrackingChanged
struct  internal_ARSessionTrackingChanged_t1558153491  : public MulticastDelegate_t3201952435
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INTERNAL_ARSESSIONTRACKINGCHANGED_T1558153491_H
#ifndef ARFRAME_T1001293426_H
#define ARFRAME_T1001293426_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.ARFrame
struct  ARFrame_t1001293426 
{
public:
	// System.Double UnityEngine.XR.iOS.ARFrame::timestamp
	double ___timestamp_0;
	// System.IntPtr UnityEngine.XR.iOS.ARFrame::capturedImage
	intptr_t ___capturedImage_1;
	// UnityEngine.XR.iOS.ARCamera UnityEngine.XR.iOS.ARFrame::camera
	ARCamera_t4158705974  ___camera_2;
	// UnityEngine.XR.iOS.ARLightEstimate UnityEngine.XR.iOS.ARFrame::lightEstimate
	ARLightEstimate_t3477821059  ___lightEstimate_3;

public:
	inline static int32_t get_offset_of_timestamp_0() { return static_cast<int32_t>(offsetof(ARFrame_t1001293426, ___timestamp_0)); }
	inline double get_timestamp_0() const { return ___timestamp_0; }
	inline double* get_address_of_timestamp_0() { return &___timestamp_0; }
	inline void set_timestamp_0(double value)
	{
		___timestamp_0 = value;
	}

	inline static int32_t get_offset_of_capturedImage_1() { return static_cast<int32_t>(offsetof(ARFrame_t1001293426, ___capturedImage_1)); }
	inline intptr_t get_capturedImage_1() const { return ___capturedImage_1; }
	inline intptr_t* get_address_of_capturedImage_1() { return &___capturedImage_1; }
	inline void set_capturedImage_1(intptr_t value)
	{
		___capturedImage_1 = value;
	}

	inline static int32_t get_offset_of_camera_2() { return static_cast<int32_t>(offsetof(ARFrame_t1001293426, ___camera_2)); }
	inline ARCamera_t4158705974  get_camera_2() const { return ___camera_2; }
	inline ARCamera_t4158705974 * get_address_of_camera_2() { return &___camera_2; }
	inline void set_camera_2(ARCamera_t4158705974  value)
	{
		___camera_2 = value;
	}

	inline static int32_t get_offset_of_lightEstimate_3() { return static_cast<int32_t>(offsetof(ARFrame_t1001293426, ___lightEstimate_3)); }
	inline ARLightEstimate_t3477821059  get_lightEstimate_3() const { return ___lightEstimate_3; }
	inline ARLightEstimate_t3477821059 * get_address_of_lightEstimate_3() { return &___lightEstimate_3; }
	inline void set_lightEstimate_3(ARLightEstimate_t3477821059  value)
	{
		___lightEstimate_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARFRAME_T1001293426_H
#ifndef BEHAVIOUR_T955675639_H
#define BEHAVIOUR_T955675639_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Behaviour
struct  Behaviour_t955675639  : public Component_t3819376471
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // BEHAVIOUR_T955675639_H
#ifndef INTERNAL_ARANCHORUPDATED_T3705772742_H
#define INTERNAL_ARANCHORUPDATED_T3705772742_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARAnchorUpdated
struct  internal_ARAnchorUpdated_t3705772742  : public MulticastDelegate_t3201952435
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INTERNAL_ARANCHORUPDATED_T3705772742_H
#ifndef ARUSERANCHORADDED_T4216008690_H
#define ARUSERANCHORADDED_T4216008690_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARUserAnchorAdded
struct  ARUserAnchorAdded_t4216008690  : public MulticastDelegate_t3201952435
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARUSERANCHORADDED_T4216008690_H
#ifndef ARANCHORREMOVED_T142665927_H
#define ARANCHORREMOVED_T142665927_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARAnchorRemoved
struct  ARAnchorRemoved_t142665927  : public MulticastDelegate_t3201952435
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARANCHORREMOVED_T142665927_H
#ifndef ARANCHORUPDATED_T3886071158_H
#define ARANCHORUPDATED_T3886071158_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARAnchorUpdated
struct  ARAnchorUpdated_t3886071158  : public MulticastDelegate_t3201952435
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARANCHORUPDATED_T3886071158_H
#ifndef ARANCHORADDED_T2646854145_H
#define ARANCHORADDED_T2646854145_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARAnchorAdded
struct  ARAnchorAdded_t2646854145  : public MulticastDelegate_t3201952435
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARANCHORADDED_T2646854145_H
#ifndef ARFRAMEUPDATE_T496507918_H
#define ARFRAMEUPDATE_T496507918_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARFrameUpdate
struct  ARFrameUpdate_t496507918  : public MulticastDelegate_t3201952435
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARFRAMEUPDATE_T496507918_H
#ifndef UNITYARSESSIONNATIVEINTERFACE_T1130867170_H
#define UNITYARSESSIONNATIVEINTERFACE_T1130867170_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARSessionNativeInterface
struct  UnityARSessionNativeInterface_t1130867170  : public RuntimeObject
{
public:
	// System.IntPtr UnityEngine.XR.iOS.UnityARSessionNativeInterface::m_NativeARSession
	intptr_t ___m_NativeARSession_11;

public:
	inline static int32_t get_offset_of_m_NativeARSession_11() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170, ___m_NativeARSession_11)); }
	inline intptr_t get_m_NativeARSession_11() const { return ___m_NativeARSession_11; }
	inline intptr_t* get_address_of_m_NativeARSession_11() { return &___m_NativeARSession_11; }
	inline void set_m_NativeARSession_11(intptr_t value)
	{
		___m_NativeARSession_11 = value;
	}
};

struct UnityARSessionNativeInterface_t1130867170_StaticFields
{
public:
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARFrameUpdate UnityEngine.XR.iOS.UnityARSessionNativeInterface::ARFrameUpdatedEvent
	ARFrameUpdate_t496507918 * ___ARFrameUpdatedEvent_0;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARAnchorAdded UnityEngine.XR.iOS.UnityARSessionNativeInterface::ARAnchorAddedEvent
	ARAnchorAdded_t2646854145 * ___ARAnchorAddedEvent_1;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARAnchorUpdated UnityEngine.XR.iOS.UnityARSessionNativeInterface::ARAnchorUpdatedEvent
	ARAnchorUpdated_t3886071158 * ___ARAnchorUpdatedEvent_2;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARAnchorRemoved UnityEngine.XR.iOS.UnityARSessionNativeInterface::ARAnchorRemovedEvent
	ARAnchorRemoved_t142665927 * ___ARAnchorRemovedEvent_3;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARUserAnchorAdded UnityEngine.XR.iOS.UnityARSessionNativeInterface::ARUserAnchorAddedEvent
	ARUserAnchorAdded_t4216008690 * ___ARUserAnchorAddedEvent_4;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARUserAnchorUpdated UnityEngine.XR.iOS.UnityARSessionNativeInterface::ARUserAnchorUpdatedEvent
	ARUserAnchorUpdated_t1104644293 * ___ARUserAnchorUpdatedEvent_5;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARUserAnchorRemoved UnityEngine.XR.iOS.UnityARSessionNativeInterface::ARUserAnchorRemovedEvent
	ARUserAnchorRemoved_t1656212632 * ___ARUserAnchorRemovedEvent_6;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARSessionFailed UnityEngine.XR.iOS.UnityARSessionNativeInterface::ARSessionFailedEvent
	ARSessionFailed_t872580813 * ___ARSessionFailedEvent_7;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARSessionCallback UnityEngine.XR.iOS.UnityARSessionNativeInterface::ARSessionInterruptedEvent
	ARSessionCallback_t3370800699 * ___ARSessionInterruptedEvent_8;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARSessionCallback UnityEngine.XR.iOS.UnityARSessionNativeInterface::ARSessioninterruptionEndedEvent
	ARSessionCallback_t3370800699 * ___ARSessioninterruptionEndedEvent_9;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARSessionTrackingChanged UnityEngine.XR.iOS.UnityARSessionNativeInterface::ARSessionTrackingChangedEvent
	ARSessionTrackingChanged_t1333006279 * ___ARSessionTrackingChangedEvent_10;
	// System.Boolean UnityEngine.XR.iOS.UnityARSessionNativeInterface::tracker_enabled
	bool ___tracker_enabled_12;
	// UnityEngine.Vector4 UnityEngine.XR.iOS.UnityARSessionNativeInterface::tracker_position
	Vector4_t2243707581  ___tracker_position_13;
	// UnityEngine.Quaternion UnityEngine.XR.iOS.UnityARSessionNativeInterface::tracker_rotation
	Quaternion_t4030073918  ___tracker_rotation_14;
	// UnityEngine.Vector4 UnityEngine.XR.iOS.UnityARSessionNativeInterface::offset_position
	Vector4_t2243707581  ___offset_position_15;
	// UnityEngine.Quaternion UnityEngine.XR.iOS.UnityARSessionNativeInterface::offset_rotation
	Quaternion_t4030073918  ___offset_rotation_16;
	// UnityEngine.XR.iOS.UnityARMatrix4x4 UnityEngine.XR.iOS.UnityARSessionNativeInterface::lastARKitWorldTransform
	UnityARMatrix4x4_t100931615  ___lastARKitWorldTransform_17;
	// UnityEngine.XR.iOS.UnityARMatrix4x4 UnityEngine.XR.iOS.UnityARSessionNativeInterface::customWorldTransform
	UnityARMatrix4x4_t100931615  ___customWorldTransform_18;
	// UnityEngine.XR.iOS.UnityARCamera UnityEngine.XR.iOS.UnityARSessionNativeInterface::s_Camera
	UnityARCamera_t4198559457  ___s_Camera_19;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface UnityEngine.XR.iOS.UnityARSessionNativeInterface::s_UnityARSessionNativeInterface
	UnityARSessionNativeInterface_t1130867170 * ___s_UnityARSessionNativeInterface_20;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARFrameUpdate UnityEngine.XR.iOS.UnityARSessionNativeInterface::<>f__mg$cache0
	internal_ARFrameUpdate_t3296518558 * ___U3CU3Ef__mgU24cache0_21;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARSessionFailed UnityEngine.XR.iOS.UnityARSessionNativeInterface::<>f__mg$cache1
	ARSessionFailed_t872580813 * ___U3CU3Ef__mgU24cache1_22;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARSessionCallback UnityEngine.XR.iOS.UnityARSessionNativeInterface::<>f__mg$cache2
	ARSessionCallback_t3370800699 * ___U3CU3Ef__mgU24cache2_23;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARSessionCallback UnityEngine.XR.iOS.UnityARSessionNativeInterface::<>f__mg$cache3
	ARSessionCallback_t3370800699 * ___U3CU3Ef__mgU24cache3_24;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARSessionTrackingChanged UnityEngine.XR.iOS.UnityARSessionNativeInterface::<>f__mg$cache4
	internal_ARSessionTrackingChanged_t1558153491 * ___U3CU3Ef__mgU24cache4_25;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARAnchorAdded UnityEngine.XR.iOS.UnityARSessionNativeInterface::<>f__mg$cache5
	internal_ARAnchorAdded_t1622117597 * ___U3CU3Ef__mgU24cache5_26;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARAnchorUpdated UnityEngine.XR.iOS.UnityARSessionNativeInterface::<>f__mg$cache6
	internal_ARAnchorUpdated_t3705772742 * ___U3CU3Ef__mgU24cache6_27;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARAnchorRemoved UnityEngine.XR.iOS.UnityARSessionNativeInterface::<>f__mg$cache7
	internal_ARAnchorRemoved_t3189755211 * ___U3CU3Ef__mgU24cache7_28;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARUserAnchorAdded UnityEngine.XR.iOS.UnityARSessionNativeInterface::<>f__mg$cache8
	internal_ARUserAnchorAdded_t3999066834 * ___U3CU3Ef__mgU24cache8_29;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARUserAnchorUpdated UnityEngine.XR.iOS.UnityARSessionNativeInterface::<>f__mg$cache9
	internal_ARUserAnchorUpdated_t1661963345 * ___U3CU3Ef__mgU24cache9_30;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARUserAnchorRemoved UnityEngine.XR.iOS.UnityARSessionNativeInterface::<>f__mg$cacheA
	internal_ARUserAnchorRemoved_t4166385952 * ___U3CU3Ef__mgU24cacheA_31;

public:
	inline static int32_t get_offset_of_ARFrameUpdatedEvent_0() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___ARFrameUpdatedEvent_0)); }
	inline ARFrameUpdate_t496507918 * get_ARFrameUpdatedEvent_0() const { return ___ARFrameUpdatedEvent_0; }
	inline ARFrameUpdate_t496507918 ** get_address_of_ARFrameUpdatedEvent_0() { return &___ARFrameUpdatedEvent_0; }
	inline void set_ARFrameUpdatedEvent_0(ARFrameUpdate_t496507918 * value)
	{
		___ARFrameUpdatedEvent_0 = value;
		Il2CppCodeGenWriteBarrier((&___ARFrameUpdatedEvent_0), value);
	}

	inline static int32_t get_offset_of_ARAnchorAddedEvent_1() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___ARAnchorAddedEvent_1)); }
	inline ARAnchorAdded_t2646854145 * get_ARAnchorAddedEvent_1() const { return ___ARAnchorAddedEvent_1; }
	inline ARAnchorAdded_t2646854145 ** get_address_of_ARAnchorAddedEvent_1() { return &___ARAnchorAddedEvent_1; }
	inline void set_ARAnchorAddedEvent_1(ARAnchorAdded_t2646854145 * value)
	{
		___ARAnchorAddedEvent_1 = value;
		Il2CppCodeGenWriteBarrier((&___ARAnchorAddedEvent_1), value);
	}

	inline static int32_t get_offset_of_ARAnchorUpdatedEvent_2() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___ARAnchorUpdatedEvent_2)); }
	inline ARAnchorUpdated_t3886071158 * get_ARAnchorUpdatedEvent_2() const { return ___ARAnchorUpdatedEvent_2; }
	inline ARAnchorUpdated_t3886071158 ** get_address_of_ARAnchorUpdatedEvent_2() { return &___ARAnchorUpdatedEvent_2; }
	inline void set_ARAnchorUpdatedEvent_2(ARAnchorUpdated_t3886071158 * value)
	{
		___ARAnchorUpdatedEvent_2 = value;
		Il2CppCodeGenWriteBarrier((&___ARAnchorUpdatedEvent_2), value);
	}

	inline static int32_t get_offset_of_ARAnchorRemovedEvent_3() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___ARAnchorRemovedEvent_3)); }
	inline ARAnchorRemoved_t142665927 * get_ARAnchorRemovedEvent_3() const { return ___ARAnchorRemovedEvent_3; }
	inline ARAnchorRemoved_t142665927 ** get_address_of_ARAnchorRemovedEvent_3() { return &___ARAnchorRemovedEvent_3; }
	inline void set_ARAnchorRemovedEvent_3(ARAnchorRemoved_t142665927 * value)
	{
		___ARAnchorRemovedEvent_3 = value;
		Il2CppCodeGenWriteBarrier((&___ARAnchorRemovedEvent_3), value);
	}

	inline static int32_t get_offset_of_ARUserAnchorAddedEvent_4() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___ARUserAnchorAddedEvent_4)); }
	inline ARUserAnchorAdded_t4216008690 * get_ARUserAnchorAddedEvent_4() const { return ___ARUserAnchorAddedEvent_4; }
	inline ARUserAnchorAdded_t4216008690 ** get_address_of_ARUserAnchorAddedEvent_4() { return &___ARUserAnchorAddedEvent_4; }
	inline void set_ARUserAnchorAddedEvent_4(ARUserAnchorAdded_t4216008690 * value)
	{
		___ARUserAnchorAddedEvent_4 = value;
		Il2CppCodeGenWriteBarrier((&___ARUserAnchorAddedEvent_4), value);
	}

	inline static int32_t get_offset_of_ARUserAnchorUpdatedEvent_5() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___ARUserAnchorUpdatedEvent_5)); }
	inline ARUserAnchorUpdated_t1104644293 * get_ARUserAnchorUpdatedEvent_5() const { return ___ARUserAnchorUpdatedEvent_5; }
	inline ARUserAnchorUpdated_t1104644293 ** get_address_of_ARUserAnchorUpdatedEvent_5() { return &___ARUserAnchorUpdatedEvent_5; }
	inline void set_ARUserAnchorUpdatedEvent_5(ARUserAnchorUpdated_t1104644293 * value)
	{
		___ARUserAnchorUpdatedEvent_5 = value;
		Il2CppCodeGenWriteBarrier((&___ARUserAnchorUpdatedEvent_5), value);
	}

	inline static int32_t get_offset_of_ARUserAnchorRemovedEvent_6() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___ARUserAnchorRemovedEvent_6)); }
	inline ARUserAnchorRemoved_t1656212632 * get_ARUserAnchorRemovedEvent_6() const { return ___ARUserAnchorRemovedEvent_6; }
	inline ARUserAnchorRemoved_t1656212632 ** get_address_of_ARUserAnchorRemovedEvent_6() { return &___ARUserAnchorRemovedEvent_6; }
	inline void set_ARUserAnchorRemovedEvent_6(ARUserAnchorRemoved_t1656212632 * value)
	{
		___ARUserAnchorRemovedEvent_6 = value;
		Il2CppCodeGenWriteBarrier((&___ARUserAnchorRemovedEvent_6), value);
	}

	inline static int32_t get_offset_of_ARSessionFailedEvent_7() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___ARSessionFailedEvent_7)); }
	inline ARSessionFailed_t872580813 * get_ARSessionFailedEvent_7() const { return ___ARSessionFailedEvent_7; }
	inline ARSessionFailed_t872580813 ** get_address_of_ARSessionFailedEvent_7() { return &___ARSessionFailedEvent_7; }
	inline void set_ARSessionFailedEvent_7(ARSessionFailed_t872580813 * value)
	{
		___ARSessionFailedEvent_7 = value;
		Il2CppCodeGenWriteBarrier((&___ARSessionFailedEvent_7), value);
	}

	inline static int32_t get_offset_of_ARSessionInterruptedEvent_8() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___ARSessionInterruptedEvent_8)); }
	inline ARSessionCallback_t3370800699 * get_ARSessionInterruptedEvent_8() const { return ___ARSessionInterruptedEvent_8; }
	inline ARSessionCallback_t3370800699 ** get_address_of_ARSessionInterruptedEvent_8() { return &___ARSessionInterruptedEvent_8; }
	inline void set_ARSessionInterruptedEvent_8(ARSessionCallback_t3370800699 * value)
	{
		___ARSessionInterruptedEvent_8 = value;
		Il2CppCodeGenWriteBarrier((&___ARSessionInterruptedEvent_8), value);
	}

	inline static int32_t get_offset_of_ARSessioninterruptionEndedEvent_9() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___ARSessioninterruptionEndedEvent_9)); }
	inline ARSessionCallback_t3370800699 * get_ARSessioninterruptionEndedEvent_9() const { return ___ARSessioninterruptionEndedEvent_9; }
	inline ARSessionCallback_t3370800699 ** get_address_of_ARSessioninterruptionEndedEvent_9() { return &___ARSessioninterruptionEndedEvent_9; }
	inline void set_ARSessioninterruptionEndedEvent_9(ARSessionCallback_t3370800699 * value)
	{
		___ARSessioninterruptionEndedEvent_9 = value;
		Il2CppCodeGenWriteBarrier((&___ARSessioninterruptionEndedEvent_9), value);
	}

	inline static int32_t get_offset_of_ARSessionTrackingChangedEvent_10() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___ARSessionTrackingChangedEvent_10)); }
	inline ARSessionTrackingChanged_t1333006279 * get_ARSessionTrackingChangedEvent_10() const { return ___ARSessionTrackingChangedEvent_10; }
	inline ARSessionTrackingChanged_t1333006279 ** get_address_of_ARSessionTrackingChangedEvent_10() { return &___ARSessionTrackingChangedEvent_10; }
	inline void set_ARSessionTrackingChangedEvent_10(ARSessionTrackingChanged_t1333006279 * value)
	{
		___ARSessionTrackingChangedEvent_10 = value;
		Il2CppCodeGenWriteBarrier((&___ARSessionTrackingChangedEvent_10), value);
	}

	inline static int32_t get_offset_of_tracker_enabled_12() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___tracker_enabled_12)); }
	inline bool get_tracker_enabled_12() const { return ___tracker_enabled_12; }
	inline bool* get_address_of_tracker_enabled_12() { return &___tracker_enabled_12; }
	inline void set_tracker_enabled_12(bool value)
	{
		___tracker_enabled_12 = value;
	}

	inline static int32_t get_offset_of_tracker_position_13() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___tracker_position_13)); }
	inline Vector4_t2243707581  get_tracker_position_13() const { return ___tracker_position_13; }
	inline Vector4_t2243707581 * get_address_of_tracker_position_13() { return &___tracker_position_13; }
	inline void set_tracker_position_13(Vector4_t2243707581  value)
	{
		___tracker_position_13 = value;
	}

	inline static int32_t get_offset_of_tracker_rotation_14() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___tracker_rotation_14)); }
	inline Quaternion_t4030073918  get_tracker_rotation_14() const { return ___tracker_rotation_14; }
	inline Quaternion_t4030073918 * get_address_of_tracker_rotation_14() { return &___tracker_rotation_14; }
	inline void set_tracker_rotation_14(Quaternion_t4030073918  value)
	{
		___tracker_rotation_14 = value;
	}

	inline static int32_t get_offset_of_offset_position_15() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___offset_position_15)); }
	inline Vector4_t2243707581  get_offset_position_15() const { return ___offset_position_15; }
	inline Vector4_t2243707581 * get_address_of_offset_position_15() { return &___offset_position_15; }
	inline void set_offset_position_15(Vector4_t2243707581  value)
	{
		___offset_position_15 = value;
	}

	inline static int32_t get_offset_of_offset_rotation_16() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___offset_rotation_16)); }
	inline Quaternion_t4030073918  get_offset_rotation_16() const { return ___offset_rotation_16; }
	inline Quaternion_t4030073918 * get_address_of_offset_rotation_16() { return &___offset_rotation_16; }
	inline void set_offset_rotation_16(Quaternion_t4030073918  value)
	{
		___offset_rotation_16 = value;
	}

	inline static int32_t get_offset_of_lastARKitWorldTransform_17() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___lastARKitWorldTransform_17)); }
	inline UnityARMatrix4x4_t100931615  get_lastARKitWorldTransform_17() const { return ___lastARKitWorldTransform_17; }
	inline UnityARMatrix4x4_t100931615 * get_address_of_lastARKitWorldTransform_17() { return &___lastARKitWorldTransform_17; }
	inline void set_lastARKitWorldTransform_17(UnityARMatrix4x4_t100931615  value)
	{
		___lastARKitWorldTransform_17 = value;
	}

	inline static int32_t get_offset_of_customWorldTransform_18() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___customWorldTransform_18)); }
	inline UnityARMatrix4x4_t100931615  get_customWorldTransform_18() const { return ___customWorldTransform_18; }
	inline UnityARMatrix4x4_t100931615 * get_address_of_customWorldTransform_18() { return &___customWorldTransform_18; }
	inline void set_customWorldTransform_18(UnityARMatrix4x4_t100931615  value)
	{
		___customWorldTransform_18 = value;
	}

	inline static int32_t get_offset_of_s_Camera_19() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___s_Camera_19)); }
	inline UnityARCamera_t4198559457  get_s_Camera_19() const { return ___s_Camera_19; }
	inline UnityARCamera_t4198559457 * get_address_of_s_Camera_19() { return &___s_Camera_19; }
	inline void set_s_Camera_19(UnityARCamera_t4198559457  value)
	{
		___s_Camera_19 = value;
	}

	inline static int32_t get_offset_of_s_UnityARSessionNativeInterface_20() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___s_UnityARSessionNativeInterface_20)); }
	inline UnityARSessionNativeInterface_t1130867170 * get_s_UnityARSessionNativeInterface_20() const { return ___s_UnityARSessionNativeInterface_20; }
	inline UnityARSessionNativeInterface_t1130867170 ** get_address_of_s_UnityARSessionNativeInterface_20() { return &___s_UnityARSessionNativeInterface_20; }
	inline void set_s_UnityARSessionNativeInterface_20(UnityARSessionNativeInterface_t1130867170 * value)
	{
		___s_UnityARSessionNativeInterface_20 = value;
		Il2CppCodeGenWriteBarrier((&___s_UnityARSessionNativeInterface_20), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache0_21() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___U3CU3Ef__mgU24cache0_21)); }
	inline internal_ARFrameUpdate_t3296518558 * get_U3CU3Ef__mgU24cache0_21() const { return ___U3CU3Ef__mgU24cache0_21; }
	inline internal_ARFrameUpdate_t3296518558 ** get_address_of_U3CU3Ef__mgU24cache0_21() { return &___U3CU3Ef__mgU24cache0_21; }
	inline void set_U3CU3Ef__mgU24cache0_21(internal_ARFrameUpdate_t3296518558 * value)
	{
		___U3CU3Ef__mgU24cache0_21 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cache0_21), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache1_22() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___U3CU3Ef__mgU24cache1_22)); }
	inline ARSessionFailed_t872580813 * get_U3CU3Ef__mgU24cache1_22() const { return ___U3CU3Ef__mgU24cache1_22; }
	inline ARSessionFailed_t872580813 ** get_address_of_U3CU3Ef__mgU24cache1_22() { return &___U3CU3Ef__mgU24cache1_22; }
	inline void set_U3CU3Ef__mgU24cache1_22(ARSessionFailed_t872580813 * value)
	{
		___U3CU3Ef__mgU24cache1_22 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cache1_22), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache2_23() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___U3CU3Ef__mgU24cache2_23)); }
	inline ARSessionCallback_t3370800699 * get_U3CU3Ef__mgU24cache2_23() const { return ___U3CU3Ef__mgU24cache2_23; }
	inline ARSessionCallback_t3370800699 ** get_address_of_U3CU3Ef__mgU24cache2_23() { return &___U3CU3Ef__mgU24cache2_23; }
	inline void set_U3CU3Ef__mgU24cache2_23(ARSessionCallback_t3370800699 * value)
	{
		___U3CU3Ef__mgU24cache2_23 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cache2_23), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache3_24() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___U3CU3Ef__mgU24cache3_24)); }
	inline ARSessionCallback_t3370800699 * get_U3CU3Ef__mgU24cache3_24() const { return ___U3CU3Ef__mgU24cache3_24; }
	inline ARSessionCallback_t3370800699 ** get_address_of_U3CU3Ef__mgU24cache3_24() { return &___U3CU3Ef__mgU24cache3_24; }
	inline void set_U3CU3Ef__mgU24cache3_24(ARSessionCallback_t3370800699 * value)
	{
		___U3CU3Ef__mgU24cache3_24 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cache3_24), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache4_25() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___U3CU3Ef__mgU24cache4_25)); }
	inline internal_ARSessionTrackingChanged_t1558153491 * get_U3CU3Ef__mgU24cache4_25() const { return ___U3CU3Ef__mgU24cache4_25; }
	inline internal_ARSessionTrackingChanged_t1558153491 ** get_address_of_U3CU3Ef__mgU24cache4_25() { return &___U3CU3Ef__mgU24cache4_25; }
	inline void set_U3CU3Ef__mgU24cache4_25(internal_ARSessionTrackingChanged_t1558153491 * value)
	{
		___U3CU3Ef__mgU24cache4_25 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cache4_25), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache5_26() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___U3CU3Ef__mgU24cache5_26)); }
	inline internal_ARAnchorAdded_t1622117597 * get_U3CU3Ef__mgU24cache5_26() const { return ___U3CU3Ef__mgU24cache5_26; }
	inline internal_ARAnchorAdded_t1622117597 ** get_address_of_U3CU3Ef__mgU24cache5_26() { return &___U3CU3Ef__mgU24cache5_26; }
	inline void set_U3CU3Ef__mgU24cache5_26(internal_ARAnchorAdded_t1622117597 * value)
	{
		___U3CU3Ef__mgU24cache5_26 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cache5_26), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache6_27() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___U3CU3Ef__mgU24cache6_27)); }
	inline internal_ARAnchorUpdated_t3705772742 * get_U3CU3Ef__mgU24cache6_27() const { return ___U3CU3Ef__mgU24cache6_27; }
	inline internal_ARAnchorUpdated_t3705772742 ** get_address_of_U3CU3Ef__mgU24cache6_27() { return &___U3CU3Ef__mgU24cache6_27; }
	inline void set_U3CU3Ef__mgU24cache6_27(internal_ARAnchorUpdated_t3705772742 * value)
	{
		___U3CU3Ef__mgU24cache6_27 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cache6_27), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache7_28() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___U3CU3Ef__mgU24cache7_28)); }
	inline internal_ARAnchorRemoved_t3189755211 * get_U3CU3Ef__mgU24cache7_28() const { return ___U3CU3Ef__mgU24cache7_28; }
	inline internal_ARAnchorRemoved_t3189755211 ** get_address_of_U3CU3Ef__mgU24cache7_28() { return &___U3CU3Ef__mgU24cache7_28; }
	inline void set_U3CU3Ef__mgU24cache7_28(internal_ARAnchorRemoved_t3189755211 * value)
	{
		___U3CU3Ef__mgU24cache7_28 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cache7_28), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache8_29() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___U3CU3Ef__mgU24cache8_29)); }
	inline internal_ARUserAnchorAdded_t3999066834 * get_U3CU3Ef__mgU24cache8_29() const { return ___U3CU3Ef__mgU24cache8_29; }
	inline internal_ARUserAnchorAdded_t3999066834 ** get_address_of_U3CU3Ef__mgU24cache8_29() { return &___U3CU3Ef__mgU24cache8_29; }
	inline void set_U3CU3Ef__mgU24cache8_29(internal_ARUserAnchorAdded_t3999066834 * value)
	{
		___U3CU3Ef__mgU24cache8_29 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cache8_29), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cache9_30() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___U3CU3Ef__mgU24cache9_30)); }
	inline internal_ARUserAnchorUpdated_t1661963345 * get_U3CU3Ef__mgU24cache9_30() const { return ___U3CU3Ef__mgU24cache9_30; }
	inline internal_ARUserAnchorUpdated_t1661963345 ** get_address_of_U3CU3Ef__mgU24cache9_30() { return &___U3CU3Ef__mgU24cache9_30; }
	inline void set_U3CU3Ef__mgU24cache9_30(internal_ARUserAnchorUpdated_t1661963345 * value)
	{
		___U3CU3Ef__mgU24cache9_30 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cache9_30), value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__mgU24cacheA_31() { return static_cast<int32_t>(offsetof(UnityARSessionNativeInterface_t1130867170_StaticFields, ___U3CU3Ef__mgU24cacheA_31)); }
	inline internal_ARUserAnchorRemoved_t4166385952 * get_U3CU3Ef__mgU24cacheA_31() const { return ___U3CU3Ef__mgU24cacheA_31; }
	inline internal_ARUserAnchorRemoved_t4166385952 ** get_address_of_U3CU3Ef__mgU24cacheA_31() { return &___U3CU3Ef__mgU24cacheA_31; }
	inline void set_U3CU3Ef__mgU24cacheA_31(internal_ARUserAnchorRemoved_t4166385952 * value)
	{
		___U3CU3Ef__mgU24cacheA_31 = value;
		Il2CppCodeGenWriteBarrier((&___U3CU3Ef__mgU24cacheA_31), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYARSESSIONNATIVEINTERFACE_T1130867170_H
#ifndef ARUSERANCHORUPDATED_T1104644293_H
#define ARUSERANCHORUPDATED_T1104644293_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARUserAnchorUpdated
struct  ARUserAnchorUpdated_t1104644293  : public MulticastDelegate_t3201952435
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARUSERANCHORUPDATED_T1104644293_H
#ifndef ARSESSIONTRACKINGCHANGED_T1333006279_H
#define ARSESSIONTRACKINGCHANGED_T1333006279_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARSessionTrackingChanged
struct  ARSessionTrackingChanged_t1333006279  : public MulticastDelegate_t3201952435
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARSESSIONTRACKINGCHANGED_T1333006279_H
#ifndef INTERNAL_ARFRAMEUPDATE_T3296518558_H
#define INTERNAL_ARFRAMEUPDATE_T3296518558_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARFrameUpdate
struct  internal_ARFrameUpdate_t3296518558  : public MulticastDelegate_t3201952435
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INTERNAL_ARFRAMEUPDATE_T3296518558_H
#ifndef INTERNAL_ARANCHORADDED_T1622117597_H
#define INTERNAL_ARANCHORADDED_T1622117597_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARSessionNativeInterface/internal_ARAnchorAdded
struct  internal_ARAnchorAdded_t1622117597  : public MulticastDelegate_t3201952435
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INTERNAL_ARANCHORADDED_T1622117597_H
#ifndef ARSESSIONCALLBACK_T3370800699_H
#define ARSESSIONCALLBACK_T3370800699_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARSessionCallback
struct  ARSessionCallback_t3370800699  : public MulticastDelegate_t3201952435
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARSESSIONCALLBACK_T3370800699_H
#ifndef ARSESSIONFAILED_T872580813_H
#define ARSESSIONFAILED_T872580813_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARSessionFailed
struct  ARSessionFailed_t872580813  : public MulticastDelegate_t3201952435
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARSESSIONFAILED_T872580813_H
#ifndef ARUSERANCHORREMOVED_T1656212632_H
#define ARUSERANCHORREMOVED_T1656212632_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARSessionNativeInterface/ARUserAnchorRemoved
struct  ARUserAnchorRemoved_t1656212632  : public MulticastDelegate_t3201952435
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // ARUSERANCHORREMOVED_T1656212632_H
#ifndef MONOBEHAVIOUR_T1158329972_H
#define MONOBEHAVIOUR_T1158329972_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.MonoBehaviour
struct  MonoBehaviour_t1158329972  : public Behaviour_t955675639
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MONOBEHAVIOUR_T1158329972_H
#ifndef UNITYARCAMERAMANAGER_T2138856896_H
#define UNITYARCAMERAMANAGER_T2138856896_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityARCameraManager
struct  UnityARCameraManager_t2138856896  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Camera UnityARCameraManager::m_camera
	Camera_t189460977 * ___m_camera_2;
	// UnityEngine.XR.iOS.UnityARSessionNativeInterface UnityARCameraManager::m_session
	UnityARSessionNativeInterface_t1130867170 * ___m_session_3;
	// UnityEngine.Material UnityARCameraManager::savedClearMaterial
	Material_t193706927 * ___savedClearMaterial_4;
	// UnityEngine.XR.iOS.UnityARAlignment UnityARCameraManager::startAlignment
	int32_t ___startAlignment_5;
	// UnityEngine.XR.iOS.UnityARPlaneDetection UnityARCameraManager::planeDetection
	int32_t ___planeDetection_6;
	// System.Boolean UnityARCameraManager::htcTrackerRelayEnabled
	bool ___htcTrackerRelayEnabled_7;
	// System.Boolean UnityARCameraManager::htcTrackerOffsetEnabled
	bool ___htcTrackerOffsetEnabled_8;
	// System.Boolean UnityARCameraManager::getPointCloud
	bool ___getPointCloud_9;
	// System.Boolean UnityARCameraManager::enableLightEstimation
	bool ___enableLightEstimation_10;
	// UnityEngine.Vector4 UnityARCameraManager::tracker_position
	Vector4_t2243707581  ___tracker_position_11;
	// UnityEngine.Quaternion UnityARCameraManager::tracker_rotation
	Quaternion_t4030073918  ___tracker_rotation_12;
	// UnityEngine.Vector4 UnityARCameraManager::arkit_position
	Vector4_t2243707581  ___arkit_position_13;
	// UnityEngine.Quaternion UnityARCameraManager::arkit_rotation
	Quaternion_t4030073918  ___arkit_rotation_14;
	// UnityEngine.Vector4 UnityARCameraManager::offset_position
	Vector4_t2243707581  ___offset_position_15;
	// UnityEngine.Quaternion UnityARCameraManager::offset_rotation
	Quaternion_t4030073918  ___offset_rotation_16;

public:
	inline static int32_t get_offset_of_m_camera_2() { return static_cast<int32_t>(offsetof(UnityARCameraManager_t2138856896, ___m_camera_2)); }
	inline Camera_t189460977 * get_m_camera_2() const { return ___m_camera_2; }
	inline Camera_t189460977 ** get_address_of_m_camera_2() { return &___m_camera_2; }
	inline void set_m_camera_2(Camera_t189460977 * value)
	{
		___m_camera_2 = value;
		Il2CppCodeGenWriteBarrier((&___m_camera_2), value);
	}

	inline static int32_t get_offset_of_m_session_3() { return static_cast<int32_t>(offsetof(UnityARCameraManager_t2138856896, ___m_session_3)); }
	inline UnityARSessionNativeInterface_t1130867170 * get_m_session_3() const { return ___m_session_3; }
	inline UnityARSessionNativeInterface_t1130867170 ** get_address_of_m_session_3() { return &___m_session_3; }
	inline void set_m_session_3(UnityARSessionNativeInterface_t1130867170 * value)
	{
		___m_session_3 = value;
		Il2CppCodeGenWriteBarrier((&___m_session_3), value);
	}

	inline static int32_t get_offset_of_savedClearMaterial_4() { return static_cast<int32_t>(offsetof(UnityARCameraManager_t2138856896, ___savedClearMaterial_4)); }
	inline Material_t193706927 * get_savedClearMaterial_4() const { return ___savedClearMaterial_4; }
	inline Material_t193706927 ** get_address_of_savedClearMaterial_4() { return &___savedClearMaterial_4; }
	inline void set_savedClearMaterial_4(Material_t193706927 * value)
	{
		___savedClearMaterial_4 = value;
		Il2CppCodeGenWriteBarrier((&___savedClearMaterial_4), value);
	}

	inline static int32_t get_offset_of_startAlignment_5() { return static_cast<int32_t>(offsetof(UnityARCameraManager_t2138856896, ___startAlignment_5)); }
	inline int32_t get_startAlignment_5() const { return ___startAlignment_5; }
	inline int32_t* get_address_of_startAlignment_5() { return &___startAlignment_5; }
	inline void set_startAlignment_5(int32_t value)
	{
		___startAlignment_5 = value;
	}

	inline static int32_t get_offset_of_planeDetection_6() { return static_cast<int32_t>(offsetof(UnityARCameraManager_t2138856896, ___planeDetection_6)); }
	inline int32_t get_planeDetection_6() const { return ___planeDetection_6; }
	inline int32_t* get_address_of_planeDetection_6() { return &___planeDetection_6; }
	inline void set_planeDetection_6(int32_t value)
	{
		___planeDetection_6 = value;
	}

	inline static int32_t get_offset_of_htcTrackerRelayEnabled_7() { return static_cast<int32_t>(offsetof(UnityARCameraManager_t2138856896, ___htcTrackerRelayEnabled_7)); }
	inline bool get_htcTrackerRelayEnabled_7() const { return ___htcTrackerRelayEnabled_7; }
	inline bool* get_address_of_htcTrackerRelayEnabled_7() { return &___htcTrackerRelayEnabled_7; }
	inline void set_htcTrackerRelayEnabled_7(bool value)
	{
		___htcTrackerRelayEnabled_7 = value;
	}

	inline static int32_t get_offset_of_htcTrackerOffsetEnabled_8() { return static_cast<int32_t>(offsetof(UnityARCameraManager_t2138856896, ___htcTrackerOffsetEnabled_8)); }
	inline bool get_htcTrackerOffsetEnabled_8() const { return ___htcTrackerOffsetEnabled_8; }
	inline bool* get_address_of_htcTrackerOffsetEnabled_8() { return &___htcTrackerOffsetEnabled_8; }
	inline void set_htcTrackerOffsetEnabled_8(bool value)
	{
		___htcTrackerOffsetEnabled_8 = value;
	}

	inline static int32_t get_offset_of_getPointCloud_9() { return static_cast<int32_t>(offsetof(UnityARCameraManager_t2138856896, ___getPointCloud_9)); }
	inline bool get_getPointCloud_9() const { return ___getPointCloud_9; }
	inline bool* get_address_of_getPointCloud_9() { return &___getPointCloud_9; }
	inline void set_getPointCloud_9(bool value)
	{
		___getPointCloud_9 = value;
	}

	inline static int32_t get_offset_of_enableLightEstimation_10() { return static_cast<int32_t>(offsetof(UnityARCameraManager_t2138856896, ___enableLightEstimation_10)); }
	inline bool get_enableLightEstimation_10() const { return ___enableLightEstimation_10; }
	inline bool* get_address_of_enableLightEstimation_10() { return &___enableLightEstimation_10; }
	inline void set_enableLightEstimation_10(bool value)
	{
		___enableLightEstimation_10 = value;
	}

	inline static int32_t get_offset_of_tracker_position_11() { return static_cast<int32_t>(offsetof(UnityARCameraManager_t2138856896, ___tracker_position_11)); }
	inline Vector4_t2243707581  get_tracker_position_11() const { return ___tracker_position_11; }
	inline Vector4_t2243707581 * get_address_of_tracker_position_11() { return &___tracker_position_11; }
	inline void set_tracker_position_11(Vector4_t2243707581  value)
	{
		___tracker_position_11 = value;
	}

	inline static int32_t get_offset_of_tracker_rotation_12() { return static_cast<int32_t>(offsetof(UnityARCameraManager_t2138856896, ___tracker_rotation_12)); }
	inline Quaternion_t4030073918  get_tracker_rotation_12() const { return ___tracker_rotation_12; }
	inline Quaternion_t4030073918 * get_address_of_tracker_rotation_12() { return &___tracker_rotation_12; }
	inline void set_tracker_rotation_12(Quaternion_t4030073918  value)
	{
		___tracker_rotation_12 = value;
	}

	inline static int32_t get_offset_of_arkit_position_13() { return static_cast<int32_t>(offsetof(UnityARCameraManager_t2138856896, ___arkit_position_13)); }
	inline Vector4_t2243707581  get_arkit_position_13() const { return ___arkit_position_13; }
	inline Vector4_t2243707581 * get_address_of_arkit_position_13() { return &___arkit_position_13; }
	inline void set_arkit_position_13(Vector4_t2243707581  value)
	{
		___arkit_position_13 = value;
	}

	inline static int32_t get_offset_of_arkit_rotation_14() { return static_cast<int32_t>(offsetof(UnityARCameraManager_t2138856896, ___arkit_rotation_14)); }
	inline Quaternion_t4030073918  get_arkit_rotation_14() const { return ___arkit_rotation_14; }
	inline Quaternion_t4030073918 * get_address_of_arkit_rotation_14() { return &___arkit_rotation_14; }
	inline void set_arkit_rotation_14(Quaternion_t4030073918  value)
	{
		___arkit_rotation_14 = value;
	}

	inline static int32_t get_offset_of_offset_position_15() { return static_cast<int32_t>(offsetof(UnityARCameraManager_t2138856896, ___offset_position_15)); }
	inline Vector4_t2243707581  get_offset_position_15() const { return ___offset_position_15; }
	inline Vector4_t2243707581 * get_address_of_offset_position_15() { return &___offset_position_15; }
	inline void set_offset_position_15(Vector4_t2243707581  value)
	{
		___offset_position_15 = value;
	}

	inline static int32_t get_offset_of_offset_rotation_16() { return static_cast<int32_t>(offsetof(UnityARCameraManager_t2138856896, ___offset_rotation_16)); }
	inline Quaternion_t4030073918  get_offset_rotation_16() const { return ___offset_rotation_16; }
	inline Quaternion_t4030073918 * get_address_of_offset_rotation_16() { return &___offset_rotation_16; }
	inline void set_offset_rotation_16(Quaternion_t4030073918  value)
	{
		___offset_rotation_16 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYARCAMERAMANAGER_T2138856896_H
#ifndef UNITYARCAMERANEARFAR_T519802600_H
#define UNITYARCAMERANEARFAR_T519802600_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityARCameraNearFar
struct  UnityARCameraNearFar_t519802600  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Camera UnityARCameraNearFar::attachedCamera
	Camera_t189460977 * ___attachedCamera_2;
	// System.Single UnityARCameraNearFar::currentNearZ
	float ___currentNearZ_3;
	// System.Single UnityARCameraNearFar::currentFarZ
	float ___currentFarZ_4;

public:
	inline static int32_t get_offset_of_attachedCamera_2() { return static_cast<int32_t>(offsetof(UnityARCameraNearFar_t519802600, ___attachedCamera_2)); }
	inline Camera_t189460977 * get_attachedCamera_2() const { return ___attachedCamera_2; }
	inline Camera_t189460977 ** get_address_of_attachedCamera_2() { return &___attachedCamera_2; }
	inline void set_attachedCamera_2(Camera_t189460977 * value)
	{
		___attachedCamera_2 = value;
		Il2CppCodeGenWriteBarrier((&___attachedCamera_2), value);
	}

	inline static int32_t get_offset_of_currentNearZ_3() { return static_cast<int32_t>(offsetof(UnityARCameraNearFar_t519802600, ___currentNearZ_3)); }
	inline float get_currentNearZ_3() const { return ___currentNearZ_3; }
	inline float* get_address_of_currentNearZ_3() { return &___currentNearZ_3; }
	inline void set_currentNearZ_3(float value)
	{
		___currentNearZ_3 = value;
	}

	inline static int32_t get_offset_of_currentFarZ_4() { return static_cast<int32_t>(offsetof(UnityARCameraNearFar_t519802600, ___currentFarZ_4)); }
	inline float get_currentFarZ_4() const { return ___currentFarZ_4; }
	inline float* get_address_of_currentFarZ_4() { return &___currentFarZ_4; }
	inline void set_currentFarZ_4(float value)
	{
		___currentFarZ_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYARCAMERANEARFAR_T519802600_H
#ifndef UNITYARGENERATEPLANE_T3368998101_H
#define UNITYARGENERATEPLANE_T3368998101_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARGeneratePlane
struct  UnityARGeneratePlane_t3368998101  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.GameObject UnityEngine.XR.iOS.UnityARGeneratePlane::planePrefab
	GameObject_t1756533147 * ___planePrefab_2;
	// UnityEngine.XR.iOS.UnityARAnchorManager UnityEngine.XR.iOS.UnityARGeneratePlane::unityARAnchorManager
	UnityARAnchorManager_t1086564192 * ___unityARAnchorManager_3;

public:
	inline static int32_t get_offset_of_planePrefab_2() { return static_cast<int32_t>(offsetof(UnityARGeneratePlane_t3368998101, ___planePrefab_2)); }
	inline GameObject_t1756533147 * get_planePrefab_2() const { return ___planePrefab_2; }
	inline GameObject_t1756533147 ** get_address_of_planePrefab_2() { return &___planePrefab_2; }
	inline void set_planePrefab_2(GameObject_t1756533147 * value)
	{
		___planePrefab_2 = value;
		Il2CppCodeGenWriteBarrier((&___planePrefab_2), value);
	}

	inline static int32_t get_offset_of_unityARAnchorManager_3() { return static_cast<int32_t>(offsetof(UnityARGeneratePlane_t3368998101, ___unityARAnchorManager_3)); }
	inline UnityARAnchorManager_t1086564192 * get_unityARAnchorManager_3() const { return ___unityARAnchorManager_3; }
	inline UnityARAnchorManager_t1086564192 ** get_address_of_unityARAnchorManager_3() { return &___unityARAnchorManager_3; }
	inline void set_unityARAnchorManager_3(UnityARAnchorManager_t1086564192 * value)
	{
		___unityARAnchorManager_3 = value;
		Il2CppCodeGenWriteBarrier((&___unityARAnchorManager_3), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYARGENERATEPLANE_T3368998101_H
#ifndef UNITYARHITTESTEXAMPLE_T146867607_H
#define UNITYARHITTESTEXAMPLE_T146867607_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARHitTestExample
struct  UnityARHitTestExample_t146867607  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Transform UnityEngine.XR.iOS.UnityARHitTestExample::m_HitTransform
	Transform_t3275118058 * ___m_HitTransform_2;

public:
	inline static int32_t get_offset_of_m_HitTransform_2() { return static_cast<int32_t>(offsetof(UnityARHitTestExample_t146867607, ___m_HitTransform_2)); }
	inline Transform_t3275118058 * get_m_HitTransform_2() const { return ___m_HitTransform_2; }
	inline Transform_t3275118058 ** get_address_of_m_HitTransform_2() { return &___m_HitTransform_2; }
	inline void set_m_HitTransform_2(Transform_t3275118058 * value)
	{
		___m_HitTransform_2 = value;
		Il2CppCodeGenWriteBarrier((&___m_HitTransform_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYARHITTESTEXAMPLE_T146867607_H
#ifndef UNITYARKITCONTROL_T1698990409_H
#define UNITYARKITCONTROL_T1698990409_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARKitControl
struct  UnityARKitControl_t1698990409  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.XR.iOS.UnityARSessionRunOption[] UnityEngine.XR.iOS.UnityARKitControl::runOptions
	UnityARSessionRunOptionU5BU5D_t3114965901* ___runOptions_2;
	// UnityEngine.XR.iOS.UnityARAlignment[] UnityEngine.XR.iOS.UnityARKitControl::alignmentOptions
	UnityARAlignmentU5BU5D_t218994990* ___alignmentOptions_3;
	// UnityEngine.XR.iOS.UnityARPlaneDetection[] UnityEngine.XR.iOS.UnityARKitControl::planeOptions
	UnityARPlaneDetectionU5BU5D_t191549612* ___planeOptions_4;
	// System.Int32 UnityEngine.XR.iOS.UnityARKitControl::currentOptionIndex
	int32_t ___currentOptionIndex_5;
	// System.Int32 UnityEngine.XR.iOS.UnityARKitControl::currentAlignmentIndex
	int32_t ___currentAlignmentIndex_6;
	// System.Int32 UnityEngine.XR.iOS.UnityARKitControl::currentPlaneIndex
	int32_t ___currentPlaneIndex_7;

public:
	inline static int32_t get_offset_of_runOptions_2() { return static_cast<int32_t>(offsetof(UnityARKitControl_t1698990409, ___runOptions_2)); }
	inline UnityARSessionRunOptionU5BU5D_t3114965901* get_runOptions_2() const { return ___runOptions_2; }
	inline UnityARSessionRunOptionU5BU5D_t3114965901** get_address_of_runOptions_2() { return &___runOptions_2; }
	inline void set_runOptions_2(UnityARSessionRunOptionU5BU5D_t3114965901* value)
	{
		___runOptions_2 = value;
		Il2CppCodeGenWriteBarrier((&___runOptions_2), value);
	}

	inline static int32_t get_offset_of_alignmentOptions_3() { return static_cast<int32_t>(offsetof(UnityARKitControl_t1698990409, ___alignmentOptions_3)); }
	inline UnityARAlignmentU5BU5D_t218994990* get_alignmentOptions_3() const { return ___alignmentOptions_3; }
	inline UnityARAlignmentU5BU5D_t218994990** get_address_of_alignmentOptions_3() { return &___alignmentOptions_3; }
	inline void set_alignmentOptions_3(UnityARAlignmentU5BU5D_t218994990* value)
	{
		___alignmentOptions_3 = value;
		Il2CppCodeGenWriteBarrier((&___alignmentOptions_3), value);
	}

	inline static int32_t get_offset_of_planeOptions_4() { return static_cast<int32_t>(offsetof(UnityARKitControl_t1698990409, ___planeOptions_4)); }
	inline UnityARPlaneDetectionU5BU5D_t191549612* get_planeOptions_4() const { return ___planeOptions_4; }
	inline UnityARPlaneDetectionU5BU5D_t191549612** get_address_of_planeOptions_4() { return &___planeOptions_4; }
	inline void set_planeOptions_4(UnityARPlaneDetectionU5BU5D_t191549612* value)
	{
		___planeOptions_4 = value;
		Il2CppCodeGenWriteBarrier((&___planeOptions_4), value);
	}

	inline static int32_t get_offset_of_currentOptionIndex_5() { return static_cast<int32_t>(offsetof(UnityARKitControl_t1698990409, ___currentOptionIndex_5)); }
	inline int32_t get_currentOptionIndex_5() const { return ___currentOptionIndex_5; }
	inline int32_t* get_address_of_currentOptionIndex_5() { return &___currentOptionIndex_5; }
	inline void set_currentOptionIndex_5(int32_t value)
	{
		___currentOptionIndex_5 = value;
	}

	inline static int32_t get_offset_of_currentAlignmentIndex_6() { return static_cast<int32_t>(offsetof(UnityARKitControl_t1698990409, ___currentAlignmentIndex_6)); }
	inline int32_t get_currentAlignmentIndex_6() const { return ___currentAlignmentIndex_6; }
	inline int32_t* get_address_of_currentAlignmentIndex_6() { return &___currentAlignmentIndex_6; }
	inline void set_currentAlignmentIndex_6(int32_t value)
	{
		___currentAlignmentIndex_6 = value;
	}

	inline static int32_t get_offset_of_currentPlaneIndex_7() { return static_cast<int32_t>(offsetof(UnityARKitControl_t1698990409, ___currentPlaneIndex_7)); }
	inline int32_t get_currentPlaneIndex_7() const { return ___currentPlaneIndex_7; }
	inline int32_t* get_address_of_currentPlaneIndex_7() { return &___currentPlaneIndex_7; }
	inline void set_currentPlaneIndex_7(int32_t value)
	{
		___currentPlaneIndex_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYARKITCONTROL_T1698990409_H
#ifndef UNITYARUSERANCHORCOMPONENT_T3596724887_H
#define UNITYARUSERANCHORCOMPONENT_T3596724887_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARUserAnchorComponent
struct  UnityARUserAnchorComponent_t3596724887  : public MonoBehaviour_t1158329972
{
public:
	// System.String UnityEngine.XR.iOS.UnityARUserAnchorComponent::m_AnchorId
	String_t* ___m_AnchorId_2;

public:
	inline static int32_t get_offset_of_m_AnchorId_2() { return static_cast<int32_t>(offsetof(UnityARUserAnchorComponent_t3596724887, ___m_AnchorId_2)); }
	inline String_t* get_m_AnchorId_2() const { return ___m_AnchorId_2; }
	inline String_t** get_address_of_m_AnchorId_2() { return &___m_AnchorId_2; }
	inline void set_m_AnchorId_2(String_t* value)
	{
		___m_AnchorId_2 = value;
		Il2CppCodeGenWriteBarrier((&___m_AnchorId_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYARUSERANCHORCOMPONENT_T3596724887_H
#ifndef UNITYARVIDEO_T2351297253_H
#define UNITYARVIDEO_T2351297253_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARVideo
struct  UnityARVideo_t2351297253  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Material UnityEngine.XR.iOS.UnityARVideo::m_ClearMaterial
	Material_t193706927 * ___m_ClearMaterial_2;
	// UnityEngine.Rendering.CommandBuffer UnityEngine.XR.iOS.UnityARVideo::m_VideoCommandBuffer
	CommandBuffer_t1204166949 * ___m_VideoCommandBuffer_3;
	// UnityEngine.Texture2D UnityEngine.XR.iOS.UnityARVideo::_videoTextureY
	Texture2D_t3542995729 * ____videoTextureY_4;
	// UnityEngine.Texture2D UnityEngine.XR.iOS.UnityARVideo::_videoTextureCbCr
	Texture2D_t3542995729 * ____videoTextureCbCr_5;
	// UnityEngine.Matrix4x4 UnityEngine.XR.iOS.UnityARVideo::_displayTransform
	Matrix4x4_t2933234003  ____displayTransform_6;
	// System.Boolean UnityEngine.XR.iOS.UnityARVideo::bCommandBufferInitialized
	bool ___bCommandBufferInitialized_7;

public:
	inline static int32_t get_offset_of_m_ClearMaterial_2() { return static_cast<int32_t>(offsetof(UnityARVideo_t2351297253, ___m_ClearMaterial_2)); }
	inline Material_t193706927 * get_m_ClearMaterial_2() const { return ___m_ClearMaterial_2; }
	inline Material_t193706927 ** get_address_of_m_ClearMaterial_2() { return &___m_ClearMaterial_2; }
	inline void set_m_ClearMaterial_2(Material_t193706927 * value)
	{
		___m_ClearMaterial_2 = value;
		Il2CppCodeGenWriteBarrier((&___m_ClearMaterial_2), value);
	}

	inline static int32_t get_offset_of_m_VideoCommandBuffer_3() { return static_cast<int32_t>(offsetof(UnityARVideo_t2351297253, ___m_VideoCommandBuffer_3)); }
	inline CommandBuffer_t1204166949 * get_m_VideoCommandBuffer_3() const { return ___m_VideoCommandBuffer_3; }
	inline CommandBuffer_t1204166949 ** get_address_of_m_VideoCommandBuffer_3() { return &___m_VideoCommandBuffer_3; }
	inline void set_m_VideoCommandBuffer_3(CommandBuffer_t1204166949 * value)
	{
		___m_VideoCommandBuffer_3 = value;
		Il2CppCodeGenWriteBarrier((&___m_VideoCommandBuffer_3), value);
	}

	inline static int32_t get_offset_of__videoTextureY_4() { return static_cast<int32_t>(offsetof(UnityARVideo_t2351297253, ____videoTextureY_4)); }
	inline Texture2D_t3542995729 * get__videoTextureY_4() const { return ____videoTextureY_4; }
	inline Texture2D_t3542995729 ** get_address_of__videoTextureY_4() { return &____videoTextureY_4; }
	inline void set__videoTextureY_4(Texture2D_t3542995729 * value)
	{
		____videoTextureY_4 = value;
		Il2CppCodeGenWriteBarrier((&____videoTextureY_4), value);
	}

	inline static int32_t get_offset_of__videoTextureCbCr_5() { return static_cast<int32_t>(offsetof(UnityARVideo_t2351297253, ____videoTextureCbCr_5)); }
	inline Texture2D_t3542995729 * get__videoTextureCbCr_5() const { return ____videoTextureCbCr_5; }
	inline Texture2D_t3542995729 ** get_address_of__videoTextureCbCr_5() { return &____videoTextureCbCr_5; }
	inline void set__videoTextureCbCr_5(Texture2D_t3542995729 * value)
	{
		____videoTextureCbCr_5 = value;
		Il2CppCodeGenWriteBarrier((&____videoTextureCbCr_5), value);
	}

	inline static int32_t get_offset_of__displayTransform_6() { return static_cast<int32_t>(offsetof(UnityARVideo_t2351297253, ____displayTransform_6)); }
	inline Matrix4x4_t2933234003  get__displayTransform_6() const { return ____displayTransform_6; }
	inline Matrix4x4_t2933234003 * get_address_of__displayTransform_6() { return &____displayTransform_6; }
	inline void set__displayTransform_6(Matrix4x4_t2933234003  value)
	{
		____displayTransform_6 = value;
	}

	inline static int32_t get_offset_of_bCommandBufferInitialized_7() { return static_cast<int32_t>(offsetof(UnityARVideo_t2351297253, ___bCommandBufferInitialized_7)); }
	inline bool get_bCommandBufferInitialized_7() const { return ___bCommandBufferInitialized_7; }
	inline bool* get_address_of_bCommandBufferInitialized_7() { return &___bCommandBufferInitialized_7; }
	inline void set_bCommandBufferInitialized_7(bool value)
	{
		___bCommandBufferInitialized_7 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYARVIDEO_T2351297253_H
#ifndef UNITYPOINTCLOUDEXAMPLE_T3196264220_H
#define UNITYPOINTCLOUDEXAMPLE_T3196264220_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityPointCloudExample
struct  UnityPointCloudExample_t3196264220  : public MonoBehaviour_t1158329972
{
public:
	// System.UInt32 UnityPointCloudExample::numPointsToShow
	uint32_t ___numPointsToShow_2;
	// UnityEngine.GameObject UnityPointCloudExample::PointCloudPrefab
	GameObject_t1756533147 * ___PointCloudPrefab_3;
	// System.Collections.Generic.List`1<UnityEngine.GameObject> UnityPointCloudExample::pointCloudObjects
	List_1_t1125654279 * ___pointCloudObjects_4;
	// UnityEngine.Vector3[] UnityPointCloudExample::m_PointCloudData
	Vector3U5BU5D_t1172311765* ___m_PointCloudData_5;

public:
	inline static int32_t get_offset_of_numPointsToShow_2() { return static_cast<int32_t>(offsetof(UnityPointCloudExample_t3196264220, ___numPointsToShow_2)); }
	inline uint32_t get_numPointsToShow_2() const { return ___numPointsToShow_2; }
	inline uint32_t* get_address_of_numPointsToShow_2() { return &___numPointsToShow_2; }
	inline void set_numPointsToShow_2(uint32_t value)
	{
		___numPointsToShow_2 = value;
	}

	inline static int32_t get_offset_of_PointCloudPrefab_3() { return static_cast<int32_t>(offsetof(UnityPointCloudExample_t3196264220, ___PointCloudPrefab_3)); }
	inline GameObject_t1756533147 * get_PointCloudPrefab_3() const { return ___PointCloudPrefab_3; }
	inline GameObject_t1756533147 ** get_address_of_PointCloudPrefab_3() { return &___PointCloudPrefab_3; }
	inline void set_PointCloudPrefab_3(GameObject_t1756533147 * value)
	{
		___PointCloudPrefab_3 = value;
		Il2CppCodeGenWriteBarrier((&___PointCloudPrefab_3), value);
	}

	inline static int32_t get_offset_of_pointCloudObjects_4() { return static_cast<int32_t>(offsetof(UnityPointCloudExample_t3196264220, ___pointCloudObjects_4)); }
	inline List_1_t1125654279 * get_pointCloudObjects_4() const { return ___pointCloudObjects_4; }
	inline List_1_t1125654279 ** get_address_of_pointCloudObjects_4() { return &___pointCloudObjects_4; }
	inline void set_pointCloudObjects_4(List_1_t1125654279 * value)
	{
		___pointCloudObjects_4 = value;
		Il2CppCodeGenWriteBarrier((&___pointCloudObjects_4), value);
	}

	inline static int32_t get_offset_of_m_PointCloudData_5() { return static_cast<int32_t>(offsetof(UnityPointCloudExample_t3196264220, ___m_PointCloudData_5)); }
	inline Vector3U5BU5D_t1172311765* get_m_PointCloudData_5() const { return ___m_PointCloudData_5; }
	inline Vector3U5BU5D_t1172311765** get_address_of_m_PointCloudData_5() { return &___m_PointCloudData_5; }
	inline void set_m_PointCloudData_5(Vector3U5BU5D_t1172311765* value)
	{
		___m_PointCloudData_5 = value;
		Il2CppCodeGenWriteBarrier((&___m_PointCloudData_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYPOINTCLOUDEXAMPLE_T3196264220_H
#ifndef UNITYARAMBIENT_T680084560_H
#define UNITYARAMBIENT_T680084560_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.XR.iOS.UnityARAmbient
struct  UnityARAmbient_t680084560  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Light UnityEngine.XR.iOS.UnityARAmbient::l
	Light_t494725636 * ___l_2;

public:
	inline static int32_t get_offset_of_l_2() { return static_cast<int32_t>(offsetof(UnityARAmbient_t680084560, ___l_2)); }
	inline Light_t494725636 * get_l_2() const { return ___l_2; }
	inline Light_t494725636 ** get_address_of_l_2() { return &___l_2; }
	inline void set_l_2(Light_t494725636 * value)
	{
		___l_2 = value;
		Il2CppCodeGenWriteBarrier((&___l_2), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // UNITYARAMBIENT_T680084560_H





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1900 = { sizeof (UnityARAmbient_t680084560), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable1900[1] = 
{
	UnityARAmbient_t680084560::get_offset_of_l_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1901 = { sizeof (UnityARAnchorManager_t1086564192), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable1901[1] = 
{
	UnityARAnchorManager_t1086564192::get_offset_of_planeAnchorMap_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1902 = { sizeof (UnityARCameraManager_t2138856896), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable1902[15] = 
{
	UnityARCameraManager_t2138856896::get_offset_of_m_camera_2(),
	UnityARCameraManager_t2138856896::get_offset_of_m_session_3(),
	UnityARCameraManager_t2138856896::get_offset_of_savedClearMaterial_4(),
	UnityARCameraManager_t2138856896::get_offset_of_startAlignment_5(),
	UnityARCameraManager_t2138856896::get_offset_of_planeDetection_6(),
	UnityARCameraManager_t2138856896::get_offset_of_htcTrackerRelayEnabled_7(),
	UnityARCameraManager_t2138856896::get_offset_of_htcTrackerOffsetEnabled_8(),
	UnityARCameraManager_t2138856896::get_offset_of_getPointCloud_9(),
	UnityARCameraManager_t2138856896::get_offset_of_enableLightEstimation_10(),
	UnityARCameraManager_t2138856896::get_offset_of_tracker_position_11(),
	UnityARCameraManager_t2138856896::get_offset_of_tracker_rotation_12(),
	UnityARCameraManager_t2138856896::get_offset_of_arkit_position_13(),
	UnityARCameraManager_t2138856896::get_offset_of_arkit_rotation_14(),
	UnityARCameraManager_t2138856896::get_offset_of_offset_position_15(),
	UnityARCameraManager_t2138856896::get_offset_of_offset_rotation_16(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1903 = { sizeof (UnityARCameraNearFar_t519802600), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable1903[3] = 
{
	UnityARCameraNearFar_t519802600::get_offset_of_attachedCamera_2(),
	UnityARCameraNearFar_t519802600::get_offset_of_currentNearZ_3(),
	UnityARCameraNearFar_t519802600::get_offset_of_currentFarZ_4(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1904 = { sizeof (UnityARGeneratePlane_t3368998101), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable1904[2] = 
{
	UnityARGeneratePlane_t3368998101::get_offset_of_planePrefab_2(),
	UnityARGeneratePlane_t3368998101::get_offset_of_unityARAnchorManager_3(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1905 = { sizeof (UnityARHitTestExample_t146867607), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable1905[1] = 
{
	UnityARHitTestExample_t146867607::get_offset_of_m_HitTransform_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1906 = { sizeof (UnityARKitControl_t1698990409), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable1906[6] = 
{
	UnityARKitControl_t1698990409::get_offset_of_runOptions_2(),
	UnityARKitControl_t1698990409::get_offset_of_alignmentOptions_3(),
	UnityARKitControl_t1698990409::get_offset_of_planeOptions_4(),
	UnityARKitControl_t1698990409::get_offset_of_currentOptionIndex_5(),
	UnityARKitControl_t1698990409::get_offset_of_currentAlignmentIndex_6(),
	UnityARKitControl_t1698990409::get_offset_of_currentPlaneIndex_7(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1907 = { sizeof (UnityARMatrixOps_t4039665643), -1, 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1908 = { sizeof (UnityARUserAnchorComponent_t3596724887), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable1908[1] = 
{
	UnityARUserAnchorComponent_t3596724887::get_offset_of_m_AnchorId_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1909 = { sizeof (UnityARUtility_t3608388148), -1, sizeof(UnityARUtility_t3608388148_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable1909[3] = 
{
	UnityARUtility_t3608388148::get_offset_of_meshCollider_0(),
	UnityARUtility_t3608388148::get_offset_of_meshFilter_1(),
	UnityARUtility_t3608388148_StaticFields::get_offset_of_planePrefab_2(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1910 = { sizeof (UnityARVideo_t2351297253), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable1910[6] = 
{
	UnityARVideo_t2351297253::get_offset_of_m_ClearMaterial_2(),
	UnityARVideo_t2351297253::get_offset_of_m_VideoCommandBuffer_3(),
	UnityARVideo_t2351297253::get_offset_of__videoTextureY_4(),
	UnityARVideo_t2351297253::get_offset_of__videoTextureCbCr_5(),
	UnityARVideo_t2351297253::get_offset_of__displayTransform_6(),
	UnityARVideo_t2351297253::get_offset_of_bCommandBufferInitialized_7(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1911 = { sizeof (UnityPointCloudExample_t3196264220), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable1911[4] = 
{
	UnityPointCloudExample_t3196264220::get_offset_of_numPointsToShow_2(),
	UnityPointCloudExample_t3196264220::get_offset_of_PointCloudPrefab_3(),
	UnityPointCloudExample_t3196264220::get_offset_of_pointCloudObjects_4(),
	UnityPointCloudExample_t3196264220::get_offset_of_m_PointCloudData_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1912 = { sizeof (ARAnchor_t1161832412)+ sizeof (RuntimeObject), sizeof(ARAnchor_t1161832412_marshaled_pinvoke), 0, 0 };
extern const int32_t g_FieldOffsetTable1912[2] = 
{
	ARAnchor_t1161832412::get_offset_of_identifier_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARAnchor_t1161832412::get_offset_of_transform_1() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1913 = { sizeof (ARCamera_t4158705974)+ sizeof (RuntimeObject), sizeof(ARCamera_t4158705974 ), 0, 0 };
extern const int32_t g_FieldOffsetTable1913[7] = 
{
	ARCamera_t4158705974::get_offset_of_worldTransform_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARCamera_t4158705974::get_offset_of_eulerAngles_1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARCamera_t4158705974::get_offset_of_trackingQuality_2() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARCamera_t4158705974::get_offset_of_intrinsics_row1_3() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARCamera_t4158705974::get_offset_of_intrinsics_row2_4() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARCamera_t4158705974::get_offset_of_intrinsics_row3_5() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARCamera_t4158705974::get_offset_of_imageResolution_6() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1914 = { sizeof (ARErrorCode_t2887756272)+ sizeof (RuntimeObject), sizeof(int64_t), 0, 0 };
extern const int32_t g_FieldOffsetTable1914[5] = 
{
	ARErrorCode_t2887756272::get_offset_of_value___1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1915 = { sizeof (ARFrame_t1001293426)+ sizeof (RuntimeObject), sizeof(ARFrame_t1001293426 ), 0, 0 };
extern const int32_t g_FieldOffsetTable1915[4] = 
{
	ARFrame_t1001293426::get_offset_of_timestamp_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARFrame_t1001293426::get_offset_of_capturedImage_1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARFrame_t1001293426::get_offset_of_camera_2() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARFrame_t1001293426::get_offset_of_lightEstimate_3() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1916 = { sizeof (ARHitTestResult_t3275513025)+ sizeof (RuntimeObject), sizeof(ARHitTestResult_t3275513025_marshaled_pinvoke), 0, 0 };
extern const int32_t g_FieldOffsetTable1916[6] = 
{
	ARHitTestResult_t3275513025::get_offset_of_type_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARHitTestResult_t3275513025::get_offset_of_distance_1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARHitTestResult_t3275513025::get_offset_of_localTransform_2() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARHitTestResult_t3275513025::get_offset_of_worldTransform_3() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARHitTestResult_t3275513025::get_offset_of_anchorIdentifier_4() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARHitTestResult_t3275513025::get_offset_of_isValid_5() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1917 = { sizeof (ARHitTestResultType_t3616749745)+ sizeof (RuntimeObject), sizeof(int64_t), 0, 0 };
extern const int32_t g_FieldOffsetTable1917[6] = 
{
	ARHitTestResultType_t3616749745::get_offset_of_value___1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1918 = { sizeof (ARLightEstimate_t3477821059)+ sizeof (RuntimeObject), sizeof(ARLightEstimate_t3477821059 ), 0, 0 };
extern const int32_t g_FieldOffsetTable1918[1] = 
{
	ARLightEstimate_t3477821059::get_offset_of_ambientIntensity_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1919 = { sizeof (ARPlaneAnchor_t1439520888)+ sizeof (RuntimeObject), sizeof(ARPlaneAnchor_t1439520888_marshaled_pinvoke), 0, 0 };
extern const int32_t g_FieldOffsetTable1919[5] = 
{
	ARPlaneAnchor_t1439520888::get_offset_of_identifier_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARPlaneAnchor_t1439520888::get_offset_of_transform_1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARPlaneAnchor_t1439520888::get_offset_of_alignment_2() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARPlaneAnchor_t1439520888::get_offset_of_center_3() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARPlaneAnchor_t1439520888::get_offset_of_extent_4() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1920 = { sizeof (ARPlaneAnchorAlignment_t2379298071)+ sizeof (RuntimeObject), sizeof(int64_t), 0, 0 };
extern const int32_t g_FieldOffsetTable1920[2] = 
{
	ARPlaneAnchorAlignment_t2379298071::get_offset_of_value___1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1921 = { sizeof (ARPoint_t3436811567)+ sizeof (RuntimeObject), sizeof(ARPoint_t3436811567 ), 0, 0 };
extern const int32_t g_FieldOffsetTable1921[2] = 
{
	ARPoint_t3436811567::get_offset_of_x_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARPoint_t3436811567::get_offset_of_y_1() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1922 = { sizeof (ARRect_t3555590363)+ sizeof (RuntimeObject), sizeof(ARRect_t3555590363 ), 0, 0 };
extern const int32_t g_FieldOffsetTable1922[2] = 
{
	ARRect_t3555590363::get_offset_of_origin_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARRect_t3555590363::get_offset_of_size_1() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1923 = { sizeof (ARSize_t3911821096)+ sizeof (RuntimeObject), sizeof(ARSize_t3911821096 ), 0, 0 };
extern const int32_t g_FieldOffsetTable1923[2] = 
{
	ARSize_t3911821096::get_offset_of_width_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARSize_t3911821096::get_offset_of_height_1() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1924 = { sizeof (ARTextureHandles_t3764914833)+ sizeof (RuntimeObject), sizeof(ARTextureHandles_t3764914833 ), 0, 0 };
extern const int32_t g_FieldOffsetTable1924[2] = 
{
	ARTextureHandles_t3764914833::get_offset_of_textureY_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARTextureHandles_t3764914833::get_offset_of_textureCbCr_1() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1925 = { sizeof (ARTrackingQuality_t55960597)+ sizeof (RuntimeObject), sizeof(int64_t), 0, 0 };
extern const int32_t g_FieldOffsetTable1925[5] = 
{
	ARTrackingQuality_t55960597::get_offset_of_value___1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1926 = { sizeof (ARTrackingState_t2048880995)+ sizeof (RuntimeObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable1926[4] = 
{
	ARTrackingState_t2048880995::get_offset_of_value___1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1927 = { sizeof (ARTrackingStateReason_t4227173799)+ sizeof (RuntimeObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable1927[5] = 
{
	ARTrackingStateReason_t4227173799::get_offset_of_value___1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1928 = { sizeof (ARUserAnchor_t4064312267)+ sizeof (RuntimeObject), sizeof(ARUserAnchor_t4064312267_marshaled_pinvoke), 0, 0 };
extern const int32_t g_FieldOffsetTable1928[2] = 
{
	ARUserAnchor_t4064312267::get_offset_of_identifier_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARUserAnchor_t4064312267::get_offset_of_transform_1() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1929 = { sizeof (UnityARMatrix4x4_t100931615)+ sizeof (RuntimeObject), sizeof(UnityARMatrix4x4_t100931615 ), 0, 0 };
extern const int32_t g_FieldOffsetTable1929[4] = 
{
	UnityARMatrix4x4_t100931615::get_offset_of_column0_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityARMatrix4x4_t100931615::get_offset_of_column1_1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityARMatrix4x4_t100931615::get_offset_of_column2_2() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityARMatrix4x4_t100931615::get_offset_of_column3_3() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1930 = { sizeof (UnityVideoParams_t2644681676)+ sizeof (RuntimeObject), sizeof(UnityVideoParams_t2644681676 ), 0, 0 };
extern const int32_t g_FieldOffsetTable1930[5] = 
{
	UnityVideoParams_t2644681676::get_offset_of_yWidth_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityVideoParams_t2644681676::get_offset_of_yHeight_1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityVideoParams_t2644681676::get_offset_of_screenOrientation_2() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityVideoParams_t2644681676::get_offset_of_texCoordScale_3() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityVideoParams_t2644681676::get_offset_of_cvPixelBufferPtr_4() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1931 = { sizeof (UnityARLightEstimate_t311267890)+ sizeof (RuntimeObject), sizeof(UnityARLightEstimate_t311267890 ), 0, 0 };
extern const int32_t g_FieldOffsetTable1931[2] = 
{
	UnityARLightEstimate_t311267890::get_offset_of_ambientIntensity_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityARLightEstimate_t311267890::get_offset_of_ambientColorTemperature_1() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1932 = { sizeof (internal_UnityARCamera_t2580192745)+ sizeof (RuntimeObject), sizeof(internal_UnityARCamera_t2580192745 ), 0, 0 };
extern const int32_t g_FieldOffsetTable1932[8] = 
{
	internal_UnityARCamera_t2580192745::get_offset_of_worldTransform_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
	internal_UnityARCamera_t2580192745::get_offset_of_projectionMatrix_1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	internal_UnityARCamera_t2580192745::get_offset_of_trackingState_2() + static_cast<int32_t>(sizeof(RuntimeObject)),
	internal_UnityARCamera_t2580192745::get_offset_of_trackingReason_3() + static_cast<int32_t>(sizeof(RuntimeObject)),
	internal_UnityARCamera_t2580192745::get_offset_of_videoParams_4() + static_cast<int32_t>(sizeof(RuntimeObject)),
	internal_UnityARCamera_t2580192745::get_offset_of_lightEstimation_5() + static_cast<int32_t>(sizeof(RuntimeObject)),
	internal_UnityARCamera_t2580192745::get_offset_of_displayTransform_6() + static_cast<int32_t>(sizeof(RuntimeObject)),
	internal_UnityARCamera_t2580192745::get_offset_of_getPointCloudData_7() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1933 = { sizeof (UnityARCamera_t4198559457)+ sizeof (RuntimeObject), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable1933[8] = 
{
	UnityARCamera_t4198559457::get_offset_of_worldTransform_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityARCamera_t4198559457::get_offset_of_projectionMatrix_1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityARCamera_t4198559457::get_offset_of_trackingState_2() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityARCamera_t4198559457::get_offset_of_trackingReason_3() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityARCamera_t4198559457::get_offset_of_videoParams_4() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityARCamera_t4198559457::get_offset_of_lightEstimation_5() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityARCamera_t4198559457::get_offset_of_displayTransform_6() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityARCamera_t4198559457::get_offset_of_pointCloudData_7() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1934 = { sizeof (UnityARAnchorData_t2901866349)+ sizeof (RuntimeObject), sizeof(UnityARAnchorData_t2901866349 ), 0, 0 };
extern const int32_t g_FieldOffsetTable1934[5] = 
{
	UnityARAnchorData_t2901866349::get_offset_of_ptrIdentifier_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityARAnchorData_t2901866349::get_offset_of_transform_1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityARAnchorData_t2901866349::get_offset_of_alignment_2() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityARAnchorData_t2901866349::get_offset_of_center_3() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityARAnchorData_t2901866349::get_offset_of_extent_4() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1935 = { sizeof (UnityARUserAnchorData_t2645079618)+ sizeof (RuntimeObject), sizeof(UnityARUserAnchorData_t2645079618 ), 0, 0 };
extern const int32_t g_FieldOffsetTable1935[2] = 
{
	UnityARUserAnchorData_t2645079618::get_offset_of_ptrIdentifier_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityARUserAnchorData_t2645079618::get_offset_of_transform_1() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1936 = { sizeof (UnityARHitTestResult_t4129824344)+ sizeof (RuntimeObject), sizeof(UnityARHitTestResult_t4129824344_marshaled_pinvoke), 0, 0 };
extern const int32_t g_FieldOffsetTable1936[6] = 
{
	UnityARHitTestResult_t4129824344::get_offset_of_type_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityARHitTestResult_t4129824344::get_offset_of_distance_1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityARHitTestResult_t4129824344::get_offset_of_localTransform_2() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityARHitTestResult_t4129824344::get_offset_of_worldTransform_3() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityARHitTestResult_t4129824344::get_offset_of_anchor_4() + static_cast<int32_t>(sizeof(RuntimeObject)),
	UnityARHitTestResult_t4129824344::get_offset_of_isValid_5() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1937 = { sizeof (UnityARAlignment_t2379988631)+ sizeof (RuntimeObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable1937[4] = 
{
	UnityARAlignment_t2379988631::get_offset_of_value___1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1938 = { sizeof (UnityARPlaneDetection_t612575857)+ sizeof (RuntimeObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable1938[3] = 
{
	UnityARPlaneDetection_t612575857::get_offset_of_value___1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1939 = { sizeof (ARKitSessionConfiguration_t318899795)+ sizeof (RuntimeObject), sizeof(ARKitSessionConfiguration_t318899795_marshaled_pinvoke), 0, 0 };
extern const int32_t g_FieldOffsetTable1939[3] = 
{
	ARKitSessionConfiguration_t318899795::get_offset_of_alignment_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARKitSessionConfiguration_t318899795::get_offset_of_getPointCloudData_1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARKitSessionConfiguration_t318899795::get_offset_of_enableLightEstimation_2() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1940 = { sizeof (ARKitWorldTrackingSessionConfiguration_t1371796706)+ sizeof (RuntimeObject), sizeof(ARKitWorldTrackingSessionConfiguration_t1371796706_marshaled_pinvoke), 0, 0 };
extern const int32_t g_FieldOffsetTable1940[4] = 
{
	ARKitWorldTrackingSessionConfiguration_t1371796706::get_offset_of_alignment_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARKitWorldTrackingSessionConfiguration_t1371796706::get_offset_of_planeDetection_1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARKitWorldTrackingSessionConfiguration_t1371796706::get_offset_of_getPointCloudData_2() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ARKitWorldTrackingSessionConfiguration_t1371796706::get_offset_of_enableLightEstimation_3() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1941 = { sizeof (UnityARSessionRunOption_t3123075684)+ sizeof (RuntimeObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable1941[3] = 
{
	UnityARSessionRunOption_t3123075684::get_offset_of_value___1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1942 = { sizeof (UnityARSessionNativeInterface_t1130867170), -1, sizeof(UnityARSessionNativeInterface_t1130867170_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable1942[32] = 
{
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_ARFrameUpdatedEvent_0(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_ARAnchorAddedEvent_1(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_ARAnchorUpdatedEvent_2(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_ARAnchorRemovedEvent_3(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_ARUserAnchorAddedEvent_4(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_ARUserAnchorUpdatedEvent_5(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_ARUserAnchorRemovedEvent_6(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_ARSessionFailedEvent_7(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_ARSessionInterruptedEvent_8(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_ARSessioninterruptionEndedEvent_9(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_ARSessionTrackingChangedEvent_10(),
	UnityARSessionNativeInterface_t1130867170::get_offset_of_m_NativeARSession_11(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_tracker_enabled_12(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_tracker_position_13(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_tracker_rotation_14(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_offset_position_15(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_offset_rotation_16(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_lastARKitWorldTransform_17(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_customWorldTransform_18(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_s_Camera_19(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_s_UnityARSessionNativeInterface_20(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_U3CU3Ef__mgU24cache0_21(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_U3CU3Ef__mgU24cache1_22(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_U3CU3Ef__mgU24cache2_23(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_U3CU3Ef__mgU24cache3_24(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_U3CU3Ef__mgU24cache4_25(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_U3CU3Ef__mgU24cache5_26(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_U3CU3Ef__mgU24cache6_27(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_U3CU3Ef__mgU24cache7_28(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_U3CU3Ef__mgU24cache8_29(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_U3CU3Ef__mgU24cache9_30(),
	UnityARSessionNativeInterface_t1130867170_StaticFields::get_offset_of_U3CU3Ef__mgU24cacheA_31(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1943 = { sizeof (ARFrameUpdate_t496507918), sizeof(Il2CppMethodPointer), 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1944 = { sizeof (ARAnchorAdded_t2646854145), sizeof(Il2CppMethodPointer), 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1945 = { sizeof (ARAnchorUpdated_t3886071158), sizeof(Il2CppMethodPointer), 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1946 = { sizeof (ARAnchorRemoved_t142665927), sizeof(Il2CppMethodPointer), 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1947 = { sizeof (ARUserAnchorAdded_t4216008690), sizeof(Il2CppMethodPointer), 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1948 = { sizeof (ARUserAnchorUpdated_t1104644293), sizeof(Il2CppMethodPointer), 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1949 = { sizeof (ARUserAnchorRemoved_t1656212632), sizeof(Il2CppMethodPointer), 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1950 = { sizeof (ARSessionFailed_t872580813), sizeof(Il2CppMethodPointer), 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1951 = { sizeof (ARSessionCallback_t3370800699), sizeof(Il2CppMethodPointer), 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1952 = { sizeof (ARSessionTrackingChanged_t1333006279), sizeof(Il2CppMethodPointer), 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1953 = { sizeof (internal_ARFrameUpdate_t3296518558), sizeof(Il2CppMethodPointer), 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1954 = { sizeof (internal_ARAnchorAdded_t1622117597), sizeof(Il2CppMethodPointer), 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1955 = { sizeof (internal_ARAnchorUpdated_t3705772742), sizeof(Il2CppMethodPointer), 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1956 = { sizeof (internal_ARAnchorRemoved_t3189755211), sizeof(Il2CppMethodPointer), 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1957 = { sizeof (internal_ARUserAnchorAdded_t3999066834), sizeof(Il2CppMethodPointer), 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1958 = { sizeof (internal_ARUserAnchorUpdated_t1661963345), sizeof(Il2CppMethodPointer), 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1959 = { sizeof (internal_ARUserAnchorRemoved_t4166385952), sizeof(Il2CppMethodPointer), 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1960 = { sizeof (internal_ARSessionTrackingChanged_t1558153491), sizeof(Il2CppMethodPointer), 0, 0 };
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1961 = { sizeof (U3CPrivateImplementationDetailsU3E_t1486305142), -1, sizeof(U3CPrivateImplementationDetailsU3E_t1486305142_StaticFields), 0 };
extern const int32_t g_FieldOffsetTable1961[1] = 
{
	U3CPrivateImplementationDetailsU3E_t1486305142_StaticFields::get_offset_of_U24fieldU2D8E7629AD5AF686202B8CB7C014505C432FFE31E6_0(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1962 = { sizeof (U24ArrayTypeU3D24_t762068664)+ sizeof (RuntimeObject), sizeof(U24ArrayTypeU3D24_t762068664 ), 0, 0 };
#ifdef __clang__
#pragma clang diagnostic pop
#endif
