namespace FontTool {
	struct Hole {
		private int _left;
		private int _right;
		private int _top;
		private int _bottom;
		private int _x;
		private int _y;
		private int _width;
		private int _height;

		public Hole(int left = 0, int right = 0, int top = 0, int bottom = 0) {
			_left = left;
			_right = right;
			_top = top;
			_bottom = bottom;
			_x = left;
			_y = top;
			_width = right - left;
			_height = bottom - top;
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

		public int Left {
			get {
				return _left;
			}
		}

		public int Right {
			get {
				return _right;
			}
		}

		public int Top {
			get {
				return _top;
			}
		}

		public int Bottom {
			get {
				return _bottom;
			}
		}

		public int X {
			get {
				return _x;
			}
		}

		public int Y {
			get {
				return _y;
			}
		}
	}
}
