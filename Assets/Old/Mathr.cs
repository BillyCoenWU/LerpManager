using System;
using UnityEngine;
using System.Collections;

namespace RGSMS
{
	public enum EASE
	{
		Linear,

		QuadraticEaseIn,
		QuadraticEaseOut,
		QuadraticEaseInOut,

		CubicEaseIn,
		CubicEaseOut,
		CubicEaseInOut,

		QuarticEaseIn,
		QuarticEaseOut,
		QuarticEaseInOut,

		QuinticEaseIn,
		QuinticEaseOut,
		QuinticEaseInOut,

		SineEaseIn,
		SineEaseOut,
		SineEaseInOut,

		CircularEaseIn,
		CircularEaseOut,
		CircularEaseInOut,

		ExponentialEaseIn,
		ExponentialEaseOut,
		ExponentialEaseInOut,

		ElasticEaseIn,
		ElasticEaseOut,
		ElasticEaseInOut,

		BackEaseIn,
		BackEaseOut,
		BackEaseInOut,

		BounceEaseIn,
		BounceEaseOut,
		BounceEaseInOut
	}

	public class Mathr
	{
		private const float PI = Mathf.PI;
		private const float HALFPI = PI / 2.0f;

        #region Coroutines

        public static void Lerp (Transform target, Vector3 a, Vector3 b, float speed, EASE e, Action startCall, Action endCall, MonoBehaviour m)
        {
            m.StartCoroutine(LerpCoroutine(target, a, b, speed, e, startCall, endCall));
        }
        
        private static IEnumerator LerpCoroutine (Transform target, Vector3 a, Vector3 b, float speed, EASE e, Action startCall, Action EndCall)
        {
            float t = 0.0f;

            startCall();

            while(t < 1.0f)
            {
                t += Time.deltaTime * speed;

                target.position = Lerp(a, b, t, e);

                yield return null;
            }

            EndCall();
        }

        #endregion

		#region Int Lerps

		public static int Lerp (int a, int b, float t, EASE i)
		{
			if(i == EASE.ElasticEaseIn || i == EASE.ElasticEaseInOut || i == EASE.ElasticEaseOut ||
			   i == EASE.BackEaseIn || i == EASE.BackEaseInOut || i == EASE.BackEaseOut)
			{
				return LerpUnclamped (a, b, t, i);
			}

			return Mathf.FloorToInt(Mathf.Lerp(a, b, Interpolate(t, i)));
		}

		public static int LerpUnclamped (int a, int b, float t, EASE i)
		{
			return Mathf.FloorToInt(Mathf.LerpUnclamped(a, b, Interpolate(t, i)));
		}

		public static int InverseLerp (int a, int b, float value, EASE i)
		{
			return Mathf.FloorToInt(Interpolate(Mathf.InverseLerp(a, b, value), i));
		}

		#endregion

		#region Double Lerps

		public static double Lerp (double a, double b, float t, EASE i)
		{
			if(i == EASE.ElasticEaseIn || i == EASE.ElasticEaseInOut || i == EASE.ElasticEaseOut ||
			   i == EASE.BackEaseIn || i == EASE.BackEaseInOut || i == EASE.BackEaseOut)
			{
				return LerpUnclamped (a, b, t, i);
			}

			return DoubleLerp(a, b, Mathf.Clamp01(Interpolate(t, i)));
		}

		public static double LerpUnclamped (double a, double b, float t, EASE i)
		{
			return DoubleLerp(a, b, Interpolate(t, i));
		}

		public static double InverseLerp (double a, double b, float value, EASE i)
		{
			return InverseDoubleLerp (a, b, Interpolate(value, i));
		}

		#endregion

        #region Float Lerps

        public static float Lerp (float a, float b, float t, EASE i)
		{
			if(i == EASE.ElasticEaseIn || i == EASE.ElasticEaseInOut || i == EASE.ElasticEaseOut ||
			   i == EASE.BackEaseIn || i == EASE.BackEaseInOut || i == EASE.BackEaseOut)
			{
				return LerpUnclamped (a, b, t, i);
			}

			return Mathf.Lerp(a, b, Interpolate(t, i));
		}

		public static float LerpUnclamped (float a, float b, float t, EASE i)
		{
			return Mathf.LerpUnclamped(a, b, Interpolate(t, i));
		}

		public static float LerpAngle (float a, float b, float t, EASE i)
		{
			return Mathf.LerpAngle(a, b, Interpolate(t, i));
		}

		public static float InverseLerp (float a, float b, float value, EASE i)
		{
			return Interpolate(Mathf.InverseLerp(a, b, value), i);
		}

		#endregion

		#region Color Lerps

		public static Color Lerp (Color a, Color b, float t, EASE i)
		{
			if(i == EASE.ElasticEaseIn || i == EASE.ElasticEaseInOut || i == EASE.ElasticEaseOut ||
			   i == EASE.BackEaseIn || i == EASE.BackEaseInOut || i == EASE.BackEaseOut)
			{
				return LerpUnclamped (a, b, t, i);
			}

			return Color.Lerp(a, b, Interpolate(t, i));
		}

		public static Color LerpUnclamped (Color a, Color b, float t, EASE i)
		{
			return Color.LerpUnclamped(a, b, Interpolate(t, i));
		}

		#endregion

		#region Vector3 Lerps

		public static Vector3 Lerp (Vector3 a, Vector3 b, float t, EASE i)
		{
			if(i == EASE.ElasticEaseIn || i == EASE.ElasticEaseInOut || i == EASE.ElasticEaseOut ||
			   i == EASE.BackEaseIn || i == EASE.BackEaseInOut || i == EASE.BackEaseOut)
			{
				return LerpUnclamped (a, b, t, i);
			}

			return Vector3.Lerp(a, b, Interpolate(t, i));
		}

		public static Vector3 LerpUnclamped (Vector3 a, Vector3 b, float t, EASE i)
		{
			return Vector3.LerpUnclamped(a, b, Interpolate(t, i));
		}

		#endregion

		#region Vector2 Lerps

		public static Vector2 Lerp (Vector2 a, Vector2 b, float t, EASE i)
		{
			if(i == EASE.ElasticEaseIn || i == EASE.ElasticEaseInOut || i == EASE.ElasticEaseOut ||
			   i == EASE.BackEaseIn || i == EASE.BackEaseInOut || i == EASE.BackEaseOut)
			{
				return LerpUnclamped (a, b, t, i);
			}

			return Vector2.Lerp(a, b, Interpolate(t, i));
		}

		public static Vector2 LerpUnclamped (Vector2 a, Vector2 b, float t, EASE i)
		{
			return Vector2.LerpUnclamped(a, b, Interpolate(t, i));
		}

		#endregion

		#region Vector4 Lerps

		public static Vector4 Lerp (Vector4 a, Vector4 b, float t, EASE i)
		{
			if(i == EASE.ElasticEaseIn || i == EASE.ElasticEaseInOut || i == EASE.ElasticEaseOut ||
			   i == EASE.BackEaseIn || i == EASE.BackEaseInOut || i == EASE.BackEaseOut)
			{
				return LerpUnclamped (a, b, t, i);
			}

			return Vector4.Lerp(a, b, Interpolate(t, i));
		}

		public static Vector4 LerpUnclamped (Vector4 a, Vector4 b, float t, EASE i)
		{
			return Vector4.LerpUnclamped(a, b, Interpolate(t, i));
		}

		#endregion

		#region Quaternion Lerps

		public static Quaternion Lerp (Quaternion a, Quaternion b, float t, EASE i)
		{
			if(i == EASE.ElasticEaseIn || i == EASE.ElasticEaseInOut || i == EASE.ElasticEaseOut ||
			   i == EASE.BackEaseIn || i == EASE.BackEaseInOut || i == EASE.BackEaseOut)
			{
				return LerpUnclamped (a, b, t, i);
			}

			return Quaternion.Lerp(a, b, Interpolate(t, i));
		}

		public static Quaternion LerpUnclamped (Quaternion a, Quaternion b, float t, EASE i)
		{
			return Quaternion.LerpUnclamped(a, b, Interpolate(t, i));
		}

		#endregion

		#region Interpolates

		private static double DoubleLerp (double a, double b, float t)
		{
			return (1.0 - double.Parse(t.ToString())) * a + double.Parse(t.ToString()) * b;
		}

		private static double InverseDoubleLerp (double a, double b, float value)
		{
			return (double.Parse(value.ToString()) - a) * (double.Parse(value.ToString()) - b);
		}

		private static float Interpolate (float t, EASE INTERPOLATION)
		{
			switch(INTERPOLATION)
			{
				default:
				
				case EASE.Linear:
					return t;

				case EASE.QuadraticEaseOut:
					return QuadraticEaseOut(t);

				case EASE.QuadraticEaseIn:
					return QuadraticEaseIn(t);
				
				case EASE.QuadraticEaseInOut:
					return QuadraticEaseInOut(t);
				
				case EASE.CubicEaseIn:
					return CubicEaseIn(t);
				
				case EASE.CubicEaseOut:
					return CubicEaseOut(t);
				
				case EASE.CubicEaseInOut:
					return CubicEaseInOut(t);
				
				case EASE.QuarticEaseIn:
					return QuarticEaseIn(t);
				
				case EASE.QuarticEaseOut:
					return QuarticEaseOut(t);
				
				case EASE.QuarticEaseInOut:
					return QuarticEaseInOut(t);
				
				case EASE.QuinticEaseIn:
					return QuinticEaseIn(t);
				
				case EASE.QuinticEaseOut:
					return QuinticEaseOut(t);
				
				case EASE.QuinticEaseInOut:
					return QuinticEaseInOut(t);
				
				case EASE.SineEaseIn:
					return SineEaseIn(t);
				
				case EASE.SineEaseOut:
					return SineEaseOut(t);
				
				case EASE.SineEaseInOut:
					return SineEaseInOut(t);
				
				case EASE.CircularEaseIn:
					return CircularEaseIn(t);
				
				case EASE.CircularEaseOut:
					return CircularEaseOut(t);
				
				case EASE.CircularEaseInOut:
					return CircularEaseInOut(t);
				
				case EASE.ExponentialEaseIn:
					return ExponentialEaseIn(t);
				
				case EASE.ExponentialEaseOut:
					return ExponentialEaseOut(t);
				
				case EASE.ExponentialEaseInOut:
					return ExponentialEaseInOut(t);
				
				case EASE.ElasticEaseIn:
					return ElasticEaseIn(t);
				
				case EASE.ElasticEaseOut:
					return ElasticEaseOut(t);
				
				case EASE.ElasticEaseInOut:
					return ElasticEaseInOut(t);
				
				case EASE.BackEaseIn:
					return BackEaseIn(t);
				
				case EASE.BackEaseOut:
					return BackEaseOut(t);
				
				case EASE.BackEaseInOut:
					return BackEaseInOut(t);
				
				case EASE.BounceEaseIn:
					return BounceEaseIn(t);
				
				case EASE.BounceEaseOut:
					return BounceEaseOut(t);
				
				case EASE.BounceEaseInOut:
					return BounceEaseInOut(t);
			}
		}
			
		private static float QuadraticEaseIn (float t)
		{
			return t * t;
		}

		private static float QuadraticEaseOut (float t)
		{
			return -(t * (t - 2.0f));
		}

		private static float QuadraticEaseInOut (float t)
		{
			if(t < 0.5f)
			{
				return 2.0f * t * t;
			}
			else
			{
				return (-2.0f * t * t) + (4.0f * t) - 1.0f;
			}
		}

		private static float CubicEaseIn (float t)
		{
			return t * t * t;
		}

		private static float CubicEaseOut (float t)
		{
			float f = (t - 1.0f);
			return f * f * f + 1.0f;
		}

		private static float CubicEaseInOut (float t)
		{
			if(t < 0.5f)
			{
				return 4.0f * t * t * t;
			}
			else
			{
				float f = ((2.0f * t) - 2.0f);
				return 0.5f * f * f * f + 1.0f;
			}
		}

		private static float QuarticEaseIn (float t)
		{
			return t * t * t * t;
		}

		private static float QuarticEaseOut (float t)
		{
			float f = (t - 1.0f);
			return f * f * f * (1.0f - t) + 1.0f;
		}

		private static float QuarticEaseInOut (float t) 
		{
			if(t < 0.5f)
			{
				return 8.0f * t * t * t * t;
			}
			else
			{
				float f = (t - 1.0f);
				return -8.0f * f * f * f * f + 1.0f;
			}
		}

		private static float QuinticEaseIn (float t) 
		{
			return t * t * t * t * t;
		}

		private static float QuinticEaseOut (float t) 
		{
			float f = (t - 1.0f);
			return f * f * f * f * f + 1.0f;
		}

		private static float QuinticEaseInOut (float t) 
		{
			if(t < 0.5f)
			{
				return 16.0f * t * t * t * t * t;
			}
			else
			{
				float f = ((2.0f * t) - 2.0f);
				return 0.5f * f * f * f * f * f + 1.0f;
			}
		}

		private static float SineEaseIn (float t)
		{
			return Mathf.Sin((t - 1.0f) * HALFPI) + 1.0f;
		}

		private static float SineEaseOut (float t)
		{
			return Mathf.Sin(t * HALFPI);
		}

		private static float SineEaseInOut (float t)
		{
			return 0.5f * (1.0f - Mathf.Cos(t * PI));
		}

		private static float CircularEaseIn (float t)
		{
			return 1.0f - Mathf.Sqrt(1.0f - (t * t));
		}

		private static float CircularEaseOut(float t)
		{
			return Mathf.Sqrt((2.0f - t) * t);
		}

		private static float CircularEaseInOut (float t)
		{
			if(t < 0.5f)
			{
				return 0.5f * (1.0f - Mathf.Sqrt(1.0f - 4.0f * (t * t)));
			}
			else
			{
				return 0.5f * (Mathf.Sqrt(-((2.0f * t) - 3.0f) * ((2.0f * t) - 1.0f)) + 1.0f);
			}
		}

		private static float ExponentialEaseIn (float t)
		{
			return Mathf.Approximately(t, 0.0f) ? t : Mathf.Pow(2.0f, 10.0f * (t - 1.0f));
		}

		private static float ExponentialEaseOut (float t)
		{
			return Mathf.Approximately(t, 1.0f) ? t : 1.0f - Mathf.Pow(2.0f, -10.0f * t);
		}

		private static float ExponentialEaseInOut (float t)
		{
			if(Mathf.Approximately(t, 0.0f) || Mathf.Approximately(t, 1.0f)) return t;

			if(t < 0.5f)
			{
				return 0.5f * Mathf.Pow(2.0f, (20.0f * t) - 10.0f);
			}
			else
			{
				return -0.5f * Mathf.Pow(2, (-20.0f * t) + 10.0f) + 1.0f;
			}
		}

		private static float ElasticEaseIn (float t)
		{
			return Mathf.Sin(13.0f * HALFPI * t) * Mathf.Pow(2.0f, 10.0f * (t - 1.0f));
		}

		private static float ElasticEaseOut (float t)
		{
			return Mathf.Sin(-13.0f * HALFPI * (t + 1.0f)) * Mathf.Pow(2.0f, -10.0f * t) + 1.0f;
		}

		private static float ElasticEaseInOut (float t)
		{
			if(t < 0.5f)
			{
				return 0.5f * Mathf.Sin(13.0f * HALFPI * (2.0f * t)) * Mathf.Pow(2.0f, 10.0f * ((2.0f * t) - 1.0f));
			}
			else
			{
				return 0.5f * (Mathf.Sin(-13.0f * HALFPI * ((2.0f * t - 1.0f) + 1.0f)) * Mathf.Pow(2.0f, -10.0f * (2.0f * t - 1.0f)) + 2.0f);
			}
		}

		private static float BackEaseIn (float t)
		{
			return t * t * t - t * Mathf.Sin(t * PI);
		}

		private static float BackEaseOut (float t)
		{
			float f = (1.0f - t);
			return 1.0f - (f * f * f - f * Mathf.Sin(t * PI));
		}

		private static float BackEaseInOut (float t)
		{
			if(t < 0.5f)
			{
				float f = 2.0f * t;
				return 0.5f * (f * f * f - f * Mathf.Sin(f * PI));
			}
			else
			{
				float f = (1.0f - (2.0f * t - 1.0f));
				return 0.5f * (1.0f - (f * f * f - f * Mathf.Sin(f * PI))) + 0.5f;
			}
		}

		private static float BounceEaseIn (float t)
		{
			return 1.0f - BounceEaseOut(1.0f - t);
		}

		private static float BounceEaseOut (float t)
		{
			if(t < 0.36f)
			{
				return (121.0f * t * t) / 16.0f;
			}
			else if(t < 0.72f)
			{
				return (9.075f * t * t) - (9.9f * t) + 3.4f;
			}
			else if(t < 0.9f)
			{
				return (12.066f * t * t) - (19.635f * t) + 8.898f;
			}
			else
			{
				return (10.8f * t * t) - (20.52f * t) + 10.72f;
			}
		}

		private static float BounceEaseInOut (float t)
		{
			if(t < 0.5f)
			{
				return 0.5f * BounceEaseIn(t * 2.0f);
			}
			else
			{
				return 0.5f * BounceEaseOut(t * 2.0f - 1.0f) + 0.5f;
			}
		}

		#endregion
	}
}
