using System;

namespace UnityEngine.XR.iOS
{
	public class UnityARMatrixOps
	{

		public static Vector3 GetPosition(Matrix4x4 matrix)
		{
			// Convert from ARKit's right-handed coordinate
			// system to Unity's left-handed
			Vector3 position = matrix.GetColumn(3);
			position.z = -position.z;

			return position;
		}

		public static Quaternion GetRotation(UnityARMatrix4x4 m)
		{
			return GetRotation (new Matrix4x4 (m.column0, m.column1, m.column2, m.column3));
		}

		public static Quaternion GetRotation(Matrix4x4 matrix)
		{
			// Convert from ARKit's right-handed coordinate
			// system to Unity's left-handed
			Quaternion rotation = QuaternionFromMatrix(matrix);
			rotation.z = -rotation.z;
			rotation.w = -rotation.w;

			return rotation;
		}

		static Quaternion QuaternionFromMatrix(Matrix4x4 m) {
			// Adapted from: http://www.euclideanspace.com/maths/geometry/rotations/conversions/matrixToQuaternion/index.htm
			Quaternion q = new Quaternion();
			q.w = Mathf.Sqrt( Mathf.Max( 0, 1 + m[0,0] + m[1,1] + m[2,2] ) ) / 2; 
			q.x = Mathf.Sqrt( Mathf.Max( 0, 1 + m[0,0] - m[1,1] - m[2,2] ) ) / 2; 
			q.y = Mathf.Sqrt( Mathf.Max( 0, 1 - m[0,0] + m[1,1] - m[2,2] ) ) / 2; 
			q.z = Mathf.Sqrt( Mathf.Max( 0, 1 - m[0,0] - m[1,1] + m[2,2] ) ) / 2; 
			q.x *= Mathf.Sign( q.x * ( m[2,1] - m[1,2] ) );
			q.y *= Mathf.Sign( q.y * ( m[0,2] - m[2,0] ) );
			q.z *= Mathf.Sign( q.z * ( m[1,0] - m[0,1] ) );
			return q;
		}

		//Written by Chris 13/12/2017
		public static UnityARMatrix4x4 InsertRotation(UnityARMatrix4x4 result, Quaternion q) {
			//Adapted from: http://www.euclideanspace.com/maths/geometry/rotations/conversions/quaternionToMatrix/index.htm

			double sqw = q.w*q.w;
			double sqx = q.x*q.x;
			double sqy = q.y*q.y;
			double sqz = q.z*q.z;

			// invs (inverse square length) is only required if quaternion is not already normalised
			double invs = 1 / (sqx + sqy + sqz + sqw);

			float m00 = (float)(( sqx - sqy - sqz + sqw)*invs); // since sqw + sqx + sqy + sqz =1/invs*invs
			float m11 = (float)((-sqx + sqy - sqz + sqw)*invs);
			float m22 = (float)((-sqx - sqy + sqz + sqw)*invs);

			double tmp1 = q.x*q.y;
			double tmp2 = q.z*q.w;
			float m10 = (float)(2.0 * (tmp1 + tmp2)*invs);
			float m01 = (float)(2.0 * (tmp1 - tmp2)*invs);

			tmp1 = q.x*q.z;
			tmp2 = q.y*q.w;
			float m20 = (float)(2.0 * (tmp1 - tmp2)*invs);
			float m02 = (float)(2.0 * (tmp1 + tmp2)*invs);
			tmp1 = q.y*q.z;
			tmp2 = q.x*q.w;
			float m21 = (float)(2.0 * (tmp1 + tmp2)*invs);
			float m12 = (float)(2.0 * (tmp1 - tmp2)*invs);      

			result.column0 = new Vector4(m00, m10, m20, 0);
			result.column1 = new Vector4(m01, m11, m21, 0);
			result.column2 = new Vector4(m02, m12, m22, 0);


			return result;
		}

		//Written by Chris
		static Quaternion QuaternionFromMatrix(UnityARMatrix4x4 m) {
			Matrix4x4 um = new Matrix4x4(m.column0, m.column1, m.column2, m.column3);
			return QuaternionFromMatrix (um);
		}
	}
}

