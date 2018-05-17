using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace FontTool {
	class FontPage {
		private List<FontChar> lstCharImg;
		private List<UsedHeight> heights = new List<UsedHeight>();
		private List<Hole> holes = new List<Hole>();
		private string outDir;
		private string fileName;
		private int width = 0;
		private int height = 0;
		private int currX;

		public FontPage(List<FontChar> lstCharImg, string outDir, string fileName) {
			this.lstCharImg = lstCharImg;
			this.outDir = outDir;
			this.fileName = fileName;
		}

		public void CreateFontPage() {
			lstCharImg.Sort(SortByWidthHeight);
			ResetSize();
			CreateBigImage();
			SaveFntFile();
		}

		private void CreateBigImage() {
			Bitmap img = new Bitmap(width, height, PixelFormat.Format32bppArgb);
			Graphics g = Graphics.FromImage(img);
			foreach (FontChar charImg in lstCharImg) {
				g.DrawImage(charImg.Image, charImg.Rect);
			}
			img.Save(Path.Combine(outDir, fileName + ".png"));
		}

		private void ResetSize() {
			currX = 0;
			heights.Clear();
			holes.Clear();
			if (width == 0 || height == 0) {
				CalSize();
			} else {
				if (width > height) {
					height *= 2;
				} else {
					width *= 2;
				}
			}
			AddChars();
		}

		private void CalSize() {
			int totalAcre = 0;
			foreach (FontChar charImg in lstCharImg) {
				totalAcre += charImg.Acreage;
			}
			int exp = (int)Math.Ceiling(Math.Log(totalAcre, 2));
			int heightExp = exp / 2;
			int widthExp = heightExp + exp % 2;
			height = (int)Math.Pow(2, heightExp);
			width = (int)Math.Pow(2, widthExp);
		}

		private void AddChars() {
			List<FontChar> lstChars = new List<FontChar>(lstCharImg);
			while (lstChars.Count > 0) {
				while (holes.Count > 0) {
					Hole hole = holes[0];
					FontChar bestMatch = null;
					int n = 0;
					int tmpWidth = 0;
					int tmpHeight = 0;
					while (lstChars.Count > n) {
						FontChar charImg = lstChars[n];
						tmpWidth = charImg.Width + 2;
						tmpHeight = charImg.Height + 2;
						if (hole.Width == tmpWidth && hole.Height == tmpHeight) {
							bestMatch = charImg;
							break;
						} else if (hole.Width >= tmpWidth && hole.Height >= tmpHeight ) {
							if (bestMatch == null || charImg.Width > bestMatch.Width) {
								bestMatch = charImg;
							}
						}
						n++;
					}
					if (bestMatch != null) {
						tmpWidth = bestMatch.Width + 2;
						tmpHeight = bestMatch.Height + 2;
						if (hole.Width > tmpWidth) {
							Hole hole2 = new Hole(hole.Left + tmpWidth, hole.Right, hole.Top, hole.Bottom);
							holes.Add(hole2);
						}
						if (hole.Height > tmpHeight) {
							Hole hole2 = new Hole(hole.Left, hole.Left + tmpWidth, hole.Top + tmpHeight, hole.Bottom);
							holes.Add(hole2);
						}
						AddCharByPos(hole.X, hole.Y, bestMatch);
						lstChars.Remove(bestMatch);
					}
					holes.RemoveAt(0);
				}
				bool ok = false;
				int i = 0;
				int origX = currX;
				while (lstChars.Count > i) {
					FontChar charImg = lstChars[i];
					if (charImg.Width <= width - currX) {
						if (AddChar(charImg)) {
							lstChars.Remove(charImg);
							ok = true;
							if (origX > currX) {
								break;
							} else {
								origX = currX;
							}
						} else {
							ResetSize();
							return;
						}
					} else {
						i++;
					}
				}
				if (!ok) {
					FontChar charImg = lstChars[0];
					lstChars.RemoveAt(0);
					if (!AddChar(charImg)) {
						ResetSize();
						return;
					}
				}
			}
		}

		private bool AddChar(FontChar charImg) {
			for (int i = 0; i <= heights.Count; i++) {
				if (currX + charImg.Width > width) {
					currX = 0;
				}
				int cy = 0;
				foreach (UsedHeight usedHeight in heights) {
					if (currX >= usedHeight.Right) {
						continue;
					}
					if (currX + charImg.Width < usedHeight.Left) {
						break;
					}
					if (cy < usedHeight.Y) {
						cy = usedHeight.Y;
					}
				}
				if (cy + charImg.Height <= height) {
					AddCharByPos(currX, cy, charImg, true);
					currX += charImg.Width + 1;
					return true;
				} else {
					if (i < heights.Count) {
						currX = heights[i].Right;
					}
				}
			}
			return false;
		}

		private void AddCharByPos(int cx, int cy, FontChar charImg, bool bUpdateHeights = false) {
			charImg.X = cx;
			charImg.Y = cy;
			if (bUpdateHeights) {
				UpdateHeights(cx, cy, charImg);
			}
		}

		private void UpdateHeights(int cx, int cy, FontChar charImg) {
			int left = cx;
			int right = cx + charImg.Width + 1;
			int y = cy + charImg.Height + 1;
			UsedHeight newUsedHeight = new UsedHeight(left, right, y);
			if (heights.Count == 0) {
				heights.Add(newUsedHeight);
			} else {
				List<UsedHeight> newHeights = new List<UsedHeight>();
				for (int i = 0; i < heights.Count; i++) {
					UsedHeight usedHeight = heights[i];
					if (usedHeight.Right < left || usedHeight.Left > right) {
						newHeights.Add(usedHeight);
					} else {
						if (usedHeight.Y < cy) {
							Hole hole = new Hole(Math.Max(usedHeight.Left, left), Math.Min(usedHeight.Right, right), usedHeight.Y, cy);
							holes.Add(hole);
						}
						if (usedHeight.Left <= left || usedHeight.Right >= right) {
							if (usedHeight.Y == y) {
								if (usedHeight.Right < right) {
									usedHeight.Right = right;
									newHeights.Add(usedHeight);
									newUsedHeight = null;
								} else {
									newHeights[newHeights.Count - 1].Right = usedHeight.Right;
								}
							} else {
								if (usedHeight.Left < left) {
									UsedHeight leftHeigth = usedHeight.Clone();
									leftHeigth.Right = left;
									newHeights.Add(leftHeigth);
								}
								if (newUsedHeight != null) {
									newHeights.Add(newUsedHeight);
									newUsedHeight = null;
								}
								if (usedHeight.Right > right) {
									usedHeight.Left = right;
									newHeights.Add(usedHeight);
								}
							}
						}
					}
				}
				heights = newHeights;
			}
		}

		private void SaveFntFile() {
			lstCharImg.Sort(SortByCharCode);
			string content = "info face=\"Arial\" size=32 bold=0 italic=0 charset=\"\" unicode=1 stretchH=100 smooth=1 aa=1 padding=0,0,0,0 spacing=1,1 outline=0\r\n";
			content += string.Format("common lineHeight={0} base=26 scaleW={1} scaleH={2} pages=1 packed=0 alphaChnl=1 redChnl=0 greenChnl=0 blueChnl=0\r\n", FontChar.LineHeight, width, height);
			content += string.Format("page id=0 file=\"{0}.png\"\r\n", fileName);
			content += string.Format("chars count={0}\r\n", lstCharImg.Count);
			string strCharLine = "char id={0,-3} x={1,-4} y={2,-4} width={3,-4} height={4,-4} xoffset={5,-4} yoffset={6,-4} xadvance={7,-4} page=0 chnl=15\r\n";
			foreach (FontChar charImg in lstCharImg) {
				content += string.Format(strCharLine, (int)charImg.CharCode, charImg.X, charImg.Y, charImg.Width, charImg.Height, 0, charImg.OffsetY, charImg.AdvanceX);
			}
			if (FontChar.SpaceWidth > 0) {
				content += string.Format(strCharLine, 32, 0, 0, 0, 0, FontChar.SpaceWidth, 0, FontChar.SpaceWidth);
			}
			if (FontChar.KerningPairs) {
				string kerningLoop = "";
				int count = 0;
				foreach (FontChar charImg in lstCharImg) {
					List<string> lst = charImg.GetKerningPairsStr();
					count += lst.Count;
					for (int i = 0; i < lst.Count; i++) {
						kerningLoop += lst[i];
					}
				}
				content += string.Format("\nkernings count={0}\r\n", count);
				content += kerningLoop;
			}
			SaveFile(Path.Combine(outDir, fileName + ".fnt"), content);
		}

		private void SaveFile(string filename, string content) {
			using (StreamWriter sw = new StreamWriter(filename)) {
				sw.Write(content);
			}
		}

		private int SortByWidthHeight(FontChar charA, FontChar charB) {
			if (charB.Height == charA.Height) {
				return charB.Width - charA.Width;
			}
			return charB.Height - charA.Height;
		}

		private int SortByCharCode(FontChar charA, FontChar charB) {
			return charA.CharCode - charB.CharCode;
		}
	}
}
