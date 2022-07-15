// Functional in either UnityEngine or native .NET projects.
#if UNITY_5_3_OR_NEWER
using UnityEngine;
#else
using Vector3 = System.Numerics.Vector3;
using Vector2 = System.Numerics.Vector2;
#endif

namespace Extevious.Curves {
	public static class CurveFunctions {
		#region Vector3
		/// <summary>
		/// A 3-point parametric interpolation curve.
		/// </summary>
		public static Vector3 ParametricCurve (Vector3 p0, Vector3 p1, Vector3 p2, float s, float t) {
			float x = 1f - s;

			Vector3 A = p0;
			Vector3 B = (p1 - p0) * (1f / (x * s));
			Vector3 C = (p2 - p0) * (1f / x);

			Vector3 a0 = A;
			Vector3 a1 = B - C * s;
			Vector3 a2 = C - B;

			return ((a2 * t) + a1) * t + a0;
		}

		/// <summary>
		/// Returns a position between 4 Vector3 with Catmull-Rom spline algorithm
		/// </summary>
		public static Vector3 CatmullRomCurve (Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) {
			Vector3 a = 2f * p1;
			Vector3 b = p2 - p0;
			Vector3 c = 2f * p0 - 5f * p1 + 4f * p2 - p3;
			Vector3 d = -p0 + 3f * p1 - 3f * p2 + p3;

			return 0.5f * (a + (b * t) + (c * t * t) + (d * t * t * t));
		}

		/// <summary>
		/// A Bezier Curve between 2 points and a single control handle.
		/// </summary>
		public static Vector3 BezierCurve2p1c (Vector3 p0, Vector3 p1, Vector3 s, float t) {
			float omt = 1f - t;

			return omt * omt * p0 +
				   2f * t * omt * s +
				   t * t * p1;
		}
		#endregion

		#region Vector2
		/// <summary>
		/// A 3-point parametric interpolation curve.
		/// </summary>
		public static Vector2 ParametricCurve (Vector2 p0, Vector2 p1, Vector2 p2, float s, float t) {
			float x = 1f - s;

			Vector2 A = p0;
			Vector2 B = (p1 - p0) * (1f / (x * s));
			Vector2 C = (p2 - p0) * (1f / x);

			Vector2 a0 = A;
			Vector2 a1 = B - C * s;
			Vector2 a2 = C - B;

			return ((a2 * t) + a1) * t + a0;
		}

		/// <summary>
		/// Returns a position between 4 Vector3 with Catmull-Rom spline algorithm
		/// </summary>
		public static Vector2 CatmullRomCurve (Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t) {
			Vector2 a = 2f * p1;
			Vector2 b = p2 - p0;
			Vector2 c = 2f * p0 - 5f * p1 + 4f * p2 - p3;
			Vector2 d = -p0 + 3f * p1 - 3f * p2 + p3;

			return 0.5f * (a + (b * t) + (c * t * t) + (d * t * t * t));
		}

		/// <summary>
		/// A Bezier Curve between 2 points and a single control handle.
		/// </summary>
		public static Vector2 BezierCurve2p1c (Vector2 p0, Vector2 p1, Vector2 s, float t) {
			float omt = 1f - t;

			return omt * omt * p0 +
				   2f * t * omt * s +
				   t * t * p1;
		}
		#endregion
	}
}