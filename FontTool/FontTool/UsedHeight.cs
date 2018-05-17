namespace FontTool {
	class UsedHeight {
		private int _left;
		private int _right;
		private int _y;

		public UsedHeight(int left, int right, int y) {
			_left = left;
			_right = right;
			_y = y;
		}

		public UsedHeight Clone() {
			return new UsedHeight(_left, _right, _y);
		}

		public int Left {
			get {
				return _left;
			}
			set {
				_left = value;
			}
		}

		public int Right {
			get {
				return _right;
			}
			set {
				_right = value;
			}
		}

		public int Y {
			get {
				return _y;
			}
		}
	}
}
