//Special Thanks to CreativeMatter for providing his NoiseGen Class in the Unity Forum
//https://forum.unity.com/threads/using-mathf-perlinnoise-for-camera-shake.208456/

using UnityEngine;

public static class NoiseGen
{
	public static Vector2 Shake2D(float amplitude, float frequency, int octaves, float persistance, float lacunarity, float burstFrequency, int burstContrast, float time)
	{
		float valX = 0;
		float valY = 0;

		float iAmplitude = 1;
		float iFrequency = frequency;
		float maxAmplitude = 0;

		// Burst frequency
		float burstCoord  = time / (1 - burstFrequency);

		// Sample diagonally trough perlin noise
		float burstMultiplier = Mathf.PerlinNoise(burstCoord, burstCoord);

		//Apply contrast to the burst multiplier using power, it will make values stay close to zero and less often peak closer to 1
		burstMultiplier =  Mathf.Pow(burstMultiplier, burstContrast);

		for (int i=0; i < octaves; i++) // Iterate trough octaves
		{
			float noiseFrequency = time / (1 - iFrequency) / 10;

			float perlinValueX = Mathf.PerlinNoise(noiseFrequency, 0.5f) ;
			float perlinValueY = Mathf.PerlinNoise(0.5f, noiseFrequency);

			// Adding small value To keep the average at 0 and   *2 - 1 to keep values between -1 and 1.
			perlinValueX = (perlinValueX + 0.0352f) * 2 -1;
			perlinValueY = (perlinValueY + 0.0345f) * 2 -1;

			valX += perlinValueX * iAmplitude;
			valY += perlinValueY * iAmplitude;

			// Keeping track of maximum amplitude for normalizing later
			maxAmplitude += iAmplitude;

			iAmplitude     *= persistance;
			iFrequency     *= lacunarity;
		}

		valX *= burstMultiplier;
		valY *= burstMultiplier;

		// normalize
		valX /= maxAmplitude;
		valY /= maxAmplitude;

		valX *= amplitude;
		valY *= amplitude;

		return new Vector2(valX, valY);
	}
}
