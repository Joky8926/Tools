﻿using System;
using System.Windows.Forms;

namespace FontTool {
	static class Program {
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main(string[] args) {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			if (args.Length == 0) {
				Application.Run(new ToolWnd());
			} else {
				Application.Run(new ToolWnd(args[0]));
			}
		}
	}
}
