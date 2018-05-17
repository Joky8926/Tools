using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace FontEditTool {
	class BMFontConfiguration {
		private string fntFile;
		private string pngFile;
		private string strInfo;
		private string strCommon;
		private string strPage;
		private string strChars;
		private List<string> lstCharLoop = new List<string>();
		private List<string> lstKerningLoop = new List<string>();
		private List<BMFontDef> _lstFontDef = new List<BMFontDef>();
		private List<BMFontKerningDef> _lstKerning = new List<BMFontKerningDef>();
		private int _commonHeight;

		public BMFontConfiguration(string fntFile) {
			this.fntFile = fntFile;
			ReadConfigFile();
			ParseConfigFile();
		}

		private void ReadConfigFile() {
			List<string> tmp = new List<string>();
			using (StreamReader sr = new StreamReader(fntFile)) {
				string line;
				while ((line = sr.ReadLine()) != null) {
					if (line != "") {
						tmp.Add(line);
					}
				}
			}
			strInfo = tmp[0] + "\r\n";
			strCommon = tmp[1] + "\r\n";
			strPage = tmp[2] + "\r\n";
			strChars = tmp[3] + "\r\n";
			int currLine = 4;
			string strKerningStart = "kernings";
			for (int i = currLine; i < tmp.Count; i++) {
				if (tmp[i].StartsWith(strKerningStart)) {
					currLine = i;
					break;
				}
				lstCharLoop.Add(tmp[i]);
			}
			if (currLine == 4) {
				return;
			}
			currLine++;
			for (int i = currLine; i < tmp.Count; i++) {
				lstKerningLoop.Add(tmp[i]);
			}
		}

		private void ParseConfigFile() {
			ParseCommonArguments();
			ParseImageFileName();
			for (int i = 0; i < lstCharLoop.Count; i++) {
				ParseCharacterDefinition(lstCharLoop[i]);
			}
			for (int i = 0; i < lstKerningLoop.Count; i++) {
				ParseKerningEntry(lstKerningLoop[i]);
			}
		}

		private void ParseCommonArguments() {
			_commonHeight = int.Parse(Regex.Match(strCommon, @"(?<=lineHeight=)\d+(?=\s)").Value);
		}

		private void ParseImageFileName() {
			string fileName = Regex.Match(strPage, @"(?<=file="").+(?="")").Value;
			pngFile = Path.Combine(Path.GetDirectoryName(fntFile), fileName);
		}

		private void ParseCharacterDefinition(string line) {
			BMFontDef characterDefinition = new BMFontDef(line);
			_lstFontDef.Add(characterDefinition);
		}
		
		private void ParseKerningEntry(string line) {
			BMFontKerningDef fontKerning = new BMFontKerningDef(line);
			_lstKerning.Add(fontKerning);
		}

		private string GetHeadLines() {
			return strInfo + Regex.Replace(strCommon, @"(?<=lineHeight=)\d+(?=\s)", _commonHeight.ToString()) + strPage + strChars;
		}

		public void SaveConfig(string content) {
			string text = GetHeadLines() + content;
			using (StreamWriter sw = new StreamWriter(fntFile)) {
				sw.Write(text);
			}
		}
		
		public string PngFileName {
			get {
				return pngFile;
			}
		}

		public List<BMFontDef> LstFontDef {
			get {
				return _lstFontDef;
			}
		}

		public List<BMFontKerningDef> LstKerning {
			get {
				return _lstKerning;
			}
		}

		public int LineHeight {
			get {
				return _commonHeight;
			}
			set {
				_commonHeight = value;
			}
		}
	}
}
