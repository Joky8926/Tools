using System.Drawing;
using System.Drawing.Imaging;

namespace FontTool {
	class CharImage {
		private const int KERNING_RAYS = 8;
		private static int minTop;
		private static int maxBottom;
		private Bitmap srcImg;
		private Bitmap _image;
		private Rectangle _rect;
		private int _width;
		private int _height;
		private int _acreage;
		private int[] arrLeftEmpty = new int[KERNING_RAYS];
		private int[] arrRightEmpty = new int[KERNING_RAYS];

		public CharImage(Bitmap image, Rectangle rect) {
			srcImg = image;
			_rect = rect;
			_image = image.Clone(rect, PixelFormat.Format32bppArgb);
			_width = _image.Width;
			_height = _image.Height;
			_acreage = _width * _height;
			if (rect.Top < minTop) {
				minTop = rect.Top;
			}
			if (rect.Bottom > maxBottom) {
				maxBottom = rect.Bottom;
			}
		}

		public void GenSidesEmpty() {
			for (int i = 0; i < KERNING_RAYS; i++) {
				int[] sides = GetLeftEmpty(i);
				arrLeftEmpty[i] = sides[0];
				arrRightEmpty[i] = sides[1];
			}
		}
		
		private int[] GetLeftEmpty(int index) {
			int left = _width;
			int right = _width;
			int y = (int)((maxBottom - minTop) * (index + 0.5) / KERNING_RAYS) - OffsetY;
			if (y >= 0 && y < _height) {
				for (int x = 0; x < _width; x++) {
					if (_image.GetPixel(x, y).A > 0) {
						left = x;
						break;
					}
				}
				for (int x = _width - 1; x >= 0; x--) {
					if (_image.GetPixel(x, y).A > 0) {
						right = _width - x - 1;
						break;
					}
				}
			}
			return new int[] { left, right };
		}

		public int CalOffset(CharImage imgB) {
			int offset = int.MaxValue;
			for (int i = 0; i < KERNING_RAYS; i++) {
				int sum = arrRightEmpty[i] + imgB.arrLeftEmpty[i];
				if (offset > sum) {
					offset = sum;
				}
			}
			return -offset;
		}

		public int Width {
			get {
				return _width;
			}
		}

		public int Height {
			get {
				return _height;
			}
		}

		public int Acreage {
			get {
				return _acreage;
			}
		}

		public int OffsetY {
			get {
				return _rect.Top - minTop;
			}
		}

		public Bitmap Image {
			get {
				return _image;
			}
		}

		public static void Init() {
			minTop = int.MaxValue;
			maxBottom = 0;
		}

		public CharImage Union(CharImage imgB) {
			if (imgB == null) {
				return this;
			}
			CharImage ret = new CharImage(srcImg, Rectangle.Union(_rect, imgB._rect));
			ret.GenSidesEmpty();
			return ret;
		}

		public static int LineHeight {
			get {
				return maxBottom - minTop;
			}
		}
	}
}
