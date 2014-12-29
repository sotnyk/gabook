using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace NukeGA
{
	public static class BitmapUtils
	{
		/// <summary>
		/// Метод конвертирует объект Bitmap в одномерный массив цветовых компонент R, G, B. 
		/// Размеры массива соответствуют количеству точек в исходном изображении, умноженному на 3. 
		/// Первой идет серия яркостей компоненты R, затем - G, последней - B. Внутри серии
		/// нумерация точек сквозная, построчная, сверху вниз (а в каждой строке - слева направо). 
		/// </summary>
		/// <param name="bmp">Экземпляр Bitmap.</param>
		/// <param name="width">Ширина изображения.</param>
		/// <param name="height">Высота изображения.</param>
		/// <returns>Одномерный массив значений компонент.</returns>
		public unsafe static byte[] BitmapToByteRGB1D(Bitmap bmp, out int width, out int height)
		{
			width = bmp.Width;
			height = bmp.Height;
			byte[] rgb = new byte[3 * height * width];
			BitmapData bd = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly,
				PixelFormat.Format24bppRgb);
			try
			{
				byte* curpos = (byte*)bd.Scan0;
				int rPos = 0, gPos = width * height, bPos = 2 * width * height;
				for (int h = 0; h < height; h++)
				{
					curpos = ((byte*)bd.Scan0) + h * bd.Stride;
					for (int w = 0; w < width; w++)
					{
						rgb[bPos++] = *(curpos++);
						rgb[gPos++] = *(curpos++);
						rgb[rPos++] = *(curpos++);
					}
				}
			}
			finally
			{
				bmp.UnlockBits(bd);
			}
			return rgb;
		}

		/// <summary>
		/// Метод предназначен для создания нового экземпляра класса Bitmap на 
		/// базе имеющейся в виде float[]-массива информацией о яркости каждого пиксела.
		/// Размеры массива соответствуют количеству точек в исходном изображении, умноженному на 3. 
		/// Первой идет серия яркостей компоненты R, затем - G, последней - B. Внутри серии
		/// нумерация точек сквозная, построчная, сверху вниз (а в каждой строке - слева направо). 
		/// </summary>
		/// <param name="rgb">Float массив с данными о яркости каждой компоненты
		/// каждого пиксела</param>
		/// <param name="width">Ширина изображения.</param>
		/// <param name="height">Высота изображения.</param>
		/// <returns>Новый экземпляр класса Bitmap</returns>
		public unsafe static Bitmap RGBToBitmap(byte[] rgb, int width, int height)
		{
			if (rgb.Length != 3 * width * height)
			{
				throw new ArrayTypeMismatchException("Size of passed array must be 3*width*height");
			}
			Bitmap result = new Bitmap(width, height, PixelFormat.Format24bppRgb);

			BitmapData bd = result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly,
				PixelFormat.Format24bppRgb);
			try
			{
				byte* curpos = (byte*)bd.Scan0;
				int rPos = 0, gPos = width * height, bPos = 2 * width * height;
				for (int h = 0; h < height; h++)
				{
					curpos = ((byte*)bd.Scan0) + h * bd.Stride;
					for (int w = 0; w < width; w++)
					{
						*(curpos++) = rgb[bPos++];
						*(curpos++) = rgb[gPos++];
						*(curpos++) = rgb[rPos++];
					}
				}
			}
			finally
			{
				result.UnlockBits(bd);
			}
			return result;
		}

		/// <summary>
		/// Метод подсчитывает количество черных точек в переданном
		/// экземпляре Bitmap.
		/// </summary>
		/// <param name="bitmap"></param>
		/// <returns></returns>
		public static int CalcBlackPoints(Bitmap bitmap)
		{
			int result = 0;
			int w, h;
			byte[] currentAsBytes = BitmapUtils.BitmapToByteRGB1D(bitmap, out w, out h);
			int shift = w * h;
			for (int r = 0, g = shift, b = shift * 2; r < shift; ++r, ++g, ++b)
				if (currentAsBytes[r] + currentAsBytes[g] + currentAsBytes[b] == 0)
					result++;
			return result;
		}
	}
}
